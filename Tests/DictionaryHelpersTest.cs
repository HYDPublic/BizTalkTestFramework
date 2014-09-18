using MbUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BizTalkTestFramework.MockObjects;

namespace BizTalkTestFramework.Tests
{
    [TestFixture]
    public class DictionaryHelpersTest
    {
        [Test]
        [Row("http://www.google.com/mysamplenamespace/localname", "http://www.google.com/mysamplenamespace","localname")]
        public void CheckSplitString(string fullUri, string nspace, string name)
        { 
            String _readName;
            String _readNamespace;

            fullUri.SplitUri(out _readName, out _readNamespace);

            Assert.AreEqual(name, _readName);
            Assert.AreEqual(nspace, _readNamespace);
        }
    }
}
