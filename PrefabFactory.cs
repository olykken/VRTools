using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class PrefabFactory : EditorWindow {

        [MenuItem("'YourProjectNameHere'/Create Prefab From Selected")]
        static void CreatePrefab()
        {
            GameObject[] objs = Selection.gameObjects;

            foreach (GameObject go in objs)
            {
                string localPath = "Assets/Prefabs/Resources/" + go.name + ".prefab";
                if (AssetDatabase.LoadAssetAtPath(localPath, typeof(GameObject)))
                {
                    if (EditorUtility.DisplayDialog("Are you sure?",
                            "The prefab already exists. Do you want to overwrite it?",
                            "Yes",
                            "No"))
                    {
                        CreateNew(go, localPath);
                    }
                }
                else
                {
                    CreateNew(go, localPath);
                }
            }
        }

        // Disable the menu item if no selection is in place
        [MenuItem("Examples/Create Prefab From Selected", true)]
        static bool ValidateCreatePrefab()
        {
            return Selection.activeGameObject != null;
        }

        static void CreateNew(GameObject obj, string localPath)
        {
            Object prefab = PrefabUtility.CreateEmptyPrefab(localPath);
            PrefabUtility.ReplacePrefab(obj, prefab, ReplacePrefabOptions.ReplaceNameBased);
        }
}

