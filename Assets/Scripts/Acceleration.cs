using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Acceleration : MonoBehaviour
{
    [SerializeField]
    private Image Button;
    [SerializeField]
    private Sprite Yes;
    [SerializeField]
    private Sprite No;
    float Count;

    void Start()
    {
        Count = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Count == 0)
        {
            Button.sprite = No;
        }
        if (Count == 1)
        {
            Button.sprite = Yes;
        }
        if (Count == 2)
        {
            Count = 0;
        }
    }

    public void ChangeImage()
    {
        Count += 1;
    }
}
