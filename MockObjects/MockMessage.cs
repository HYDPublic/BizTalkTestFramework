using Microsoft.BizTalk.Message.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BizTalkTestFramework.MockObjects
{

    public sealed class MockMessage : IBaseMessage
    {
        public void AddPart(string partName, IBaseMessagePart part, bool bBody)
        {
            throw new NotImplementedException();
        }

        public IBaseMessagePart BodyPart
        {
            get { throw new NotImplementedException(); }
        }

        public string BodyPartName
        {
            get { throw new NotImplementedException(); }
        }

        public IBaseMessageContext Context
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

        public Exception GetErrorInfo()
        {
            throw new NotImplementedException();
        }

        public IBaseMessagePart GetPart(string partName)
        {
            throw new NotImplementedException();
        }

        public IBaseMessagePart GetPartByIndex(int index, out string partName)
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

        public Guid MessageID
        {
            get { throw new NotImplementedException(); }
        }

        public int PartCount
        {
            get { throw new NotImplementedException(); }
        }

        public void RemovePart(string partName)
        {
            throw new NotImplementedException();
        }

        public void SetErrorInfo(Exception errInfo)
        {
            throw new NotImplementedException();
        }
    }
}
