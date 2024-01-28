using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenuScript : MonoBehaviour
{
  public PlayerController player;
  
  public void ResumeGame() {
    Time.timeScale = 1.0f;
    player.isPause = false;
    gameObject.SetActive(false);
  }
}
