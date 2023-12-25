using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Data;
using System.Globalization;
using System.Windows.Forms;
using System.Drawing;

namespace Tyuiu.BrovinaYV.Sprint7.ProjectV11.Lib
{
    public class DataService
    {
        public static int CountCsvLines(string filePath)
        {
            int lineCount = 0;

            using (var reader = new StreamReader(filePath))
            {
                // Пропускаем заголовок
                reader.ReadLine();

                // Считаем оставшиеся строки
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }
            }

            return lineCount;
        }

        public void LoadCsvDataToDataGridView(string filePath, DataGridView dataGridView)
        {
            DataTable dataTable = new DataTable();
            using (StreamReader sr = new StreamReader(filePath))
            {
                string header_str = sr.ReadLine();
                if (header_str == null)
                {
                    MessageBox.Show("Файл пустой", "Предупреждение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                string[] headers = header_str.Split(';');
                foreach (string header in headers)
                {
                    dataTable.Columns.Add(header);
                }

                while (!sr.EndOfStream)
                {
                    string[] rows = sr.ReadLine().Split(';');
                    DataRow dr = dataTable.NewRow();
                    for (int i = 0; i < headers.Length; i++)
                    {
                        // Convert Unix timestamp to DateTime for the 7th column (index 6)
                        if (i == 7)
                        {
                            double timestamp = 0.0;
                            if (!double.TryParse(rows[i], out timestamp))
                                continue;
                            DateTime dateTime = DateTimeOffset.FromUnixTimeSeconds((long)timestamp).DateTime;
                            dr[i] = dateTime.ToShortDateString();
                        }
                        else
                        {
                            dr[i] = rows[i];
                        }
                    }
                    dataTable.Rows.Add(dr);
                }
            }

            dataGridView.DataSource = dataTable;
        }

        public DataTable CreateEmptyTable()
        {
            DataTable dataTable = new DataTable();
            string[] headers = { "Фамилия", "Имя", "Отчество", "Адрес", "Номер Телефона", "Оклад", "Наименование подразделения", "Дата рождения", "Должность", "Отработанные часы" };
            foreach (string header in headers)
            {
                dataTable.Columns.Add(header);
            }
            return dataTable;
        }

        public void HighlightRowsWithSearchString(DataGridView dataGridView, string searchString)
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && searchString != string.Empty && cell.Value.ToString().Contains(searchString))
                    {
                        cell.Style.BackColor = Color.Yellow;
                    }
                    else
                    {
                        cell.Style.BackColor = Color.White;
                    }
                }
            }
        }

        public void SaveDataGridViewToCsv(string filePath, DataGridView dataGridView)
        {
            using (StreamWriter sw = new StreamWriter(filePath, false, new UTF8Encoding(true)))
            {
                // Write headers
                for (int i = 0; i < dataGridView.Columns.Count; i++)
                {
                    sw.Write(dataGridView.Columns[i].HeaderText);
                    if (i < dataGridView.Columns.Count - 1)
                        sw.Write(";");
                }
                sw.WriteLine();

                // Write data
                foreach (DataGridViewRow row in dataGridView.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        for (int i = 0; i < dataGridView.Columns.Count; i++)
                        {
                            if (i == 7) // Convert DateTime to Unix timestamp for the 7th column (index 6)
                            {
                                if (row.Cells[i].Value == null)
                                    continue;
                                if (DateTime.TryParseExact((string)row.Cells[i].Value, "dd.MM.yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime parsedDate))
                                {
                                    long unixTimestamp = ((DateTimeOffset)parsedDate).ToUnixTimeSeconds();
                                    sw.Write(unixTimestamp);
                                }
                            }
                            else
                            {
                                sw.Write(row.Cells[i].Value.ToString());
                            }

                            if (i < dataGridView.Columns.Count - 1)
                                sw.Write(";");
                        }
                        sw.WriteLine();
                    }
                }
            }
        }
    }
}

