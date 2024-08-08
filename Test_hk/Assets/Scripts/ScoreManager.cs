using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI scoreText;
    public int score = 0;
    private void Start()
    {
        CheckNull();
    }
    public void AddScore()
    {
        score++;
        UpdateScore();
    }
    public void UpdateScore()
    {
        scoreText.text = score.ToString();
    }
    private void CheckNull()
    {
        string error = "is not assigned or invalid on " + gameObject.name;

        if(scoreText == null)
        {
            Debug.LogError("Score Text" + error);
        }
    }
}
