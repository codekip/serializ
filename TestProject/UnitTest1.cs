using Microsoft.VisualStudio.TestTools.UnitTesting;
using testWindowsFormsApp1;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            // var filepath = @"L:\01 Site Tools\03 Support Tools\03 FLT-RDT System\OLDVersion\FLT Maintenance System.xlsb";
            var filepath = @"L:\01 Site Tools\06 Daily Management\02 PQ Data\PQ Results 0910\High bay rejects by month\2016\03_2016 Rejects raw.xls";

            var expected = @"gardiner.aj";
            var actual = FileOwnerInfo.LastSavedBy(filepath);

            Assert.AreEqual(expected, actual);
        }
    }
}
