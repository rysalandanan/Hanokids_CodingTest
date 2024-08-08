using UnityEngine;
using System.IO;

[System.Serializable]
public class GameData
{
    public int score;
    public bool[] eggsState;
}
public class SaveAndLoad : MonoBehaviour
{
    [SerializeField] private ScoreManager scoreManager;
    [SerializeField] private string saveFileName;
    [SerializeField] private GameObject[] eggs;
    private string filePath;

    private void Start()
    {
        filePath = Path.Combine(Application.persistentDataPath, saveFileName+".json");

        //Load the game data at the start//
        LoadGame();
    }

    public void SaveGame()
    {
        if (scoreManager == null)
        {
            Debug.LogError("ScoreManager is invalid or not assigned");
            return;
        }

        int currentScore = scoreManager.score;

        bool[] eggsState = new bool[eggs.Length];
        for (int i =0; i < eggs.Length; i++)
        {
            eggsState[i] = eggs[i].activeSelf;
        }

        GameData data = new GameData
        {
            score = currentScore,
            eggsState = eggsState
        };
        string json = JsonUtility.ToJson(data);
        File.WriteAllText(filePath, json);
        Debug.Log("Game Save to: " + saveFileName);
    }
    private void LoadGame()
    {
        if (File.Exists(filePath))
        {
            string json = File.ReadAllText(filePath);
            GameData data = JsonUtility.FromJson<GameData>(json);

            if (data != null)
            {
                if (scoreManager != null)
                {
                    scoreManager.score = data.score;
                    scoreManager.UpdateScore();
                    Debug.Log($"Loaded score: {data.score}");
                }
                for (int i =0;i < eggs.Length;i++)
                {
                    if (i < data.eggsState.Length)
                    {
                        eggs[i].SetActive(data.eggsState[i]);
                    }
                }
            }
            else
            {
                Debug.LogWarning("Loaded data is null.");
            }
        }
        else
        {
            Debug.LogWarning("Save file not found");
        }
    }
    public void ResetGame()
    {
        if (File.Exists(filePath))
        {
            File.Delete(filePath);
            Debug.Log("Save file deleted.");
        }
        else
        {
            Debug.LogWarning("No save file to delete.");
        }

        // Optionally reset game state here
        if (scoreManager != null)
        {
            scoreManager.score = 0;
            scoreManager.UpdateScore();
        }
    }
}
