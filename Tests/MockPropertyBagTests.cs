using BizTalkTestFramework.MockObjects;
using MbUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizTalkTestFramework.Tests
{

    [TestFixture()]
    public class MockPropertyBagTests
    {
        [Test]
        [Row("name","http://namespace/",42)]
        [Row("name", "http://namespace/", "String")]
        [Row("name", "http://namespace/", 3.1415)]
        [Description("This test check if adding an object to the PropertyBag correctly writes the object in the dictionary.")]
        public void TestStoreObject(string name, string nspace, object value)
        {
            var bag = new MockPropertyBag();
            bag.Write(name, nspace, value);

            Assert.AreEqual(value, bag.Read(name, nspace));
            Assert.AreEqual<uint>(1u, bag.CountProperties);
        }

        [Test]
        [Row("name", "http://namespace/", 42)]
        [Row("name", "http://namespace/", "String")]
        [Row("name", "http://namespace/", 3.1415)]
        [Description("This test check if readAt method of MockPropertyBag works as expected.")]
        public void TestReadAtMethod(string name, string nspace, object value)
        {
            var bag = new MockPropertyBag();
            bag.Write(name, nspace, value);

            string readName; 
            string readNamespace;
            var valueRead = bag.ReadAt(0, out readName, out readNamespace);
            Assert.AreEqual(value, valueRead);
            Assert.AreEqual(name, readName);
            Assert.AreEqual(nspace, readNamespace);
            Assert.AreEqual<uint>(1u, bag.CountProperties);        
        }

        [Test]
        [Row("name", "http://namespace/", 42,43)]
        [Row("name", "http://namespace/", "String", "newString")]
        [Row("name", "http://namespace/", 3.1415, 6.2765)]
        [Description("This test check if values can be updated in MockPropertyBag.")]
        public void TestUpdateOneEntry(string name, string nspace, object oldValue, object newValue)
        {
            var bag = new MockPropertyBag();
            bag.Write(name, nspace, oldValue);
            Assert.AreEqual(oldValue, bag.Read(name,nspace));
            Assert.AreEqual<uint>(1u, bag.CountProperties);
            bag.Write(name, nspace, newValue);

            Assert.AreEqual(newValue, bag.Read(name, nspace));
            Assert.AreEqual<uint>(1u, bag.CountProperties);
        }


        [Test]
        [Description("This test check if MockPropertyBag supports multiple entries.")]
        public void TestAddMultipleEntries([Column(1, "str", 3.14)] object fieldA, [Column(2, "str2", 4.14)] object fieldB, [Column(16, "str3", 23.14)] object fieldC)
        {
            var nspace = "http://namespace/";

            var bag = new MockPropertyBag();
            bag.Write("fieldA", nspace, fieldA);
            bag.Write("fieldB", nspace, fieldB);
            bag.Write("fieldC", nspace, fieldC);

            Assert.AreEqual(fieldA, bag.Read("fieldA", nspace));
            Assert.AreEqual(fieldB, bag.Read("fieldB", nspace));
            Assert.AreEqual(fieldC, bag.Read("fieldC", nspace));
            Assert.AreEqual<uint>(3u, bag.CountProperties);
        }

        [Test]
        [Description("This test check if MockPropertyBag supports multiple entries in its ReadAt method.")]
        public void TestReadAtMultipleEntries([Column(1, "str", 3.14)] object fieldA, [Column(2, "str2", 4.14)] object fieldB, [Column(16, "str3", 23.14)] object fieldC)
        {
            var nspace = "http://namespace/";

            var bag = new MockPropertyBag();
            bag.Write("fieldA", nspace, fieldA);
            bag.Write("fieldB", nspace, fieldB);
            bag.Write("fieldC", nspace, fieldC);

            Assert.AreEqual(fieldA, bag.Read("fieldA", nspace));
            Assert.AreEqual(fieldB, bag.Read("fieldB", nspace));
            Assert.AreEqual(fieldC, bag.Read("fieldC", nspace));

            object readValue;
            string readNamespace;
            string readName;

            readValue = bag.ReadAt(0,out readName, out readNamespace);
            Assert.AreEqual(fieldA, readValue);
            Assert.AreEqual("fieldA", readName);
            Assert.AreEqual(nspace, readNamespace);
            readValue = bag.ReadAt(1, out readName, out readNamespace);
            Assert.AreEqual(fieldB, readValue);
            Assert.AreEqual("fieldB", readName);
            Assert.AreEqual(nspace, readNamespace);
            readValue = bag.ReadAt(2, out readName, out readNamespace);
            Assert.AreEqual(fieldC, readValue);
            Assert.AreEqual("fieldC", readName);
            Assert.AreEqual(nspace, readNamespace);

            Assert.AreEqual<uint>(3u, bag.CountProperties);
        }

    }
}
