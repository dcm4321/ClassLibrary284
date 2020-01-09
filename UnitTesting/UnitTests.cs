
using System.Linq;

using ClassLibrary284;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting
{
    [TestClass]
    public class UnitTests
    {
        [TestMethod]
        public void Test1()
        {
            var rl = new RangeList(1, 3);
            Assert.IsTrue(3 == rl.Count);
            var actual = rl.ToArray();
            Assert.IsTrue(Enumerable.Range(1, 3).SequenceEqual(actual));
        }

        [TestMethod]
        public void Test1a()
        {
            var rl = new RangeList(1, 1);
            Assert.IsTrue(1 == rl.Count);
            var actual = rl.ToArray();
            Assert.IsTrue(Enumerable.Range(1, 1).SequenceEqual(actual));
        }

        [TestMethod]
        public void Test1b()
        {
            var rl = new RangeList(3, 1);
            Assert.IsTrue(0 == rl.Count);
            var actual = rl.ToArray();
            Assert.IsTrue(Enumerable.Range(1, 0).SequenceEqual(actual));
        }
    }
}
