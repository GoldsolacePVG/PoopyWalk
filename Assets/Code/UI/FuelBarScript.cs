using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBarScript : MonoBehaviour
{
    public PlayerController player;
    public Image bar;
    void Update() {
        bar.fillAmount = player.fuel / 100.0f;
    }
}
