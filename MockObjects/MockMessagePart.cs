using Microsoft.BizTalk.Message.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizTalkTestFramework.MockObjects
{
    public sealed class MockMessagePart : IBaseMessagePart
    {
        public string Charset
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public string ContentType
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public System.IO.Stream Data
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public System.IO.Stream GetOriginalDataStream()
        {
            throw new NotImplementedException();
        }

        public void GetSize(out ulong lSize, out bool fImplemented)
        {
            throw new NotImplementedException();
        }

        public bool IsMutable
        {
            get { throw new NotImplementedException(); }
        }

        public Guid PartID
        {
            get { throw new NotImplementedException(); }
        }

        public IBasePropertyBag PartProperties
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}
