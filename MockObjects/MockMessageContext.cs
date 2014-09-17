using Microsoft.BizTalk.Message.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizTalkTestFramework.MockObjects
{
    public sealed class MockMessageContext : IBaseMessageContext
    {
        public void AddPredicate(string strName, string strNameSpace, object obj)
        {
            throw new NotImplementedException();
        }

        public uint CountProperties
        {
            get { throw new NotImplementedException(); }
        }

        public ContextPropertyType GetPropertyType(string strName, string strNameSpace)
        {
            throw new NotImplementedException();
        }

        public bool IsPromoted(string strName, string strNameSpace)
        {
            throw new NotImplementedException();
        }

        public void Promote(string strName, string strNameSpace, object obj)
        {
            throw new NotImplementedException();
        }

        public object Read(string strName, string strNamespace)
        {
            throw new NotImplementedException();
        }

        public object ReadAt(int index, out string strName, out string strNamespace)
        {
            throw new NotImplementedException();
        }

        public void Write(string strName, string strNameSpace, object obj)
        {
            throw new NotImplementedException();
        }
    }
}
