using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;

namespace TestProject1
{
    [TestClass]
    public class Tests
    {
        public Tests()
            {
            test1("1");
            }

        [TestMethod]
        public void test1(string param)
        {
            string result = string.Empty;
            string a = string.Empty;
        }
    }
}