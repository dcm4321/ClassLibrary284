
using System.Linq;

using ClassLibrary284;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting
{
    [TestClass]
    public class RangeListTests
    {
        static private void GeneralTest(int low, int high, int expectedCount)
        {
            var rl = new RangeList(low, high);
            Assert.IsTrue(expectedCount == rl.Count);
            var actual = rl.ToArray();
            Assert.IsTrue(Enumerable.Range(low, low > high ? 0 : 1 + high - low).SequenceEqual(actual));
        }

        #region general tests
        [TestMethod]
        public void Test1() => GeneralTest(1, 3, 3);

        [TestMethod]
        public void Test1a() => GeneralTest(1, 1, 1);

        [TestMethod]
        public void Test1b() => GeneralTest(3, 1, 0);
        #endregion general tests

        #region contains/index tests
        [TestMethod]
        public void ContainsTest1() =>
            Assert.IsTrue(RangeList.Range(1, 3).Contains(2));

        [TestMethod]
        public void ContainsTest1a() =>
            Assert.IsFalse(RangeList.Range(1, 3).Contains(4));

        [TestMethod]
        public void ContainsTest1b() =>
            Assert.IsFalse(RangeList.Range(2, 0).Contains(2));

        [TestMethod]
        public void IndexOfTest1() =>
            Assert.IsTrue(1 == RangeList.Range(1, 3).IndexOf(2));

        [TestMethod]
        public void IndexOfTest1a() =>
            Assert.IsFalse(0 < RangeList.Range(1, 3).IndexOf(4));

        [TestMethod]
        public void IndexOfTest1b() =>
            Assert.IsFalse(0 < RangeList.Range(2, 0).IndexOf(2));

        #endregion contains/index tests

        [TestMethod]
        public void StaticTest() =>
            Assert.IsTrue(Enumerable.Range(1, 3).SequenceEqual(RangeList.Range(1, 3)));
    }
}
