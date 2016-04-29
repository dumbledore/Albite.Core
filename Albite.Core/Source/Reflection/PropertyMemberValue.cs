using System;
using System.Reflection;

namespace Albite.Core.Reflection
{
    internal class PropertyMemberValue : MemberValue
    {
        readonly PropertyInfo info;

        public PropertyMemberValue(PropertyInfo info)
        {
            this.info = info;
        }

        public override object GetValue(object obj)
        {
            return info.GetValue(obj);
        }

        public override void SetValue(object obj, object value)
        {
            info.SetValue(obj, value);
        }

        public override string Name
        {
            get { return info.Name; }
        }

        public override Type MemberType
        {
            get { return info.PropertyType; }
        }
    }
}
