using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

#if UNITY_EDITOR
using UnityEditor;

namespace DevelopmentTools
{
    [InitializeOnLoad]
    static class ColoredFolderEditor
    {
        static string iconName;
        static ColoredFolderEditor()
        {
            EditorApplication.projectWindowItemOnGUI -= OnGUI;
            EditorApplication.projectWindowItemOnGUI += OnGUI;
        }

        private static void OnGUI(string guid, Rect selectionRect)
        {
            Color backgroundColor;
            Rect folderRect = GetFolderRect(selectionRect, out backgroundColor);

            string iconGuid = EditorPrefs.GetString(guid, "");

            if (iconGuid == "" || iconGuid == "00000000000000000000000000000000")
                return;

            EditorGUI.DrawRect(folderRect, backgroundColor);

            string folderTextPath = AssetDatabase.GUIDToAssetPath(iconGuid);
            Texture2D folderTex = AssetDatabase.LoadAssetAtPath<Texture2D>(folderTextPath);

            GUI.DrawTexture(folderRect, folderTex);
        }

        private static Rect GetFolderRect(Rect selectionRect, out Color backgroundColor)
        {
            Rect folderRect;
            backgroundColor = new Color(.2f, .2f, .2f);

            // Second colum< small scale
            if (selectionRect.x < 15)
            {
                folderRect = new Rect(selectionRect.x + 3, selectionRect.y, selectionRect.height, selectionRect.height);
            }

            // First colum
            else if (selectionRect.x >= 15 && selectionRect.height < 30)
            {
                folderRect = new Rect(selectionRect.x, selectionRect.y, selectionRect.height, selectionRect.height);
                backgroundColor = new Color(.22f, .22f, .22f);
            }

            // Second colum, big scal
            else
            {
                folderRect = new Rect(selectionRect.x, selectionRect.y, selectionRect.width, selectionRect.width);
            }

            return folderRect;
        }

        public static void SetIconName(string m_iconName)
        {
            string folderPath = AssetDatabase.GetAssetPath(Selection.activeObject);
            string folderGuid = AssetDatabase.GUIDFromAssetPath(folderPath).ToString();

            string iconPath = "Assets/Plugins/Smart-Folder/Icons_Full/Default/" + m_iconName + ".png";
            string iconGuid = AssetDatabase.GUIDFromAssetPath(iconPath).ToString();

            EditorPrefs.SetString(folderGuid, iconGuid);
        }

        public static void ResetFolderTex()
        {
            string folderPath = AssetDatabase.GetAssetPath(Selection.activeObject);
            string folderGuid = AssetDatabase.GUIDFromAssetPath(folderPath).ToString();

            EditorPrefs.DeleteKey(folderGuid);
        }
    }      
}

#endif