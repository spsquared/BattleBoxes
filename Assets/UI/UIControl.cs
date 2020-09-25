using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIControl : MonoBehaviour
{
    bool menuOpen = false;
    // Start is called before the first frame update
    void Start()
    {
        hide();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("p")) {
            if (menuOpen) {
                hide();
                menuOpen = false;
            } else {
                show();
                menuOpen = true;
            }
        }
    }

    void hide() {
        //CanvasGroup.alpha = 0f;
        //CanvasGroup.interactable = false;
        //CanvasGroup.blocksRaycasts = false;
    }
    void show() {
        //CanvasGroup.alpha = 1f;
        //CanvasGroup.interactable = true;
        //CanvasGroup.blocksRaycasts = true;
    }
}
