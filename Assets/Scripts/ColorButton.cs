using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{
    [SerializeField]
    private Image Color;
    [SerializeField]
    private Sprite Red;
    [SerializeField]
    private Sprite Blue;
    [SerializeField]
    private Sprite Yellow;
    float Count;
    void Start()
    {
        Count = 0;
    }

    void Update()
    {
        if(Count == 0 )
        {
            Color.sprite = Red;
            Manager.Color_button_R = true;
            Manager.Color_button_B = false;
            Manager.Color_button_Y = false;
        }
        if(Count == 1)
        {
            Color.sprite = Blue;
            Manager.Color_button_R = false;
            Manager.Color_button_B = true;
            Manager.Color_button_Y = false;
        }
        if (Count == 2)
        {
            Color.sprite = Yellow;
            Manager.Color_button_R = false;
            Manager.Color_button_B = false;
            Manager.Color_button_Y = true;
        }
        if (Count == 3)
        {
            Count = 0;
        }
    }

    public void ChangeImage()
    {
        Count += 1;
    }
}
