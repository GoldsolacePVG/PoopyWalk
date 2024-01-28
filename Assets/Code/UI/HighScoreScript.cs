using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighScoreScript : MonoBehaviour
{
  public Text text;

  private void Update() {
    text.text = string.Format("{0:00}:{1:00}", GameManager.game.minutes, GameManager.game.seconds);
  }
}
