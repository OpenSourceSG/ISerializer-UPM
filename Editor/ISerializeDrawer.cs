using System.Linq;
using UnityEditor;
using UnityEngine;
using Object = UnityEngine.Object;

namespace ShivanceGames.ISerializer.Editor
{
    /// <summary>
    /// Custom property drawer for <see cref="ISerializeAttribute"/>.
    /// Allows selecting any component in the scene that implements the specified interface.
    /// </summary>
    [CustomPropertyDrawer(typeof(ISerializeAttribute))]
    public class ISerializeDrawer : PropertyDrawer
    {
        /// <summary>
        /// Draws the interface field in the Unity inspector as a dropdown of all matching components.
        /// </summary>
        /// <param name="position">The rectangle on the screen to use for the property GUI.</param>
        /// <param name="property">The serialized property to make the custom GUI for.</param>
        /// <param name="label">The label of the property.</param>
        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            var attr = (ISerializeAttribute)attribute;
            var targetType = attr.InterfaceType;

            EditorGUI.BeginProperty(position, label, property);

            Object current = property.objectReferenceValue;

#if UNITY_2023_1_OR_NEWER
            var allComponents = Object.FindObjectsByType<Component>(FindObjectsInactive.Include, FindObjectsSortMode.None);
#else
            var allComponents = GameObject.FindObjectsOfType<Component>(true);
#endif
            var matching = allComponents.Where(c => c is not null && targetType.IsAssignableFrom(c.GetType())).ToList();

            string[] names = matching.Select(c => $"{c.GetType().Name} ({c.gameObject.name})").ToArray();

            int currentIndex = -1;
            if (current != null)
            {
                currentIndex = matching.IndexOf(current as Component);
            }

            int newIndex = EditorGUI.Popup(position, label.text, currentIndex, names);

            if (newIndex >= 0 && newIndex < matching.Count)
            {
                property.objectReferenceValue = matching[newIndex];
            }

            EditorGUI.EndProperty();
        }
    }
}