using Microsoft.VisualStudio.TestTools.UnitTesting;
using testWindowsFormsApp1;

namespace TestProject
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Get_LastSavedBy()
        {
            var filepath = @"L:\02 Technical Database\Operational\Control Role\Productivity\Tracking Sheets\Zone 2 Daily Tracking Sheet.xlsx";

            var expected = @"sandys.cj";
            var actual = FileOwnerInfo.LastSavedBy(filepath);

            Assert.AreEqual(expected, actual);
        }

    }
}
