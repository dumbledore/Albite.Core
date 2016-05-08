using System;
using System.Reflection;

namespace Albite.Reflection
{
    class FieldMemberValue : IMemberValue
    {
        readonly FieldInfo info;

        public FieldMemberValue(FieldInfo info)
        {
            this.info = info;
        }

        public object GetValue(object obj)
        {
            return info.GetValue(obj);
        }

        public void SetValue(object obj, object value)
        {
            info.SetValue(obj, value);
        }

        public string Name
        {
            get { return info.Name; }
        }

        public Type MemberType
        {
            get { return info.FieldType; }
        }
    }
}
