using System;
using System.Reflection;

namespace Albite.Core.Reflection
{
    internal class FieldMemberValue : MemberValue
    {
        readonly FieldInfo info;

        public FieldMemberValue(FieldInfo info)
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
            get { return info.FieldType; }
        }
    }
}
