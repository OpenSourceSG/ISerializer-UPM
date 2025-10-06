using System;
using UnityEngine;

namespace ShivanceGames.ISerializer
{
    /// <summary>
    /// Attribute to serialize interface references in the Unity inspector.
    /// </summary>
    [AttributeUsage(AttributeTargets.Field)]
    public class ISerializeAttribute : PropertyAttribute
    {
        /// <summary>
        /// The interface type that this field must implement.
        /// </summary>
        public Type InterfaceType { get; private set; }

        /// <summary>
        /// Creates a new <see cref="ISerializeAttribute"/> for the given interface type.
        /// </summary>
        /// <param name="type">The interface type to restrict the field to.</param>
        /// <exception cref="ArgumentException">Thrown if the provided type is not an interface.</exception>
        public ISerializeAttribute(Type type)
        {
            if (!type.IsInterface)
            {
                throw new ArgumentException("ISerializeAttribute only works with interfaces.");
            }
            
            InterfaceType = type;
        }
    }
}