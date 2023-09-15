#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEditor.SceneManagement;

public class WolveywareBuildTool : EditorWindow
{
    [MenuItem("WolveyWare/Build Tool")]
    public static void Open()
    {
        GetWindow<WolveywareBuildTool>("WolveyWare Build Tool");
    }

    void OnGUI()
    {
        if(GUILayout.Button("Regenerate Minigames"))
        {
            RegenerateMinigames();
        }
        if(GUILayout.Button("Clear Minigames"))
        {
            ClearMinigames();
        }
    }

    string GetRelativeFilepath(string filepath)
    {
        string relativeFilepath = filepath.Substring(Application.dataPath.Length - 6);
        relativeFilepath = relativeFilepath.Replace('\\', '/');
        return relativeFilepath;
    }

    void RegenerateMinigames()
    {
        StreamWriter writer = new StreamWriter("Assets/Resources/Minigames.txt");

        foreach (string filepath in Directory.EnumerateFiles(Application.dataPath, "*.unity", SearchOption.AllDirectories))
        {
            string relativeFilepath = GetRelativeFilepath(filepath);

            if (relativeFilepath.Contains("WolveyWare/") || relativeFilepath.Contains("_Development/"))
            {
                continue;
            }

            if(!IsInEditorBuild(relativeFilepath))
            {
                EditorBuildSettingsScene[] list = EditorBuildSettings.scenes;
                EditorBuildSettingsScene[] newList = new EditorBuildSettingsScene[list.Length + 1];
                for (int i = 0; i < list.Length; i++)
                    newList[i] = list[i];

                newList[newList.Length - 1] = new EditorBuildSettingsScene(relativeFilepath, true);
                EditorBuildSettings.scenes = newList;
            }

            Scene scene = EditorSceneManager.OpenScene(relativeFilepath, OpenSceneMode.Additive);
            string filename = relativeFilepath.Substring(relativeFilepath.LastIndexOf('/') + 1);
            string minigameName = "";
            foreach(GameObject gameObject in scene.GetRootGameObjects())
            {
                MinigameManager minigameManager = gameObject.GetComponent<MinigameManager>();
                if(minigameManager != null)
                {
                    minigameName = minigameManager.minigameName;

                    writer.WriteLine("Minigame");
                    writer.WriteLine("    - Name: " + minigameManager.minigameName);
                    writer.WriteLine("    - Scene: " + filename.Substring(0, filename.Length - 6));
                    writer.WriteLine("    - Credits: ");
                    foreach (string name in minigameManager.creators)
                        writer.WriteLine("        - " + name);

                    break;
                }
            }

            Debug.Log("Added Minigame " + minigameName);

            EditorSceneManager.CloseScene(scene, true);
        }

        writer.Close();
        Debug.Log("Regenerated Minigames");
    }

    bool IsInEditorBuild(string relativeFilepath)
    {
        for(int i = 0; i < EditorBuildSettings.scenes.Length; i++)
        {
            if (EditorBuildSettings.scenes[i].path == relativeFilepath)
            {
                return true;
            }
        }

        return false;
    }

    void ClearMinigames()
    {
        EditorBuildSettingsScene[] newList = new EditorBuildSettingsScene[1];
        newList[0] = new EditorBuildSettingsScene("WolveyWare/Scenes/Main Menu", true);
        EditorBuildSettings.scenes = newList;

        StreamWriter writer = new StreamWriter("Assets/Resources/Minigames.txt");
        writer.Close();

        Debug.Log("Minigame Cleared");
    }

    public void Capture(Camera camera, string minigameName)
    {
        RenderTexture activeRenderTexture = RenderTexture.active;
        RenderTexture.active = camera.targetTexture;

        camera.Render();

        Texture2D image = new Texture2D(camera.targetTexture.width, camera.targetTexture.height);
        image.ReadPixels(new Rect(0, 0, camera.targetTexture.width, camera.targetTexture.height), 0, 0);
        image.Apply();
        RenderTexture.active = activeRenderTexture;

        byte[] bytes = image.EncodeToPNG();
        Destroy(image);

        File.WriteAllBytes(Application.dataPath + "/Resources/Screenshots/" + minigameName + ".png", bytes);
    }
}
#endif