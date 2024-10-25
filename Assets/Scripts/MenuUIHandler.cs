using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour {
    [SerializeField]
    private TMP_InputField playerNameText;

    private void Awake() {
        playerNameText.text = DataManager.Instance.playerName;
    }

    public void StartGame() {
        DataManager.Instance.playerName = playerNameText.text;
        SceneManager.LoadScene(1);
    }

    public void QuitGame() {
        //MainManager.Instance.SaveColor();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}