using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class GameDataController : MonoBehaviour
{
  public string usedFile;
  public GameData gameData = new GameData();

  private void Awake() {
    usedFile = Application.dataPath + "/gameData.json";
  }

  public void DataLoad() {
    if (File.Exists(usedFile)) {
      string content = File.ReadAllText(usedFile);
      gameData = JsonUtility.FromJson<GameData>(content);
      GameManager.game.minutes = gameData.minutes;
      GameManager.game.seconds = gameData.seconds;
      Debug.Log("Loaded!");
    }else{
      Debug.LogError("File doesn't exist");
      File.Create(usedFile);
    }
  }

  public void DataSave() {
    GameData newData = new GameData() {
      minutes = GameManager.game.minutes, 
      seconds = GameManager.game.seconds
    };
    string JSONstring = JsonUtility.ToJson(newData);
    Debug.Log(JSONstring);
    File.WriteAllText(usedFile, JSONstring);
    Debug.Log("Saved Data!");
  }
}
