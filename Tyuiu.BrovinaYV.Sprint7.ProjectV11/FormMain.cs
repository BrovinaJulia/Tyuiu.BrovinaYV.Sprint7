using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tyuiu.BrovinaYV.Sprint7.ProjectV11.Lib;

namespace Tyuiu.BrovinaYV.Sprint7.ProjectV11
{
    public partial class FormMain : Form
    {
        string path = "";
        DataService ds = new DataService();

        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonAddData_BYV_Click(object sender, EventArgs e)
        {
            DataTable data_source = this.dataGridViewMain_BYV.DataSource as DataTable;
            if (data_source == null)
                return;
            DataRow new_row = data_source.NewRow();
            new_row["Фамилия"] = textBoxSurname_BYV.Text;
            new_row["Имя"] = textBoxName_BYV.Text;
            new_row["Отчество"] = textBoxPatronymic_BYV.Text;
            new_row["Адрес"] = textBoxAdress_BYV.Text;
            new_row["Номер Телефона"] = textBoxPhoneNumber_BYV.Text;
            new_row["Оклад"] = textBoxSalary_BYV.Text;
            new_row["Наименование подразделения"] = textBoxSubUnit_BYV.Text;
            new_row["Дата рождения"] = dateTimePickerBirthday_BYV.Value.ToShortDateString();
            new_row["Должность"] = textBoxJobPost_BYV.Text;
            new_row["Отработанные часы"] = 0;
            data_source.Rows.Add(new_row);
        }

        private void buttonDeleteRow_BYV_Click(object sender, EventArgs e)
        {
            if (dataGridViewMain_BYV.SelectedRows.Count > 0 && !dataGridViewMain_BYV.Rows[dataGridViewMain_BYV.SelectedRows[0].Index].IsNewRow)
            {
                dataGridViewMain_BYV.Rows.RemoveAt(dataGridViewMain_BYV.SelectedRows[0].Index);
            }
            else
            {
                MessageBox.Show("Выделите строку для удаления");
            }
        }

        private void dataGridViewMain_BYV_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            var dataGridView = sender as DataGridView;
            if (dataGridView != null)
            {
                // Get the row index in the correct format (e.g., "1", "2", etc.)
                string rowIndex = (e.RowIndex + 1).ToString();

                // Determine the display size based on the row index string
                SizeF textSize = e.Graphics.MeasureString(rowIndex, dataGridView.Font);

                // Determine where to draw the text on the row header
                int rowIndexX = Math.Max(0, e.RowBounds.Left + (dataGridView.RowHeadersWidth - (int)textSize.Width) / 2);
                int rowIndexY = e.RowBounds.Top + (dataGridView.RowTemplate.Height - (int)textSize.Height) / 2;

                // Draw the row index
                e.Graphics.DrawString(rowIndex, dataGridView.Font, SystemBrushes.ControlText, rowIndexX, rowIndexY);
            }
        }

        private void buttonAddHours_BYV_Click(object sender, EventArgs e)
        {

            int row_index = 0;
            int hours_number = 0;
            if (!int.TryParse(this.textBoxRows_BYV.Text, out row_index))
            {
                MessageBox.Show("Ошибка при добавлении количества часов\nНомер строки не является числом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (!int.TryParse(this.textBoxHours_BYV.Text, out hours_number))
            {
                MessageBox.Show("Ошибка при добавлении количества часов\nКоличество часов не является числом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DataTable ds = this.dataGridViewMain_BYV.DataSource as DataTable;
            if (ds != null)
            {
                if (row_index < 1 || row_index > ds.Rows.Count)
                    return;
                if (ds.Rows[row_index - 1]["Отработанные часы"] != null)
                {
                    ds.Rows[row_index - 1]["Отработанные часы"] = int.Parse(ds.Rows[row_index - 1]["Отработанные часы"].ToString()) + hours_number;
                }
                else
                {
                    ds.Rows[row_index - 1]["Отработанные часы"] = hours_number;
                }
            }
        }

        private void dataGridViewMain_BYV_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            int rowCount = ((DataGridView)sender).RowCount;
            this.textBoxEmployers_BYV.Text = rowCount.ToString();
        }

        private void dataGridViewMain_BYV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            int rowCount = ((DataGridView)sender).RowCount;
            this.textBoxEmployers_BYV.Text = rowCount.ToString();
        }

        private void buttonShowChart_BYV_Click(object sender, EventArgs e)
        {
            chartMain_BYV.Series.Clear();
            var series = new System.Windows.Forms.DataVisualization.Charting.Series("Отработанные часы");
            series.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Column;
            foreach (DataGridViewRow row in this.dataGridViewMain_BYV.Rows)
            {
                if (!row.IsNewRow && row.Cells["Отработанные часы"] != null && row.Cells["Отработанные часы"].Value != null)
                {
                    string label = row.Cells["Фамилия"].Value.ToString();
                    double hours = Convert.ToDouble(row.Cells["Отработанные часы"].Value);
                    series.Points.AddXY(label, hours);
                }
            }
            this.chartMain_BYV.Series.Add(series);
        }
    }
}
