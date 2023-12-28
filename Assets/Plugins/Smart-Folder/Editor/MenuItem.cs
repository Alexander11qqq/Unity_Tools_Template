using System.Collections;
using System.Collections.Generic;
using UnityEngine;

#if UNITY_EDITOR
using UnityEditor;

namespace DevelopmentTools
{
    static class MenuItems
    {
        const int priority = 100000;

        [MenuItem("Assets/Custom Folder/Red", false, priority)]
        static void Red()
        {
            ColoredFolderEditor.SetIconName("Red");
        }

        [MenuItem("Assets/Custom Folder/Green", false, priority)]
        static void Green()
        {
            ColoredFolderEditor.SetIconName("Green");
        }

        [MenuItem("Assets/Custom Folder/Blue", false, priority)]
        static void Blue()
        {
            ColoredFolderEditor.SetIconName("Blue");
        }

        [MenuItem("Assets/Custom Folder/Custom icon...", false, priority + 11)]
        static void Custom()
        {
            IconFoldersEditor.ChooseCustomIcon();
        }

        [MenuItem("Assets/Custom Folder/Reset icon", false, priority + 23)]
        static void ResetIcon()
        {
            ColoredFolderEditor.ResetFolderTex();
        }

        [MenuItem("Assets/CreateFolder/Red", true)]
        [MenuItem("Assets/CreateFolder/Green", true)]
        [MenuItem("Assets/CreateFolder/Blue", true)]
        [MenuItem("Assets/CreateFolder/Custom icon...", true)]
        [MenuItem("Assets/CreateFolder/Reset icon", true)]
        static bool ValidateFolder()
        {
            if(Selection.activeObject == null)
                return false;

            Object selectionObject = Selection.activeObject;

            string objectPath = AssetDatabase.GetAssetPath(selectionObject);
            return AssetDatabase.IsValidFolder(objectPath);
        }

    }
}

#endif