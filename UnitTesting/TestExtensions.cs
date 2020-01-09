
using System;
using System.Text.RegularExpressions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTesting
{
    static public class TestExtensions
    {
        public static void Throws<T>(Action action, string expectedMessage = null) where T : Exception
        {
            try
            {
                action();
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex is T, $"exception must be of type ${typeof(T).Name}");
                Assert.IsTrue(expectedMessage == null || expectedMessage == ex.Message, $"${ex.Message} must match {expectedMessage}");
                return;
            }
            Assert.Fail("Expected exception but no exception was thrown.");
        }

        static public void StatusCode<T>(this Func<T> aresult, int expectedStatusCode)
            where T: IActionResult
        {
            Assert.IsTrue(expectedStatusCode == (aresult() as ObjectResult)?.StatusCode);
        }

        static public void StatusCode<T>(this Func<ActionResult<T>> aresult, int expectedStatusCode, string expectedMessage = null)
        {
            var or = ((IConvertToActionResult) aresult()).Convert() as ObjectResult;
            Assert.IsTrue(or != null);
            Assert.IsTrue(expectedStatusCode == or.StatusCode
                          && (expectedMessage == null || expectedMessage == or.Value.ToString()));
        }

        static public void StatusCode<T>(this Func<ActionResult<T>> aresult, int expectedStatusCode, Regex expectedMessage)
        {
            var or = ((IConvertToActionResult) aresult()).Convert() as ObjectResult;
            Assert.IsTrue(or != null);
            Assert.IsTrue(expectedStatusCode == or.StatusCode
                          && (expectedMessage == null || expectedMessage.IsMatch(or.Value.ToString())));
        }
    }
}
