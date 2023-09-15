using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MinigameDatabase : MonoBehaviour
{
    public static MinigameDatabase Instance { get; private set; }

    public struct MinigameInfo
    {
        public string name;
        public List<string> credits;
        public string sceneName;

        public void Clear()
        {
            name = "";
            credits.Clear();
        }
    }

    public List<MinigameInfo> minigames = new List<MinigameInfo>();

    void Awake()
    {
        Instance = this;

        TextAsset asset = Resources.Load<TextAsset>("Minigames");
        string text = asset.text;
        text = text.Replace("\r", "");
        List<string> lines = text.Split('\n').ToList();

        MinigameInfo currentInfo = new MinigameInfo();
        currentInfo.credits = new List<string>();

        for(int i = 0; i < lines.Count; i++)
        {
            if (lines[i] == "Minigame")
            {
                minigames.Add(currentInfo);
                currentInfo.Clear();
            }
            else if (lines[i].Contains("Name: "))
            {
                currentInfo.name = lines[i].Substring(lines[i].IndexOf("Name: ") + 6);
            }
            else if (lines[i].Contains("Credits"))
            {
                currentInfo.credits = GetCredits(lines, ref i);
            }
            else if (lines[i].Contains("Scene: "))
            {
                currentInfo.sceneName = lines[i].Substring(lines[i].IndexOf("Scene: ") + 7);
            }
        }

        minigames.Add(currentInfo);
        minigames.RemoveAt(0);
    }

    List<string> GetCredits(List<string> lines, ref int i)
    {
        List<string> credits = new List<string>();

        i++;
        for(; i < lines.Count; i++)
        {
            if (lines[i].StartsWith("    -") || lines[i].Contains("Minigame"))
            {
                i--;
                break;
            }

            if (lines[i].StartsWith("        -"))
            {
                credits.Add(lines[i].Substring(10));
            }
        }

        return credits;
    }
}
