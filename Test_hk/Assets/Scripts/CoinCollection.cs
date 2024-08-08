using UnityEngine;

public class CoinCollection : MonoBehaviour
{
    private ScoreManager scoreManager;
    private void Start()
    {
        scoreManager  = FindAnyObjectByType<ScoreManager>();
    }
    private void OnMouseDown()
    {
        scoreManager.AddScore();
        DisableObject();
    }
    private void DisableObject()
    {
        this.gameObject.SetActive(false);
    }
    private void CheckNull()
    {
        string error = "is not assigned or invalid on " + gameObject.name;
        
        if(scoreManager == null)
        {
            Debug.LogError("Score Manager" + error);
        }
    }
}
