using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScreenPoopScript : MonoBehaviour
{
    public Image poopScreen;
    [SerializeField] private float countDown = 2.0f;
    public bool isDirty = false;
    public bool isPaper = false;
    [SerializeField] private bool splashed = false;
    [SerializeField] private bool canClean = false;
    
    private void Update() {
        if (isDirty) {
            var tempColor = poopScreen.color;
            tempColor.a += 0.1f;
            tempColor.a = Mathf.Clamp01(tempColor.a);
            poopScreen.color = tempColor;
            if (poopScreen.color.a >= 1.0f) {
                isDirty = false;
                splashed = true;
            }
        }

        if (!isPaper) {
            if (splashed) {
                countDown -= Time.deltaTime;
                if (countDown <= 0.0f) {
                    countDown = 2.0f;
                    splashed = false;
                    canClean = true;
                }
            }

            if (canClean && poopScreen.color.a > 0.0f) {
                var auxColor = poopScreen.color;
                auxColor.a -= 0.0005f;
                auxColor.a = Mathf.Clamp01(auxColor.a);
                poopScreen.color = auxColor;
                if (poopScreen.color.a <= 0.0f) {
                    canClean = false;
                    isPaper = false;
                }
            }
        }else{
            var auxColor = poopScreen.color;
            auxColor.a = 0.0f;
            poopScreen.color = auxColor;
            isPaper = false;
            isDirty = false;
            countDown = 2.0f;
            splashed = false;
            canClean = false;
        }
    }
}
