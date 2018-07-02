using Excel = Microsoft.Office.Interop.Excel;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SQLite;
using System.Linq;
using System.Runtime.InteropServices;
using System;
using System.IO;

namespace KeyManager
{
    public class Database
    {
        private string _sql;
        private OleDbConnection _connection;
        private OleDbCommand _command;
        private OleDbDataAdapter _adapter;
        private void TextFile2List(string path, ref List<String> strings)
        {
            StreamReader reader = new StreamReader(path);
            String line;
            while ((line = reader.ReadLine()) != null)
            {
                strings.Add(line);
            }
            reader.Close();
        }
        private void Excel2DataTables(string path, ref List<DataTable> dataTables)
        {
            dataTables = new List<DataTable>();
            String constr = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" +
                            path +
                            ";Extended Properties='Excel 12.0 XML;HDR=YES;CharacterSet=65001;';";
            OleDbConnection con = new OleDbConnection(constr);
            con.Open();
            DataTable dt = con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            foreach (DataRow row in dt.Rows)
            {
                DataTable dataTable = new DataTable();
                string name = row["TABLE_NAME"].ToString();
                dataTable.TableName = name;
                OleDbCommand oconn = new OleDbCommand("SELECT * FROM [" + name + "]", con);
                OleDbDataAdapter sda = new OleDbDataAdapter(oconn);
                sda.Fill(dataTable);
                dataTables.Add(dataTable);
            }
        }
        private void DataTables2Excel(ref List<DataTable> dataTables, string file)
        {
            object misValue = System.Reflection.Missing.Value;
            Excel.Application excel = new Excel.Application();
            Excel.Workbook workbook = excel.Workbooks.Add(misValue);
            for (int i = 0; i < dataTables.Count; ++i)
            {
                Excel.Worksheet worksheet;
                if (i == 0)
                    worksheet = workbook.Worksheets[1];
                else
                    worksheet = workbook.Worksheets.Add(misValue, workbook.Worksheets[workbook.Worksheets.Count], misValue, misValue);
                worksheet.Name = dataTables[i].TableName.Trim(new char[] { '$', '\'' });
                for (int j = 0; j < dataTables[i].Columns.Count; ++j)
                {
                    worksheet.Cells[1, j + 1] = dataTables[i].Columns[j].ColumnName;
                    for (int k = 0; k < dataTables[i].Rows.Count; ++k)
                    {
                        worksheet.Cells[k + 2, j + 1] = dataTables[i].Rows[k][j];
                    }
                }
                Marshal.ReleaseComObject(worksheet);
            }
            workbook.SaveAs(file);
            workbook.Close(true, misValue, misValue);
            excel.Quit();
            Marshal.ReleaseComObject(workbook);
            Marshal.ReleaseComObject(excel);
        }
        // Create sql strings
        public string GetTableString(List<string> columns, List<string> values)
        {
            string sql = "";
            for (int i = 0; i < columns.Count; ++i)
            {
                if (values[i] != "")
                {
                    sql += columns[i] + " LIKE '%" + values[i].Replace("'", "''") + "%' AND ";
                }
                else { }
            }
            if (sql.EndsWith(" AND ") == true)
            {
                sql = sql.Substring(0, sql.Length - 5);
            }
            else { }
            return sql;
        }
        public string WhereRowString(List<string> columns, List<bool> types, List<string> values)
        {
            string sql = "";
            for (int i = 0; i < columns.Count; ++i)
            {
                if (values[i] != "")
                {
                    if (types[i] == true)
                    {
                        sql += columns[i] + "='" + values[i].Replace("'", "''") + "' AND ";
                    }
                    else
                    {
                        sql += columns[i] + "=" + values[i].Replace("'", "''") + " AND ";
                    }
                }
                else { }
            }
            if (sql.Contains(" AND ") == true)
            {
                sql = sql.Substring(0, sql.Length - 5);
            }
            else { }
            return sql;
        }
        public string SetRowString(List<string> columns, List<bool> types, List<string> values)
        {
            string sql = "";
            for (int i = 0; i < columns.Count; ++i)
            {
                if (values[i] != "")
                {
                    if (types[i] == true)
                    {
                        sql += columns[i] + "='" + values[i].Replace("'","''") + "',";
                    }
                    else
                    {
                        sql += columns[i] + "=" + values[i].Replace("'", "''") + ",";
                    }
                }
                else { }
            }
            if (sql.EndsWith(",") == true)
            {
                sql = sql.Substring(0, sql.Length - 1);
            }
            else { }
            return sql;
        }
        public string CreateRowString(List<bool> types, List<string> values)
        {
            string sql = "";
            for(int i = 0; i < types.Count; ++i)
            {
                if (types[i] == true)
                {
                    sql += "'" + values[i].Replace("'", "''") + "',";
                }
                else {
                    sql += "" + values[i].Replace("'", "''") + ",";
                }
            }
            if (sql.EndsWith(","))
            {
                sql = sql.Substring(0, sql.Length - 1);
            }
            else { }
            return sql;
        }

