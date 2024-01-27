using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainAudioGenerator : MonoBehaviour
{
    public static MainAudioGenerator instance;
    public AudioSource audioSource;

    void Start()
    {
        if (instance == null) instance = this;
    }

    public void GenerateSound(AudioClip audio)
    {
            audioSource.PlayOneShot(audio);
    }
}
