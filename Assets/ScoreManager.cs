using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    [SerializeField] private GameManager gameManager;

    // Update is called once per frame
    void Update()
    {
        // convert int to string
        string score = gameManager.GetScore().ToString();
        Debug.Log(score);
        scoreText.text = score;
    }
}
