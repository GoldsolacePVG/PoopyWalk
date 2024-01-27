using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecificActionsGenerator : MonoBehaviour
{
    public AudioClip pedo;
    public AudioClip puja;

    public void GenerateSoundPedo()
    {
        MainAudioGenerator.instance.GenerateSound(pedo);
    }

    public void GenerateSoundPuja()
    {
        MainAudioGenerator.instance.GenerateSound(puja);
    }

    public void StartButtonAnimation()
    {
        MainMenuManager.instance.StartButtonAnimation();
    }
}
