using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.IO;

public class DataManager : MonoBehaviour {
    public static DataManager Instance;

    public int highScore;
    public string highScoreName;
    public string playerName;

    [SerializeField]
    private TextMeshProUGUI HighScoreText;

    void Awake() {
        if (Instance != null) {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        LoadGame();
    }

    public void SaveGame(int score) {
        SaveData data = new SaveData();

        if (score > highScore) {
            highScore = score;
            highScoreName = playerName;
            data.highScoreName = playerName;
            data.saveHighScore = score;
        } else {
            data.highScoreName = highScoreName;
            data.saveHighScore = highScore;
        }
        data.playerName = playerName;

        string json = JsonUtility.ToJson(data);

        File.WriteAllText(Application.persistentDataPath + "/savefile.json", json);
    }

    public void LoadGame() {
        string path = Application.persistentDataPath + "/savefile.json";
        if (File.Exists(path)) {
            string json = File.ReadAllText(path);
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            highScore = data.saveHighScore;
            highScoreName = data.highScoreName;
            playerName = data.playerName;

            HighScoreText.text = $"Best Score: {highScoreName}: {highScore}";
        }
    }

    [System.Serializable]
    class SaveData {
        public int saveHighScore;
        public string highScoreName;
        public string playerName;
    }
}