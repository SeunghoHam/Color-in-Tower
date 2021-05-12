using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class eeeaeaaeea : MonoBehaviour
{
    private int HP = 10;

    public float moveSpeed = 0.03f;
    public float moveSpeed1 = 0.03f;

    public bool moveU = false;
    public bool moveD = false;
    public bool moveL = false;
    public bool moveR = true;

    public float mobHpBar;

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "tower")
        {
            other.transform.parent.GetComponent<Tower_wizard>().attack(this.gameObject);

        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "GD")
        {
            moveU = false;
            moveD = true;
            moveL = false;
            moveR = false;
        }
        if (collision.tag == "GL")
        {
            moveU = false;
            moveD = false;
            moveL = true;
            moveR = false;
        }
        if (collision.tag == "GR")
        {
            moveU = false;
            moveD = false;
            moveL = false;
            moveR = true;
        }
        if (collision.tag == "GU")
        {
            moveU = true;
            moveD = false;
            moveL = false;
            moveR = false;
        }
        if (collision.tag == "EndPortal")
        {
            Debug.Log("포탈 도착");
            Manager.Player_hp -= 1;
            Destroy(gameObject);
        }
    }


    public void HPless(int damage)
    {
        HP -= damage;
        if (HP <= 0)
        {
            Manager.money += 10;
            Destroy(gameObject);
        }
    }

    void Update()
    {
        if (moveR == true) transform.position += new Vector3(moveSpeed, 0, 0);
        if (moveL == true) transform.position += new Vector3(-moveSpeed, 0, 0);
        if (moveU == true) transform.position += new Vector3(0, moveSpeed, 0);
        if (moveD == true) transform.position += new Vector3(0, -moveSpeed, 0);


    }
}