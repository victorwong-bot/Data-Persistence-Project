using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.SceneManagement;
using TMPro;

public class MenuHandler : MonoBehaviour
{
    public TMP_InputField inputField;
    public TextMeshProUGUI inputText;
    public TextMeshProUGUI bestScoreText;

    void Start()
    {
        DataManager.Instance.LoadData();
        bestScoreText.text = $"Best Score: {DataManager.Instance.playerMaxName} : {DataManager.Instance.playerMaxScore}";
        inputField.text = DataManager.Instance.playerMaxName;
    }
    public void EnterName()
    {
        DataManager.Instance.playerName = inputText.text;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
    #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
    #else
        Application.Quit();
    #endif
    }
}
