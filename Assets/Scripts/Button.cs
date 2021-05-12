using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    [SerializeField]
    private Image Button1;
    [SerializeField]
    private Image Button4;
    [SerializeField]
    private Image Button5;
    [SerializeField]
    private Image Button6;
    [SerializeField]
    private Image image;
    [SerializeField]
    private Sprite image0;
    [SerializeField]
    private Sprite image1;
    [SerializeField]
    private Sprite image2;
    [SerializeField]
    private Sprite image3;
    [SerializeField]
    private Sprite image4;
    [SerializeField]
    private Sprite image5;
    [SerializeField]
    private Sprite image6;
    [SerializeField]
    private Sprite image7;

    ////
    [SerializeField]
    private Image image8;
    [SerializeField]
    private Image image9;
    [SerializeField]
    private Image image10;
    [SerializeField]
    private Image image11;

    int a,b;

    public static bool or = true;
    void Start()
    {
        b = 0;
    }
    void Update()
    {
        if(a == 0)
        {
            b = 0;
            or = true;
        }
        if(a == 1)
        {
            b = 1;
            or = false;
        }
        if(a == 2)
        {
            a = 0; 
          
        }
    }

    public void ChangeImage()
    {
        a += 1;
            
            if(b == 0)
        {
            Button1.sprite = image0;
            image.sprite = image1;
            Button4.sprite = image5;
            Button5.sprite = image6;
            Button6.sprite = image7;

            //포탑 -> 컬러
            image8.gameObject.SetActive(true);
            image9.gameObject.SetActive(true);
            image10.gameObject.SetActive(true);

            image11.gameObject.SetActive(false);
            //

        }
        if (b == 1)
        {
            Button1.sprite = image1;
            image.sprite = image0;
            Button4.sprite = image2;
            Button5.sprite = image3;
            Button6.sprite = image4;

            //컬러->포탑
            image8.gameObject.SetActive(false);
            image9.gameObject.SetActive(false);
            image10.gameObject.SetActive(false);

            image11.gameObject.SetActive(true);
            //
        }
    }
}
