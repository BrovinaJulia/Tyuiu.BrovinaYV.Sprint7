using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;

namespace Tyuiu.BrovinaYV.Sprint7.ProjectV11.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void TestMethod1()
        {// Утверждение
            string testFilePath = @"C:\DataSprint6\InPutFileTask7V16.csv";

            int lineCount = 0;

            // Действие
            using (var reader = new StreamReader(testFilePath))
            {
                // Пропускаем заголовок
                reader.ReadLine();

                // Считаем оставшиеся строки
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }
            }

            // Проверка
            Assert.AreEqual(9, lineCount); // Предполагаемое количество строк: 14
        }
    }
}
