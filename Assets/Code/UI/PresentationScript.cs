using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PresentationScript : MonoBehaviour {
    public Image logo;
    private float countDown = 0.0f;
    private bool enableToStartCount = false, enableToDisappear = false;
    
    void Update() {
        if (logo != null && !enableToStartCount){
            Color tempColor = logo.color;
            tempColor.a += 0.01f;
            tempColor.a = Mathf.Clamp01(tempColor.a);
            logo.color = tempColor;
            if (logo.color.a >= 1.0f) {enableToStartCount = true;}
        }else if(logo == null){Debug.LogError("Error charging");}

        if (enableToStartCount && !enableToDisappear) {
            countDown++;
            if (countDown >= 300.0f) {
                enableToDisappear = true;
                countDown = 0.0f;
            }
        }

        if (enableToDisappear) {
            if (logo != null) {
                Color tempColor2 = logo.color;
                tempColor2.a -= 0.01f;
                tempColor2.a = Mathf.Clamp01(tempColor2.a);
                logo.color = tempColor2;
                if (logo.color.a <= 0.0f) {SceneManager.LoadScene(1);}
            }
        }
    }
}