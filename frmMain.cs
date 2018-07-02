using System;
using System.Collections.Generic;
using System.Windows.Forms;
using KeyManager;
namespace Database2UI
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }
        private Database _database = new Database();
        private string _table;
        private List<string> _columns = new List<string>();
        private List<bool> _types = new List<bool>();
        private List<List<string>> _rowValues = new List<List<string>>();
        private List<List<List<string>>> _pickTables = new List<List<List<string>>>();
        private bool _UIReady = false;
        // 1. Get all tables from a database
        private void frmMain_Load(object sender, EventArgs e)
        {
            List<string> tables = _database.GetTables("database.xlsx");
            cbTables.Items.AddRange(tables.ToArray());
            cbPickTables.Items.AddRange(tables.ToArray());
            foreach (string table in tables)
            {
                _pickTables.Add(new List<List<string>>());
            }
            for(int i = 0; i < 10; ++i)
            {
                dtgvPick.Columns.Add("clColumn" + i.ToString(), "Column " + i.ToString());
            }
            cbTables.SelectedIndex = 0;
        }
        // 2. Get a table from all tables: columns, types
        private void cbTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbPickTables.SelectedIndex = cbTables.SelectedIndex;
            // Load table to datagridview
            _UIReady = false;
            _table = cbTables.SelectedItem.ToString();
            dtgvTable.DataSource = _database.GetTable(_table, new List<string>(), new List<string>());
            // Clear columns, types, all controls
            _columns.Clear();
            _types.Clear();
            tlpTable.Controls.Clear();
            dtgvTable.ClearSelection();
            dtgvPick.Rows.Clear();
            // Add columns, types, all controls
            for(int i = 0; i < dtgvTable.Columns.Count; ++i)
            {
                if (dtgvTable.Columns[i].ValueType == typeof(int) || dtgvTable.Columns[i].ValueType == typeof(double))
                {
                    _types.Add(false);
                }
                else {
                    _types.Add(true);
                }
                _columns.Add(dtgvTable.Columns[i].Name);
                tlpTable.Controls.Add(new Label(), 0, i);
                tlpTable.GetControlFromPosition(0, i).Text = dtgvTable.Columns[i].Name;
                TextBox textBox = new TextBox() { Dock = DockStyle.Fill };
                textBox.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                textBox.AutoCompleteSource = AutoCompleteSource.CustomSource;
                AutoCompleteStringCollection collection = new AutoCompleteStringCollection();
                collection.AddRange(_database.GetValuesByColumn(_table, _columns[i]));
                textBox.AutoCompleteCustomSource = collection;
                tlpTable.Controls.Add(textBox, 1, i);
            }
            _UIReady = true;
        }
        // 3. Clear all fields
        private void btClear_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dtgvTable.Columns.Count; ++i)
            {
                tlpTable.GetControlFromPosition(1, i).Text = "";
            }
        }
        private List<string> TextBoxes2Values()
        {
            List<string> values = new List<string>();
            for (int i = 0; i < dtgvTable.Columns.Count; ++i)
            {
                values.Add(tlpTable.GetControlFromPosition(1, i).Text);
            }
            return values;
        }
        // 4. Get rows from a table: get values
        private void btGet_Click(object sender, EventArgs e)
        {
            dtgvTable.DataSource = _database.GetTable(_table, _columns, TextBoxes2Values());
        }
        // 5. Get selected rows
        private void dtgvTable_RowStateChanged(object sender, DataGridViewRowStateChangedEventArgs e)
        {
            if (e.StateChanged == DataGridViewElementStates.Selected && dtgvTable.SelectedRows.Count > 0 && _UIReady)
            {
                _rowValues.Clear();
                foreach (DataGridViewRow row in dtgvTable.SelectedRows)
                {
                    List<string> values = new List<string>();
                    for (int i = 0; i < row.Cells.Count; ++i)
                    {
                        values.Add(row.Cells[i].Value.ToString());
                    }
                    _rowValues.Add(values);
                }
                for (int i = 0; i < _rowValues[0].Count; ++i)
                {
                    tlpTable.GetControlFromPosition(1, i).Text = _rowValues[0][i];
                }
            }
            else { }
        }
        // 6. Set selected rows
        private void btSet_Click(object sender, EventArgs e)
        {
            List<string> values = TextBoxes2Values();
            for (int i = 0; i < dtgvTable.SelectedRows.Count; ++i)
            {
                _database.SetRows(_table, _columns, _types, _rowValues[i], values);
                dtgvTable.SelectedRows[i].SetValues(values.ToArray());
            }
        }
        // 7. Create a row
        private void btCreate_Click(object sender, EventArgs e)
        {
            _database.CreateRow(_table, _types, TextBoxes2Values());
        }
        // 8. Delete selected rows
        private void dtgvTable_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                for (int i = 0; i < dtgvTable.SelectedRows.Count; ++i)
                {
                    _database.DeleteRows(_table, _columns, _types, _rowValues[i]);
                    dtgvTable.Rows.Remove(dtgvTable.SelectedRows[i]);
                }
            }
            else { }
        }
        // 9. Pick selected rows
        private void btPick_Click(object sender, EventArgs e)
        {
            cbPickTables.SelectedIndex = cbTables.SelectedIndex;
            for (int i = 0; i < dtgvTable.SelectedRows.Count; ++i)
            {
                _pickTables[cbPickTables.SelectedIndex].Add(_rowValues[i]);
                dtgvPick.Rows.Add(_rowValues[i].ToArray());
            }
        }
        // 10. Delete picked rows
        private void dtgvPick_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                for (int i = dtgvPick.SelectedRows.Count - 1; i >= 0; --i)
                {
                    _pickTables[cbPickTables.SelectedIndex].RemoveAt(dtgvPick.SelectedRows[i].Index);
                    dtgvPick.Rows.RemoveAt(dtgvPick.SelectedRows[i].Index);
                }
            }
            else { }
        }
        // 11. Get picked rows table
        private void cbPickTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            dtgvPick.Rows.Clear();
            for (int i = 0; i < _pickTables[cbPickTables.SelectedIndex].Count; ++i)
            {
                dtgvPick.Rows.Add(_pickTables[cbPickTables.SelectedIndex][i].ToArray());
            }
        }
    }
}