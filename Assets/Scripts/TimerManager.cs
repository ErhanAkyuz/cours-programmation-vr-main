using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float countdownTime;
    private bool timerActive = false;

    [SerializeField] private GameManager gameManager;

    void Start()
    {
        countdownTime = gameManager.GetTimer();
        Debug.Log(countdownTime);
        StartTimer();
    }

    public void StartTimer()
    {
        timerActive = true;
    }

    public void StopTimer()
    {
        timerActive = false;
    }

    void Update()
    {
        if (timerActive)
        {
            countdownTime -= Time.deltaTime;

            // Assurez-vous que le temps ne devienne pas négatif
            if (countdownTime < 0)
            {
                countdownTime = 0;
                timerActive = false;
            }

            int minutes = Mathf.FloorToInt(countdownTime / 60);
            int seconds = Mathf.FloorToInt(countdownTime % 60);

            string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);

            timerText.text = timerString;

            // Si le temps atteint 0
            if (countdownTime <= 0)
            {
                Debug.Log("Le compte à rebours est terminé !");
                SceneManager.LoadScene(0);
            }
        }
    }
}
