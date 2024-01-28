using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagement : MonoBehaviour
{
  public void ChangeScene(int sceneValue) {
    SceneManager.LoadScene(sceneValue);
  }

  public void SpecialChangeScene(int sceneValue) {
    Time.timeScale = 1.0f;
    SceneManager.LoadScene(sceneValue);
  }
  
  public void ExitGame() {
    Application.Quit();
  }
}
