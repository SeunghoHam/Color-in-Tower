using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : Singleton<Manager>
{
    [SerializeField]
    private GameObject towerPrefab;

    [SerializeField]
    private Text myMoney;
    [SerializeField]
    private Text myHp;

    [SerializeField]
    private Text myColor_R;
    [SerializeField]
    private Text myColor_B;
    [SerializeField]
    private Text myColor_Y;

    private int increaece_color = 10;

    public static int money;

    public static int Player_hp;

    public static int color_R;
    public static int color_B;
    public static int color_Y;

    public static bool dragsangtea = false;

    public static bool dreagtower = false; //1

    public static bool dreagcolor_R = false; //2
    public static bool dreagcolor_B = false; //3
    public static bool dreagcolor_Y = false; //4

    public static bool Color_button_R = false;
    public static bool Color_button_B = false;
    public static bool Color_button_Y = false;


    public static int color_number = 1;

    public static int num_check = 1;  //1: 1개   2: 5개    3:all
    public static int type_check;  //2: 빨   3: 파    4: 노

    private float ttime = 0;

    private void Start()
    {
        money = 198;
        color_R = 99;
        color_B = 99;
        color_Y = 99;

        Player_hp = 10;
    }

    public GameObject TowerPrefab
    {
        get
        {
            return towerPrefab;
        }
    }

    private void Update()
    {
        SetCountText_money();
        SetCountText_Hp();
        SetCountText_color_R();
        SetCountText_color_B();
        SetCountText_color_Y();

        if (dreagcolor_R == true)
            type_check = 2;
        else if (dreagcolor_B == true)
            type_check = 3;
        else if (dreagcolor_Y == true)
            type_check = 4;


        if (num_check == 1)
            color_number = 1;
        else if (num_check == 2)
            color_number = 5;
        else if (num_check == 3)
            if (type_check == 2)
                color_number = color_R;
            else if (type_check == 3)
                color_number = color_B;
            else if (type_check == 4)
                color_number = color_Y;


        ttime += Time.deltaTime;
        if(ttime >= 2f)
        {
            color_UP();
            ttime = 0;
        }
    }

    public static void color_less(int type, int number)
    {
        if (type == 2)
            color_R -= number;
        else if (type == 3)
            color_B -= number;
        else if (type == 4)
            color_Y -= number;
    }

    private void color_UP()
    {
        if (Color_button_R == true)
            color_R += increaece_color;
        else if (Color_button_B == true)
            color_B += increaece_color;
        else if (Color_button_Y == true)
            color_Y += increaece_color;
    }

    void SetCountText_money()
    {
        myMoney.text = money.ToString();
    }
    void SetCountText_color_R()
    {
        myColor_R.text = color_R.ToString();
    }
    void SetCountText_color_B()
    {
        myColor_B.text = color_B.ToString();
    }
    void SetCountText_color_Y()
    {
        myColor_Y.text = color_Y.ToString();
    }

    void SetCountText_Hp()
    {
        if (Player_hp >= 0)
            myHp.text = Player_hp.ToString();
        else
            return;
    }
}