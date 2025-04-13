using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // AudioSource bileşeni, ses çalmak için kullanılacak
    private AudioSource audioSource;

    // Ses dosyasını buradan belirleyeceğiz
    public AudioClip buttonClickSound;

    // Start, ilk olarak AudioSource bileşenini alacak
    void Start()
    {
        // AudioSource bileşenini alıyoruz
        audioSource = GetComponent<AudioSource>();
    }

    // Ses çalma fonksiyonu
    public void PlayButtonClickSound()
    {
        // Eğer audioSource ve buttonClickSound mevcutsa, sesi çal
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound); // Buton tıklandığında sesi çal
        }
    }
}
