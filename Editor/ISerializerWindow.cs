using UnityEditor;
using UnityEngine;

namespace ShivanceGames.ISerializer.Editor
{
    /// <summary>
    /// Custom Unity Editor window for displaying documentation, usage,
    /// and feature information about the ISerializer package.
    /// </summary>
    public class ISerializerWindow : EditorWindow
    {
        /// <summary>
        /// Tabs available in the ISerializer editor window.
        /// </summary>
        private enum Tab
        {
            Overview,
            Features,
            HowToUse,
        }

        /// <summary>
        /// The currently selected tab in the editor window.
        /// </summary>
        private Tab currentTab = Tab.Overview;

        /// <summary>
        /// Scroll position for the main content area.
        /// </summary>
        private Vector2 scrollPos;

        /// <summary>
        /// Adds a new menu item under "Shivance Games" in the Unity Editor toolbar,
        /// allowing access to the ISerializer window.
        /// </summary>
        [MenuItem("Shivance Games/ISerializer")]
        public static void ShowWindow()
        {
            var window = GetWindow<ISerializerWindow>("ISerializer");
            window.minSize = new Vector2(600, 500);
            window.Show();
        }

        /// <summary>
        /// Draws all main GUI elements for the editor window.
        /// </summary>
        private void OnGUI()
        {
            DrawHeader();
            EditorGUILayout.Space(10);
            DrawTabs();
            EditorGUILayout.Space(10);

            scrollPos = EditorGUILayout.BeginScrollView(scrollPos);
            DrawContent();
            EditorGUILayout.EndScrollView();
        }

        /// <summary>
        /// Draws the header area at the top of the window, including navigation buttons.
        /// </summary>
        private void DrawHeader()
        {
            GUILayout.BeginHorizontal(EditorStyles.helpBox);
            GUILayout.FlexibleSpace();

            if (GUILayout.Button("Documentation", GUILayout.MinWidth(90)))
                Application.OpenURL("");

            if (GUILayout.Button("Contact Us", GUILayout.MinWidth(90)))
                Application.OpenURL("");

            if (GUILayout.Button("GitHub", GUILayout.MinWidth(90)))
                Application.OpenURL("https://github.com/OpenSourceSG/ISerializer");

            if (GUILayout.Button("YouTube Tutorial", GUILayout.MinWidth(90)))
                Application.OpenURL("https://www.youtube.com/channel/UCkcyY4bx0KkkorMIs_lBtLg");

            GUILayout.FlexibleSpace();
            GUILayout.EndHorizontal();
        }

        /// <summary>
        /// Draws the top navigation tabs for switching between sections.
        /// </summary>
        private void DrawTabs()
        {
            GUILayout.BeginHorizontal();
            foreach (Tab tab in System.Enum.GetValues(typeof(Tab)))
            {
                bool selected = GUILayout.Toggle(currentTab == tab, tab.ToString(), EditorStyles.toolbarButton);
                if (selected) currentTab = tab;
            }
            GUILayout.EndHorizontal();
        }

        /// <summary>
        /// Determines which content to display based on the active tab.
        /// </summary>
        private void DrawContent()
        {
            switch (currentTab)
            {
                case Tab.Overview:
                    DrawOverview();
                    break;
                case Tab.Features:
                    DrawFeatures();
                    break;
                case Tab.HowToUse:
                    DrawHowToUse();
                    break;
            }
        }

        /// <summary>
        /// Displays the Overview section, explaining why and when to use ISerializer.
        /// </summary>
        private void DrawOverview()
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.LabelField("Why use ISerializer?", EditorStyles.boldLabel);
            EditorGUILayout.EndVertical();
            
            EditorGUILayout.Space();

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.HelpBox("Unity does not natively support serialization of interfaces in the Inspector.", MessageType.Info);
            EditorGUILayout.LabelField("This extension solves that by:", EditorStyles.wordWrappedLabel);
            EditorGUILayout.LabelField(
                "• Enabling interface-driven design.\n" +
                "• Providing dropdowns for matching components.\n" +
                "• Maintaining type safety and avoiding runtime errors.\n" +
                "• Eliminating manual wiring of references.",
                EditorStyles.wordWrappedLabel
            );
            EditorGUILayout.EndVertical();
        }

        /// <summary>
        /// Displays the Features section describing the main capabilities of ISerializer.
        /// </summary>
        private void DrawFeatures()
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.LabelField("Key features of ISerializer!", EditorStyles.boldLabel);
            EditorGUILayout.EndVertical();
            
            EditorGUILayout.Space();
            
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.HelpBox("Use [ISerialize] attribute to serialize interfaces in inspector.", MessageType.Info);
            EditorGUILayout.LabelField(
                "• Dropdown selection in Inspector.\n" +
                "• Works in Unity 2021+ (2023+ supported).\n" +
                "• Lightweight, dependency-free, and editor-only.\n" +
                "• Seamless integration into existing workflows.",
                EditorStyles.wordWrappedLabel
            );
            EditorGUILayout.EndVertical();
        }

        /// <summary>
        /// Displays the How To Use section with step-by-step explanation
        /// for integrating ISerializer into a project.
        /// </summary>
        private void DrawHowToUse()
        {
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.LabelField("How to use ISerializer?", EditorStyles.boldLabel);
            EditorGUILayout.EndVertical();
            
            EditorGUILayout.Space();

            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            EditorGUILayout.LabelField(
                "• Define an interface you want to serialize (e.g., IPet).\n" +
                "• Implement that interface in one or more MonoBehaviour classes.\n" +
                "• In another script, declare an Object field and mark it with [ISerialize(typeof(YourInterface))].\n" +
                "• Select one, and your reference will be safely stored and resolved at runtime.", 
                EditorStyles.wordWrappedLabel
            );
            DrawLink("Check code example", "https://github.com/OpenSourceSG/ISerializer/tree/Akash_def?tab=readme-ov-file#how-to-use");
            EditorGUILayout.EndVertical();
        }
        
        /// <summary>
        /// Draws a clickable text hyperlink styled like an editor label.
        /// </summary>
        /// <param name="text">The visible text for the hyperlink.</param>
        /// <param name="url">The URL to open when clicked.</param>
        private void DrawLink(string text, string url)
        {
            var linkStyle = new GUIStyle(EditorStyles.label)
            {
                normal = { textColor = new Color(0.26f, 0.52f, 0.96f) },
                hover = { textColor = Color.cyan },
                fontStyle = FontStyle.Italic
            };

            var rect = GUILayoutUtility.GetRect(new GUIContent(text), linkStyle);
            EditorGUIUtility.AddCursorRect(rect, MouseCursor.Link);

            if (GUI.Button(rect, text, linkStyle))
                Application.OpenURL(url);
        }
    }
}