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
            this.FormClosing += FormMain_FormClosing;
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
                
                string rowIndex = (e.RowIndex + 1).ToString();

                SizeF textSize = e.Graphics.MeasureString(rowIndex, dataGridView.Font);

                int rowIndexX = Math.Max(0, e.RowBounds.Left + (dataGridView.RowHeadersWidth - (int)textSize.Width) / 2);
                int rowIndexY = e.RowBounds.Top + (dataGridView.RowTemplate.Height - (int)textSize.Height) / 2;

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
            int rowCount = ((DataGridView)sender).RowCount-1;
            this.textBoxEmployers_BYV.Text = rowCount.ToString();
        }

        private void dataGridViewMain_BYV_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            int rowCount = ((DataGridView)sender).RowCount-1;
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
        public void SortDataGridViewColumn(DataGridView dataGridView, string columnName, bool ascending)
        {
            if (dataGridView.Columns.Contains(columnName))
            {
                dataGridView.Sort(dataGridView.Columns[columnName], ascending ? ListSortDirection.Ascending : ListSortDirection.Descending);
            }
            else
            {
                MessageBox.Show($"Столбец '{columnName}' не найден в таблице.");
            }
        }

        public void FilterDataGridView(DataTable dataTable, string columnName, string filterValue)
        {
            if (dataTable.Columns.Contains(columnName))
                dataTable.DefaultView.RowFilter = string.Format("Convert([{0}], System.String) LIKE '%{1}%'", columnName, filterValue);
        }

        private void textBoxFilter_BYV_TextChanged(object sender, EventArgs e)
        {
          
                string column = comboBoxFilter_BYV.Text;
                string filter = textBoxFilter_BYV.Text;
                DataTable dataTable = (DataTable)dataGridViewMain_BYV.DataSource;
                FilterDataGridView(dataTable, column, filter);

            
        }

        private void ToolStripMenuItemExit_BYV_Click(object sender, EventArgs e)
        {
          DialogResult result = MessageBox.Show("Вы точно хотите закрыть программу? Все несохраненные данные будут утеряны.", "Предупреждение", MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
            else { }
        }

        private void ToolStripMenuNew_BYV_Click(object sender, EventArgs e)
        {
            DataService ds = new DataService();
            this.dataGridViewMain_BYV.DataSource = ds.CreateEmptyTable();
        }

        private void ToolStripMenuOpen_BYV_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.InitialDirectory = "%HOMEPATH%";  
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"; 
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    path = openFileDialog.FileName;
                    ds.LoadCsvDataToDataGridView(openFileDialog.FileName, this.dataGridViewMain_BYV);
                }
                else
                {
                    return;
                }

            }
        }

        private void ToolStripMenuSave_BYV_Click(object sender, EventArgs e)
        {
            if (path == string.Empty)
            {
                ToolStripMenuSave_BYV_Click(sender, e);
                return;
            }
            ds.SaveDataGridViewToCsv(path, this.dataGridViewMain_BYV);
        }

        private void КакToolStripMenuSaveAs_BYV_Click(object sender, EventArgs e)
        {

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.InitialDirectory = "%HOMEPATH%"; 
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*"; 
                saveFileDialog.FilterIndex = 1;
                saveFileDialog.RestoreDirectory = true;
                saveFileDialog.DefaultExt = "csv"; 
                saveFileDialog.AddExtension = true; 

                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    ds.SaveDataGridViewToCsv(saveFileDialog.FileName, this.dataGridViewMain_BYV);
                    path = saveFileDialog.FileName;
                }
                else
                {
                    return;
                }
            }
        }

        private void textBoxFind_BYV_TextChanged(object sender, EventArgs e)
        {
            TextBox tb = sender as TextBox;
            if (tb != null)
            {
                string currentText = tb.Text;
                ds.HighlightRowsWithSearchString(this.dataGridViewMain_BYV, currentText);
            }
        }

        private void ToolStripMenuInfo_BYV_Click(object sender, EventArgs e)
        {
            FormAbout formabout = new FormAbout();
            formabout.ShowDialog();
        }

       
        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            if (e.CloseReason == CloseReason.UserClosing)
            {
                
                DialogResult result = MessageBox.Show("Вы точно хотите закрыть программу? Все несохраненные данные будут утеряны.", "Предупреждение", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result != DialogResult.Yes)
                {
                    
                    e.Cancel = true;
                }
            }
        }

        private void ToolStripMenuHelp_BYV_Click(object sender, EventArgs e)
        {
            FormInfo forminfo = new FormInfo();
            forminfo.ShowDialog();
        }
    }
}
