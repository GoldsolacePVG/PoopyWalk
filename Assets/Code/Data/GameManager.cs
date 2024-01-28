using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager game = null;
    public int minutes = 1, seconds = 30;
    public bool isLevel1 = false;
    private void Awake() {
        if(game == null) {
            game = this;
        }else if(game != this) {
            Destroy(gameObject);
        }
    }
}
