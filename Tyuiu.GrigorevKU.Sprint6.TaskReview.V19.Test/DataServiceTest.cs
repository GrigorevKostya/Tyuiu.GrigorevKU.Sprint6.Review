using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Tyuiu.GrigorevKU.Sprint6.TaskReview.V19.Lib;
namespace Tyuiu.GrigorevKU.Sprint6.TaskReview.V19.Test
{
    [TestClass]
    public class DataServiceTest
    {
        [TestMethod]
        public void ValidGetMatrix()
        {
            DataService ds = new DataService();
            int[,] matrix = { { 1, 4, 2, 3, 7 },
                              { 0, 3, 7, 6, 0 },
                              { 2, 5, 5, 4, 3 },
                              { 3, 3, 5, 2, 0 },
                              { 3, 0, 0, 2, 4 } };
            int res = ds.GetMatrix(matrix, 2, 0, 4);
            int wait = 3;
            Assert.AreEqual(wait, res);
        }
    }
}
