using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MuteScript : MonoBehaviour
{
    public void MuteAudio(bool mute) {
        if (mute) {
            AudioListener.volume = 0.0f;
        }else{
            AudioListener.volume = 1.0f;
        }
    }
}
