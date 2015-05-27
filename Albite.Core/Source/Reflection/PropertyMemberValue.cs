using System;
using System.Reflection;

namespace Albite.Core.Reflection
{
    public class PropertyMemberValue : MemberValue
    {
        readonly PropertyInfo info;

        public PropertyMemberValue(PropertyInfo info)
        {
            this.info = info;
        }

        public override object GetValue(object t)
        {
            return info.GetValue(t);
        }

        public override void SetValue(object t, object value)
        {
            info.SetValue(t, value);
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
