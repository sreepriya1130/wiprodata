using NUnit.Framework;
using Calculator;
using System;
using System.Security.Cryptography.X509Certificates;


namespace CalculatorTest
{
    [TestFixture]
    public class Tests
    {
        [SetUp]
        public void Setup() { }
     
        [Test]
        public void Test1()
        {
            Calculation obj1 = new Calculation();
            Assert.AreEqual(8, obj1.Add(5, 3));
        }
        [Test]
        public void Test2()
        {
            Calculation obj2 = new Calculation();
            Assert.AreEqual(2, obj2.Sub(5, 3));
        }
        [Test]
        public void Test3()
        {
            Calculation obj3 = new Calculation();
            Assert.AreEqual(15,obj3.Multiply(5, 3));
        }
        [Test]
        public void Test4()
        {
            Calculation obj4 = new Calculation();
            Assert.AreEqual(2,obj4.Divide(4,2));
        }
    }
}