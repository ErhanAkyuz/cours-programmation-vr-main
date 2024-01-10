using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class VolumeSlider : MonoBehaviour
{
    [SerializeField] private Slider volumeSlider;

    private void Start()
    {
        // Charger la valeur enregistr�e ou utiliser une valeur par d�faut
        volumeSlider.value = PlayerPrefs.GetFloat("Volume", 0.5f);
    }

    public void OnVolumeChange()
    {
        // Mettre � jour le volume dans PlayerPrefs lorsque le slider change
        PlayerPrefs.SetFloat("Volume", volumeSlider.value);
        Debug.Log("Volume changed to " + volumeSlider.value);
    }
}
