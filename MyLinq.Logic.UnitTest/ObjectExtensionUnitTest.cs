using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyLinq.Logic;

namespace MyLinq.Logic.UnitTest
{
    [TestClass]
    public class ObjectExtensionUnitTest
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void CheckArgument_NullReference_ExpectedArgumentNullException()
        {
            string name = null;
            name.CheckArgument(nameof(name));
        }

        [TestMethod]
        public void CheckArgument_StringNotNull_NoArgumentNullException()
        {
            string name = "Dieser string ist nicht null!";
            name.CheckArgument(nameof(name));
        }

        [TestMethod]
        public void CheckArgument_NullArgumentWithTestName_ExpectedArgumentNullException()
        {
            object lastName = null;
            string expected = $"Value cannot be null. (Parameter '{nameof(lastName)}')";
            try
            {
                lastName.CheckArgument(nameof(lastName));
            }
            catch (ArgumentNullException ane)
            {
                Assert.AreEqual(expected, ane.Message);
            }
        }
    }
}