        // Get tables
        public List<string> GetTables(string file)
        {
            _sql = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + file + ";Extended Properties='Excel 12.0 Xml;CharacterSet=65001;HDR=YES;IMEX=1'";
            _connection = new OleDbConnection(_sql);
            _connection.Open();
            List<string> tables = new List<string>();
            DataTable dt = _connection.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null);
            foreach (DataRow row in dt.Rows)
            {
                tables.Add(row["TABLE_NAME"].ToString());
            }
            return tables;
        }
        // Get a table
        public DataTable GetTable(string table)
        {
            DataTable dt = new DataTable();
            _sql = "SELECT * FROM [" + table + "]";
            _command = new OleDbCommand(_sql, _connection);
            _adapter = new OleDbDataAdapter(_command);
            _adapter.Fill(dt);
            return dt;
        }
        // Get a part of a table
        public DataTable GetTable(string table, List<string> columns, List<string> values)
        {
            DataTable dt = new DataTable();
            _sql = "SELECT * FROM [" + table + "]";
            string extension = GetTableString(columns, values);
            if (extension != "")
            {
                _sql += " WHERE " + extension;
            }
            else { }
            _command = new OleDbCommand(_sql, _connection);
            _adapter = new OleDbDataAdapter(_command);
            _adapter.Fill(dt);
            return dt;
        }
        public string[] GetValuesByColumn(string table, string column)
        {
            List<string> values = new List<string>();
            DataTable dt = new DataTable();
            _sql = "SELECT "+ column + " FROM [" + table + "]";
            _command = new OleDbCommand(_sql, _connection);
            _adapter = new OleDbDataAdapter(_command);
            _adapter.Fill(dt);
            foreach (DataRow row in dt.Rows)
            {
                values.Add(row[0].ToString());
            }
            return values.ToArray();
        }
        // Set rows
        public void SetRows(string table, List<string> columns, List<bool> types, List<string> values, List<string> newValues)
        {
            string whereRowString = WhereRowString(columns, types, values);
            string setRowString = SetRowString(columns, types, newValues);
            _sql = "UPDATE ["+ table + "] SET " + setRowString + " WHERE " + whereRowString;
            _command = new OleDbCommand(_sql, _connection);
            _command.ExecuteNonQuery();
        }
        // Create a row
        public void CreateRow(string table, List<bool> types, List<string> newValues)
        {
            _sql = "INSERT INTO [" + table + "] VALUES (" + CreateRowString(types, newValues) + ")";
            _command = new OleDbCommand(_sql, _connection);
            _command.ExecuteNonQuery();
        }
        // Delete rows
        public void DeleteRows(string table, List<string> columns, List<bool> types, List<string> values)
        {
            string whereRowString = WhereRowString(columns, types, values);
            _sql = "DELETE FROM [" + table + "] " + " WHERE " + whereRowString;
            _command = new OleDbCommand(_sql, _connection);
            _command.ExecuteNonQuery();
        }
    }
}
