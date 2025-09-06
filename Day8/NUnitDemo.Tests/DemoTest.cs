using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnitDemo;

namespace NUnitDemo.Tests
{
    [TestFixture]
    public class DemoTest
    {
        [Test]
        public void TestDemo()
        {
           Demo obj = new Demo();
            Assert.AreEqual("Welcome to new project...", obj.Hello());
        }
    }
}
