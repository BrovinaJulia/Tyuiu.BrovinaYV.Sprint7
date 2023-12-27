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
        {
            string testFilePath = @"C:\DataSprint7\InPutFileTask7V11.csv";

            int lineCount = 0;

            
            using (var reader = new StreamReader(testFilePath))
            {
                
                reader.ReadLine();

                
                while (reader.ReadLine() != null)
                {
                    lineCount++;
                }
            }

            
            Assert.AreEqual(9, lineCount);
        }
    }
}
