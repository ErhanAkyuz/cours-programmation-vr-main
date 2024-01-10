using UnityEngine;

public class MusicManager : MonoBehaviour
{
    private void Start()
    {
        AudioSource audioSource = GetComponentInChildren<AudioSource>();
        if (audioSource != null)
        {
            // Appliquer le volume enregistr� � l'AudioSource
            audioSource.volume = PlayerPrefs.GetFloat("Volume", 0.5f) / 2;
        }
    }
}
