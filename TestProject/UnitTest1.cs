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
            var filepath = @"C: \Users\sawe.nk\Desktop\seialize.png";
            var expected = @"EU\sawe.nk";
            var actual = FileOwnerInfo.Getowner(filepath);

            Assert.AreEqual(expected, actual);
        }
    }
}
