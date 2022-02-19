using System;
using Lab2.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace UnitTestProject
{
    [TestClass]
    public class UnitTest
    {
        [TestMethod]
        public void TestMethodAtbashEncode()
        {
            string text = "Виталик";
            string expected = "Эцмяуцф";
            var atbash = new Atbash();
            Assert.AreEqual(expected, atbash.Encode(text));
        }

        [TestMethod]
        public void TestMethodAtbashEncodeNumbers()
        {
            string text = "Виталик2";
            string expected = "Эцмяуцф2";
            var atbash = new Atbash();
            Assert.AreEqual(expected, atbash.Encode(text));
        }

        [TestMethod]
        public void TestMethodAtbashDecode()
        {
            string text = "фртпгбмъо";
            string expected = "компьютер";
            var atbash = new Atbash();
            Assert.AreEqual(expected, atbash.Decode(text));
        }

        [TestMethod]
        public void TestMethodRot13Encode()
        {
            string text = "компьютер";
            string expected = "чыщьикясэ";
            var rot13 = new ROT13();
            Assert.AreEqual(expected, rot13.Encode(text));
        }

        [TestMethod]
        public void TestMethodRot13Decode()
        {
            string text = "чыщьикясэ";
            string expected = "компьютер";
            var rot13 = new ROT13();
            Assert.AreEqual(expected, rot13.Decode(text));
        }
    }
}
