using Microsoft.BizTalk.Message.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BizTalkTestFramework.MockObjects
{
    /// <summary>
    /// http://msdn.microsoft.com/en-us/library/ee268986(v=bts.10).aspx
    /// <remarks>
    /// Notice that existing properties never have a NULL value. A NULL value means that the property does not exist. For example:
    /// * Attempting to set (or promote) a property value to NULL deletes the property with S_OK.
    /// * Attempting to read a nonexistent property returns NULL with S_OK.
    /// * For predicate-related interfaces, "x:a=NULL" (VT_NULL), which is the same as the hypothetical NotExists(x:a) predicate, is the test for nonexistence of a property x:a.
    /// Multivalued property values are still contained in the same single variant value (pVar).
    /// </remarks>
    /// </summary>
    public sealed class MockMessageContext :  IBaseMessageContext
    {
        private MockBasePropertyBag _wrapped = new MockBasePropertyBag();

        private Dictionary<XmlQualifiedName, bool> _promotionStatus = new Dictionary<XmlQualifiedName,bool>();
        private Dictionary<XmlQualifiedName, byte> _propertyType = new Dictionary<XmlQualifiedName, byte>();

        private const byte PROP_PREDICATE = 4;
        private const byte PROP_PROMOTED = 2;
        private const byte PROP_WASPROMOTED = 16;
        private const byte PROP_WRITTEN = 1;



        public void AddPredicate(string strName, string strNameSpace, object obj)
        {
            // TODO: A predicate is promoted or not?
            // And if a predicate already exists?
            _promotionStatus.Write(strName, strNameSpace, true);
            _propertyType.Write(strName, strNameSpace, PROP_PREDICATE);
            _wrapped.Write(strName, strNameSpace, obj);
        }

        public uint CountProperties
        {
            get { return _wrapped.CountProperties; }
        }

        public ContextPropertyType GetPropertyType(string strName, string strNameSpace)
        {
            switch (_propertyType.Read(strName, strNameSpace))
            {
                case (PROP_PREDICATE): return ContextPropertyType.PropPredicate;
                case (PROP_PROMOTED): return ContextPropertyType.PropPromoted;
                case (PROP_WASPROMOTED): return ContextPropertyType.PropWasPromoted;
                case (PROP_WRITTEN): return ContextPropertyType.PropWritten;
                default: throw new NotSupportedException(String.Format("Value '{0}' not supported as PropertyType", _propertyType.Read(strName, strNameSpace)));
            }
        }

        /// <summary>
        /// <remarks>What should happen if field requested does not exists? it returns false?</remarks>
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strNameSpace"></param>
        /// <returns></returns>
        public bool IsPromoted(string strName, string strNameSpace)
        {
            // TODO: Test if entry does not exists.
            return _promotionStatus.Read(strName, strNameSpace);
        }

        /// <summary>
        /// <remarks>What happens if field is already promoted and i'm going to promote it?</remarks>
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strNameSpace"></param>
        /// <param name="obj"></param>
        public void Promote(string strName, string strNameSpace, object obj)
        {
            _promotionStatus.Write(strName,strNameSpace,true);
            _propertyType.Write(strName, strNameSpace, PROP_PROMOTED);
            _wrapped.Write(strName, strNameSpace, obj);
        }

        public object Read(string strName, string strNamespace)
        {
            return _wrapped.Read(strName, strNamespace);
        }

        public object ReadAt(int index, out string strName, out string strNamespace)
        {
            return _wrapped.ReadAt(index, out strName, out strNamespace);
        }

        /// <summary>
        /// <remarks>In this implementation writing a promoted value, will reset its promotion to false.</remarks>
        /// </summary>
        /// <param name="strName"></param>
        /// <param name="strNameSpace"></param>
        /// <param name="obj"></param>
        public void Write(string strName, string strNameSpace, object obj)
        {
            /// TODO: Needs to check if its promoted? and if it was promoted and now it is not, the property should be set to PROPWasPromoted?
            _promotionStatus.Write(strName, strNameSpace,false);
            _propertyType.Write(strName, strNameSpace, PROP_WRITTEN);
            _wrapped.Write(strName, strNameSpace, obj);
        }
    }
}
