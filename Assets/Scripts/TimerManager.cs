using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TimerManager : MonoBehaviour
{
    public TextMeshProUGUI timerText;
    private float countdownTime;
    private bool timerActive = false;

    [SerializeField] private GameManager gameManager;

    void Start()
    {
        countdownTime = gameManager.timer;
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

            // Si le temps atteint 0, vous pouvez exécuter une action ici, par exemple :
            if (countdownTime <= 0)
            {
                // Faites quelque chose lorsque le compte à rebours atteint 0
                Debug.Log("Le compte à rebours est terminé !");
            }
        }
    }
}
