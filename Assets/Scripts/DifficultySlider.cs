using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySlider : MonoBehaviour
{
    [SerializeField] private Slider difficultySlider;

    private void Start()
    {
        difficultySlider.value = PlayerPrefs.GetInt("Difficulty", 0);
    }

    public void OnDifficultyChange()
    { 
        int difficulty = (int) difficultySlider.value;
        PlayerPrefs.GetInt("Difficulty", difficulty);
        Debug.Log("Difficulty changed to " + difficultySlider.value);
    }
}
