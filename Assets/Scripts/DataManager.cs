using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using TMPro;
using UnityEngine.UI;
using System.IO;


public class DataManager : MonoBehaviour
{
    public static DataManager Instance;

    public string playerName;
    public int playerMaxScore;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
              
        }
        else 
        {
             Destroy(gameObject);
        }
    }

    [System.Serializable]
    class PlayerData
    {
        public string playerName;
        public int playerScore;
    }

    public void SaveData()
    {
        PlayerData data = new PlayerData();
        data.playerName = playerName;
        data.playerScore = playerMaxScore;

        string json = JsonUtility.ToJson(data);
        string path = Application.persistentDataPath + "/savedata.json";
        File.WriteAllText(path, json);
    }

    public void LoadData()
    {
        string path = Application.persistentDataPath + "/savedata.json";
        Debug.Log(path);
        if (File.Exists(path))
        {
            string json = File.ReadAllText(path);
            
            PlayerData data = JsonUtility.FromJson<PlayerData>(json);
            playerName = data.playerName;
            playerMaxScore = data.playerScore;
        }
    }




}
