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

        #region Private Implementation
        private IBaseMessageContext _context = new MockMessageContext();

        private Dictionary<String, IBaseMessagePart> _partDictionary = new Dictionary<string,IBaseMessagePart>();

        private String _bodyPartName;
        private IBaseMessagePart _bodyPart;

        private Guid _messageId = Guid.Empty;
        private Exception _innerException = null;
        #endregion

        #region Construction

        internal IBaseMessage AddContextValue(string name, string nspace, bool isPromoted, object value)
        {
            if (isPromoted)
            { 
                _context.Promote(name, nspace, value); 
            }
            else
            {
                _context.Write(name, nspace, value);
            }
            return this;

        }
        internal IBaseMessage AddContextValue(string nameAndNamespace, bool isPromoted, object value)
        {
            string strName;
            string strNamespace;

            nameAndNamespace.SplitUri(out strName, out strNamespace);

            return AddContextValue(strName, strNamespace, isPromoted,value);
        }

        internal IBaseMessage WithPart(string partName, IBaseMessagePart part, bool bBody)
        {
            this.AddPart(partName, part, bBody);
            return this;
        }

        internal IBaseMessage WithId(Guid messageId)
        {
            if (_messageId == null)
            {
                _messageId = messageId;
            }
            else throw new InvalidOperationException("Id was already assigned");
            return this;
        }
        #endregion
        public void AddPart(string partName, IBaseMessagePart part, bool bBody)
        {
            if (bBody)
            {
                this._bodyPartName = partName;
                this._bodyPart = part;
            }

            this._partDictionary[partName] = part;
        }

        public IBaseMessagePart BodyPart
        {
            get { return _bodyPart; }
        }

        public string BodyPartName
        {
            get { return _bodyPartName; }
        }

        public IBaseMessageContext Context
        {
            get
            {
                return _context;
            }
            set
            {
                _context = value;
            }
        }


        public IBaseMessagePart GetPart(string partName)
        {
            return _partDictionary[partName];
        }

        public IBaseMessagePart GetPartByIndex(int index, out string partName)
        {
            partName = this._partDictionary.Keys.ToList()[index];
            return this._partDictionary[partName];
        }


        public Guid MessageID
        {
            get {
                // TODO: Move assignment in Factory.
                if (_messageId == null) _messageId = Guid.NewGuid();    
                return _messageId; 
            }
        }

        public int PartCount
        {
            get { return _partDictionary.Count; }
        }

        public void RemovePart(string partName)
        {
            if (partName == _bodyPartName) throw new InvalidOperationException(String.Format("Unable to remove part {0} because it's a BodyPart",_bodyPartName));
            this._partDictionary.Remove(partName);
        }
        public Exception GetErrorInfo()
        {
            return _innerException;
        }

        public void SetErrorInfo(Exception errInfo)
        {
            _innerException = errInfo;
        }

        /// <summary>
        /// Gets the size of the message.This method is not CLS-compliant.
        /// </summary>
        /// <param name="lSize">When this method returns, contains the size of the message.</param>
        /// <param name="fImplemented">true if the IBaseMessage object can determine the size; otherwise, false.</param>
        public void GetSize(out ulong lSize, out bool fImplemented)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// Gets a value that indicates whether the message context can be changed by components during processing.
        /// </summary>
        public bool IsMutable
        {
            get { throw new NotImplementedException(); }
        }


    }
}
