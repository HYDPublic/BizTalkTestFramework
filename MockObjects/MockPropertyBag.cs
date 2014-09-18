using Microsoft.BizTalk.Message.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizTalkTestFramework.MockObjects
{
    public sealed class MockPropertyBag : IBasePropertyBag
    {

        private MockBasePropertyBag _wrapped = new MockBasePropertyBag();



        public uint CountProperties
        {
            get { return _wrapped.CountProperties; }
        }

        public object Read(string strName, string strNamespace)
        {
            return _wrapped.Read(strName, strNamespace);
        }

        public object ReadAt(int index, out string strName, out string strNamespace)
        {
            return _wrapped.ReadAt(index,out strName, out strNamespace);
        }

        public void Write(string strName, string strNameSpace, object obj)
        {
            _wrapped.Write(strName, strNameSpace, obj);
        }
    }
}
