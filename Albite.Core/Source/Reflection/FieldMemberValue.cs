using System;
using System.Reflection;

namespace Albite.Reflection
{
    class FieldMemberValue : IMemberValue
    {
        private readonly FieldInfo _info;

        public FieldMemberValue(FieldInfo info)
        {
            _info = info;
        }

        public object GetValue(object obj)
        {
            return _info.GetValue(obj);
        }

        public void SetValue(object obj, object value)
        {
            _info.SetValue(obj, value);
        }

        public string Name
        {
            get { return _info.Name; }
        }

        public Type MemberType
        {
            get { return _info.FieldType; }
        }
    }
}
