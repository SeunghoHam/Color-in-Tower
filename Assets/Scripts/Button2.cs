using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button2 : MonoBehaviour
{
    [SerializeField]
    private Image Button4;
    [SerializeField]
    private Image Button5;
    [SerializeField]
    private Image Button6;
    [SerializeField]
    private Sprite image0_0;
    [SerializeField]
    private Sprite image0_1;
    [SerializeField]
    private Sprite image1_0;
    [SerializeField]
    private Sprite image1_1;
    [SerializeField]
    private Sprite image2_0;
    [SerializeField]
    private Sprite image2_1;

    public static bool or;
    int a;
    void Start()
    {
        a = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Button.or == false)
        {
            a = 1;
        }
        else
        {
            a = 0;
        }
    }

    public void ChangeImage_0()
    {
        if (a == 1)
        {
            Button4.sprite = image0_1;
            Button5.sprite = image1_0;
            Button6.sprite = image2_0;

            Manager.num_check = 1;
        }
    }

    public void Changelmage_1()
    {
        if (a == 1)
        {
            Button4.sprite = image0_0;
            Button5.sprite = image1_1;
            Button6.sprite = image2_0;

            Manager.num_check = 2;
        }
    }

    public void Changelmage_2()
    {
        if (a == 1)
        {
            Button4.sprite = image0_0;
            Button5.sprite = image1_0;
            Button6.sprite = image2_1;

            Manager.num_check = 3;
        }
    }
}
