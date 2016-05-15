using System;
using System.Reflection;

namespace Albite.Reflection
{
    class PropertyMemberValue : IMemberValue
    {
        private readonly PropertyInfo _info;

        public PropertyMemberValue(PropertyInfo info)
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

        public MemberInfo Info
        {
            get { return _info; }
        }

        public Type MemberType
        {
            get { return _info.PropertyType; }
        }

        public bool CanRead
        {
            get { return _info.CanRead; }
        }

        public bool CanWrite
        {
            get { return _info.CanWrite; }
        }
    }
}
