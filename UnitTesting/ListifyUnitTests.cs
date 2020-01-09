
using System.Text.RegularExpressions;

using Listify.Controllers;

using Microsoft.AspNetCore.Http;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting
{
    [TestClass]
    public class ListifyUnitTests
    {
        [TestMethod]
        public void Test1() =>
            Assert.IsTrue(2 == new ListifyController().Get(1, 3, 1).Value);

        [TestMethod]
        public void Test1a() =>
            TestExtensions.StatusCode(() => new ListifyController().Get(1, 3, 4), StatusCodes.Status404NotFound
                , new Regex("index: ", RegexOptions.IgnoreCase));
    }
}
