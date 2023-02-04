using Eco.EM.Framework.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Runtime.InteropServices.ComTypes;

namespace em_framework_unittest
{
    [TestClass]
    public class Tables_Tests
    {
        [TestMethod]
        public void Tables_Create3ColumnTable()
        {
            var Table = Tables.New(3);

            Assert.AreEqual(3, Table.Columns.Length);
        }

        [TestMethod]
        public void Tables_Create3ColumnTable_FillWith2Rows()
        {
            var Table = Tables.New(3);
            Table.Rows.Add(new Row() { Values = "1,Clay,Leader".Split(",") });
            Table.Rows.Add(new Row() { Values = "1,Kye,Leader".Split(",") });

            Assert.AreEqual(2, Table.Rows.Count);
        }

        [TestMethod]
        public void Tables_Create3ColumnTable_FillWith2Rows_ToString()
        {
            var Table = Tables.New(3);
            Table.Rows.Add(new Row() { Values = "1,Clay,Leader".Split(",") });
            Table.Rows.Add(new Row() { Values = "1,Kye,Leader".Split(",") });

            var outputString = Tables.ToString(Table);

            Assert.AreNotEqual(string.Empty, outputString);
        }
    }
}
