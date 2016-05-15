using System;
using System.Reflection;

namespace Albite.Reflection
{
    // As properties are more special than fields,
    // e.g. they handle indexers as well, i.e. GetValue/SetValue
    // actually depends on getter/setter methods, that can
    // have more than zero/one parameters, e.g. for indexers
    // we have 1 argument (the index), rather than zero,
    // they cannot be handled by a single class like MemberInfo.

    /// <summary>
    /// Abstracts setting fields and simple properties (excl. properties) into one.
    /// </summary>
    public interface IMemberValue
    {
        /// <summary>
        /// Returns the value of member.
        /// </summary>
        /// <param name="obj">The object for which the member value is being queried.</param>
        /// <returns>
        /// The value of the member of <c>obj</c>.
        /// </returns>
        object GetValue(object obj);

        /// <summary>
        /// Sets the value of the member.
        /// </summary>
        /// <param name="obj">The object for which the member value is being set</param>
        /// <param name="value">The value of the member.</param>
        void SetValue(object obj, object value);

        /// <summary>
        /// Gets the underlying MemberInfo object.
        /// </summary>
        MemberInfo Info { get; }

        /// <summary>
        /// Gets the type of the member.
        /// <returns>The type of the member.</returns>
        /// </summary>
        Type MemberType { get; }

        /// <summary>
        /// <c>true</c> if member can be read from.
        /// </summary>
        bool CanRead { get; }

        /// <summary>
        /// <c>true</c> if member can be written to.
        /// </summary>
        bool CanWrite { get; }
    }
}
