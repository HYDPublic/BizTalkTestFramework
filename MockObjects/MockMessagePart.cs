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
        #region Implementation

        private IBasePropertyBag _bag = new MockPropertyBag();

        private Guid _partId = Guid.Empty;

        private string _charset;
        private string _contentType;

        private System.IO.Stream _partStream;
        #endregion

        public Guid PartID
        {
            get
            {
                if (_partId == Guid.Empty)
                {
                    _partId = Guid.NewGuid();
                }
                return _partId;
            }
        }

        public IBasePropertyBag PartProperties
        {
            get
            {
                return _bag;
            }
            set
            {
                _bag = value;
            }
        }

        public string Charset
        {
            get
            {
                return _charset;
            }
            set
            {
                _charset = value;
            }
        }

        public string ContentType
        {
            get
            {
                return _contentType;
            }
            set
            {
                _contentType = value;
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
            return _partStream;
        }

        /// <summary>
        /// <remarks>according to http://msdn.microsoft.com/en-us/library/system.io.filestream.canseek(v=vs.110).aspx if a class derived from Stream does not support seeking, calls to Length, SetLength, Position, and Seek throw a NotSupportedException.</remarks>
        /// </summary>
        /// <param name="lSize"></param>
        /// <param name="fImplemented"></param>
        public void GetSize(out ulong lSize, out bool fImplemented)
        {
            if (!_partStream.CanSeek)
            {
                fImplemented = false;
                lSize = 0;
            }
            else
            {
                try
                {
                    fImplemented = true;
                    lSize = (ulong)_partStream.Length;
                }
                catch (NotSupportedException)
                {
                    fImplemented = false;
                    lSize = 0;                    
                }
            }
            throw new NotImplementedException();
        }

        public bool IsMutable
        {
            get { throw new NotImplementedException(); }
        }

    }
}
