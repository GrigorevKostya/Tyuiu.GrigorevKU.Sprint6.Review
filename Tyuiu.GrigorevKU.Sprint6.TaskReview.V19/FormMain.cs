using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tyuiu.GrigorevKU.Sprint6.TaskReview.V19.Lib;
namespace Tyuiu.GrigorevKU.Sprint6.TaskReview.V19
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }
        DataService ds = new DataService();

        private void labelRandomStop_GKU_Click(object sender, EventArgs e)
        {

        }

        private void buttonGenerate_GKU_Click(object sender, EventArgs e)
        {
            try
            {
                int n1 = Convert.ToInt32(textBoxRangeStart_GKU.Text);
                int n2 = Convert.ToInt32(textBoxRangeStop_GKU.Text);
                int n = Convert.ToInt32(textBoxRowCount_GKU.Text);
                int m = Convert.ToInt32(textBoxColumnCount_GKU.Text);

                int[,] arrayValues = new int[n, m];

                arrayValues = ds.GenerateMatrix(n1, n2, n, m);

                dataGridViewMatrix_GKU.ColumnCount = m;
                dataGridViewMatrix_GKU.RowCount = n;

                for (int i = 0; i < m; i++)
                {
                    dataGridViewMatrix_GKU.Columns[i].Width = 50;
                }

                for (int j = 0; j < n; j++)
                {
                    for (int c = 0; c < m; c++)
                    {
                        dataGridViewMatrix_GKU.Rows[j].Cells[c].Value = arrayValues[j, c];
                    }
                }
            }
            catch
            {
                MessageBox.Show("Введены неверные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            buttonDone_GKU.Enabled = true;
            textBoxCalcStart_GKU.Enabled = true;
            textBoxCalcStop_GKU.Enabled = true;
            textBoxSelectedRow_GKU.Enabled = true;
            textBoxResult_GKU.Enabled = true;
        }

        private void buttonDone_GKU_Click(object sender, EventArgs e)
        {
            try
            {
                int r = Convert.ToInt32(textBoxSelectedRow_GKU.Text);
                int k = Convert.ToInt32(textBoxCalcStart_GKU.Text);
                int l = Convert.ToInt32(textBoxCalcStop_GKU.Text);
                int row = dataGridViewMatrix_GKU.Rows.Count;
                int column = dataGridViewMatrix_GKU.Columns.Count;

                int[,] mx = new int[row, column];
                for (int row1 = 0; row1 < row; row1++)
                {
                    for (int col = 0; col < column; col++)
                    {
                        mx[row1, col] = Convert.ToInt32(dataGridViewMatrix_GKU.Rows[row1].Cells[col].Value.ToString());
                    }
                }
                if (k <= l)
                {
                    textBoxResult_GKU.Text = Convert.ToString(ds.GetMatrix(mx, r, k, l));
                }
                else
                {
                    MessageBox.Show("Введены неверные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch
            {
                MessageBox.Show("Введены неверные данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
