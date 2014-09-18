using Microsoft.BizTalk.Message.Interop;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Collections.Specialized;


namespace BizTalkTestFramework.MockObjects
{
    internal class MockBasePropertyBag : IBasePropertyBag
    {
        Dictionary<XmlQualifiedName, object> _bag = new Dictionary<XmlQualifiedName,object>();

        public uint CountProperties
        {
            get { return (uint)_bag.Count; }
        }

        public object Read(string strName, string strNamespace)
        {
            return _bag[new XmlQualifiedName(strName,strNamespace)];
        }

        public object ReadAt(int index, out string strName, out string strNamespace)
        {
            var key = _bag.Keys.ToList()[index];
            strNamespace = key.Namespace;
            strName = key.Name;
            return _bag[key];
        }

        public void Write(string strName, string strNameSpace, object obj)
        {
            var key = new XmlQualifiedName(strName, strNameSpace);
            _bag[key] = obj;
            // http://stackoverflow.com/questions/4245064/method-to-add-new-or-update-existing-item-in-dictionary
            //if (_bag.ContainsKey(key))
            //    _bag[key] = obj;
            //else _bag.Add(key, obj);

        }
    }
}
