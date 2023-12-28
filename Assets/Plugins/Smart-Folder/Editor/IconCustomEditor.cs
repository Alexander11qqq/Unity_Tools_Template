using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
#if UNITY_EDITOR
using UnityEditor;

namespace DevelopmentTools
{
    [InitializeOnLoad]
    static class IconFoldersEditor
    {
        static string selectedFolderGuid;
        static int controlID;

        static IconFoldersEditor()
        {
            EditorApplication.projectWindowItemOnGUI -= OnGUI;
            EditorApplication.projectWindowItemOnGUI += OnGUI;
        }

        private static void OnGUI(string guid, Rect selectionRect)
        {
            if (guid != selectedFolderGuid)
                return;

            if (Event.current.commandName == "ObjectSelectorUpdated" && EditorGUIUtility.GetObjectPickerControlID() == controlID)
            {
                UnityEngine.Object selectedObject = EditorGUIUtility.GetObjectPickerObject();

                string folderTexGuid = AssetDatabase.GUIDFromAssetPath(AssetDatabase.GetAssetPath(selectedObject)).ToString();

                EditorPrefs.SetString(selectedFolderGuid, folderTexGuid);
            }
        }

        public static void ChooseCustomIcon()
        {
            selectedFolderGuid = Selection.assetGUIDs[0];

            controlID = EditorGUIUtility.GetControlID(FocusType.Passive);
            EditorGUIUtility.ShowObjectPicker<Sprite>(null, false, "Folder", controlID);
        }
    }

}

#endif