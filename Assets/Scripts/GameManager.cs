using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int difficulty = 0;
    public int timer = 60;
    private int score = 0;
    // Start is called before the first frame update
    void Start()
    {
        PlayerPrefs.GetInt("Difficulty");
        switch (difficulty)
        {
            case 0:
                timer = 30; break;
            case 1:
                timer = 60; break;
            case 2:
                timer = 90; break;
        }

    }

    public int GetScore()
    {
        return score;
    }

    public void SetScore(int score)
    { this.score = score; }

}
