using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace BizTalkTestFramework.MockObjects
{
    public static class DictionaryHelpers
    {

        public static void SplitUri(this String fullUri, out string name, out string nspace)
        {
            int index = fullUri.LastIndexOf('/');
            nspace = fullUri.Substring(0, index);
            name = fullUri.Substring(index+1);
        }

        public static T Read<T>(this Dictionary<XmlQualifiedName, T> dict, string strName, string strNamespace)
        {
            return dict[new XmlQualifiedName(strName, strNamespace)];
        }

        public static void Write<T>(this Dictionary<XmlQualifiedName, T> dict, string strName, string strNamespace, T value)
        {
            dict[new XmlQualifiedName(strName, strNamespace)] = value;
        }

    }
}
