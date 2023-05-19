using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class DataManager : MonoBehaviour
{
    private string _filePath;

    private void Awake()
    {
        _filePath = Application.persistentDataPath + "/playerData.json";
    }

    public void Save(PlayerData playerData)
    {
        string json = JsonUtility.ToJson(playerData);
        File.WriteAllText(_filePath, json);
    }

    public PlayerData Load()
    {
        if (File.Exists(_filePath))
        {
            string json = File.ReadAllText(_filePath);
            return JsonUtility.FromJson<PlayerData>(json);
        }

        else
        {
            return new PlayerData();
        }
    }
}
