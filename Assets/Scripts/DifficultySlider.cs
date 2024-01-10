using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DifficultySlider : MonoBehaviour
{
    [SerializeField] private Slider difficultySlider;

    private void Start()
    {
        difficultySlider.value = PlayerPrefs.GetFloat("Difficulty", 0);
    }

    public void OnDifficultyChange()
    {
        PlayerPrefs.GetFloat("Difficulty", difficultySlider.value);
        Debug.Log("Difficulty changed to " + difficultySlider.value);
    }
}
