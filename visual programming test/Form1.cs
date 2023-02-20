using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace visual_programming_test
{
    public partial class Form1 : Form
    {

        private const int min_row_g = 0;
        private const int max_row_g = 100;
        private const int min_col_g = 0;
        private const int max_col_g = 100;
        private const int min_value_g = 0;
        private const int max_value_g = 10000;


        private static KeyValuePair<int, int> check(int n, int m)
        {
            return new KeyValuePair<int, int>(clamp(n, min_row_g, max_row_g), clamp(m, min_col_g, max_col_g));
        }

        private static int clamp(int value, int left, int right)
        {
            return value <= left ? left : value >= right ? right : value;
        }

        private static void showTableMaxValues(DataGridView dg, int n, int m)
        {
            initDataGrid(dg);

            var check_value = check(n, m);

            dg.DataSource = null;
            dg.RowCount = check_value.Key;
            dg.ColumnCount = check_value.Value;
        }

        private static void initDataGrid(DataGridView dg, bool is_modified = false)
        {
            dg.Visible = false;
            dg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dg.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dg.Dock = DockStyle.Fill;
            dg.AllowUserToAddRows = false;
            dg.AllowUserToDeleteRows = false;
            dg.AllowUserToResizeColumns = false;
            dg.MultiSelect = false;
            dg.ReadOnly = !is_modified;
            dg.RowHeadersVisible= false;
            dg.ColumnHeadersVisible= false;
        }


        private static void createRandomTable(DataGridView dg, int n, int m)
        {
            var check_value = check(n, m);

            dg.DataSource = null;
            dg.RowCount = check_value.Key;
            dg.ColumnCount = check_value.Value;

            Random rand= new Random();

            for (int i=0, ie=m; i<ie; ++i)
            {
                for (int j = 0, je = n; j < je; ++j)
                {
                    dg[i, j].Value = rand.Next(min_value_g, max_value_g);
                }
            }
            if(n >0 && m>0) dg.Visible= true;
        }

        public Form1()
        {
            InitializeComponent();
            textBox1.Text = "0";
            textBox2.Text = "0";
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox1.Text, out int _)) textBox1.Clear();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!int.TryParse(textBox2.Text, out int _)) textBox2.Clear();
        }

        private void button2_Click(object sender, EventArgs e)
        { 
            button2.Enabled= false;
            createRandomTable(dataGridView1, int.Parse(textBox1.Text), int.Parse(textBox2.Text));
            button2.Enabled = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            showTableMaxValues(dataGridView1, int.Parse(textBox1.Text), int.Parse(textBox2.Text));
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Visible= false;
            dataGridView2.Visible= false;

            initDataGrid(dataGridView1);
            initDataGrid(dataGridView2);
        }
    }
}
