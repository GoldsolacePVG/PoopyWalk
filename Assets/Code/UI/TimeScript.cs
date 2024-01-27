using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimeScript : MonoBehaviour
{
    public Text timerText;
    public float levelOneCountdown = 120.0f;
    void Start() {
        UpdateTimer(levelOneCountdown);
    }

    private void UpdateTimer(float timer) {
        int minutes = Mathf.FloorToInt(timer / 60);
        int seconds = Mathf.FloorToInt(timer % 60);
        if (minutes == 0 && seconds == 30) {
            timerText.color = Color.red;
        }
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

    void Update() {
        if (levelOneCountdown > 0.0f) {
            levelOneCountdown -= Time.deltaTime;
            UpdateTimer(levelOneCountdown);
        }else{
            Debug.Log("Game Over!");
        }
    }
}
