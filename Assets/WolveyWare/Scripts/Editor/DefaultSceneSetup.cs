#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;

[InitializeOnLoad]
public static class DefaultSceneSetup
{
    // When Unity editor opens, this constructor sets up the event callback
    static DefaultSceneSetup()
    {
        EditorSceneManager.newSceneCreated += SetUpScene;
    }

    private static void SetUpScene(Scene scene, NewSceneSetup setup, NewSceneMode mode)
    {
        // Instantiate the UI Prefab
        PrefabUtility.InstantiatePrefab((GameObject)AssetDatabase.LoadAssetAtPath("Assets/WolveyWare/Prefabs/WolveyWare Canvas.prefab", typeof(GameObject)));
    }
}
#endif