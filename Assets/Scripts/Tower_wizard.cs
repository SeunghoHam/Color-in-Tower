using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower_wizard : MonoBehaviour
{
    [SerializeField]
    private Sprite color_R;
    [SerializeField]
    private Sprite color_B;
    [SerializeField]
    private Sprite color_Y;
    [SerializeField]
    private Sprite tear2_color_R;
    [SerializeField]
    private Sprite tear2_color_B;
    [SerializeField]
    private Sprite tear2_color_Y;

    //색 타입 1: 빨강  2: 파랑  3: 노랑
    public int tear = 1;
    public int nomal_damage = 5;

    public int color_damage = 0;

    public int attack_damage;
    public int maxorb = 1;
    public float attack_chargetime = 3f;

    public int Color_Type;
    public int Color_num = 0;
    public int Color_max;

    private int stock_check = 0;

    public GameObject OB_orb;

    private int orb_count = 0;
    private float x;

    [SerializeField]
    private float ttime = 0;
    private bool timer = false;

    private void Start()
    {
        x = gameObject.transform.position.x;
    }
    private void Update()
    {
        attack_damage = nomal_damage + color_damage;
        Color_max = 30 * tear;

        if (timer == true)
        {
            ttime += Time.deltaTime;
        }
        else ttime = 0;
        if (orb_count < maxorb)
        {
            Charging_orb();
        }

        if (Color_num - stock_check == 3)
        {
            color_damage += 1;
            stock_check = Color_num;
        }
        if (Color_num >= 30 && tear == 1)
        {
            tower_upgrade();
        }
    }

    private void Charging_orb()
    {
        timer = true;
        if (ttime >= attack_chargetime)
        {
            orb_count += 1;
            timer = false;
        }
    }

    public void attack(GameObject monster)
    {
        if (orb_count > 0)
        {
            //방향전환
            if (gameObject.transform.position.x - monster.transform.position.x < 0 && gameObject.transform.localScale.x == 1)
            {
                gameObject.transform.localScale = new Vector3(-1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
                gameObject.transform.position = new Vector3((x + 0.625f), gameObject.transform.position.y, gameObject.transform.position.z);
            }
            else if (gameObject.transform.position.x - monster.transform.position.x >= 0 && gameObject.transform.localScale.x == -1)
            {
                gameObject.transform.localScale = new Vector3(1, gameObject.transform.localScale.y, gameObject.transform.localScale.z);
                gameObject.transform.position = new Vector3(x, gameObject.transform.position.y, gameObject.transform.position.z);
            }
            //
            orb_count -= 1;
            //공격 모션 실행
            // 오브 생성
            GameObject orb = (GameObject)Instantiate(OB_orb, transform.position, Quaternion.identity);
            orb.transform.SetParent(transform);
            orb.GetComponent<wizard_orb>().getposition(monster, attack_damage);
            //
            //체력감소는 몬스터에서
        }
    }

    public void getcolor(int type, int num)
    {
        Color_Type = type;

        if (Color_Type == 2)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = color_R;
        else if (Color_Type == 3)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = color_B;
        else if (Color_Type == 4)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = color_Y;

        if (num > Color_max - Color_num)
        {
            num = Color_max - Color_num;
        }
        Manager.color_less(Color_Type, num);
        Color_num += num;
    }

    public void color_add(int num)
    {
        if (num > Color_max - Color_num)
        {
            num = Color_max - Color_num;
        }
        if (Color_Type == Manager.type_check)
        {
            Manager.color_less(Color_Type, num);
            Color_num += num;
        }
    }

    private void tower_upgrade()
    {
        Color_num = 0;
        tear += 1;
        nomal_damage = 10;
        attack_chargetime = 2f;
        //스프라이트 변경
        if (Color_Type == 2)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = tear2_color_R;
        else if (Color_Type == 3)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = tear2_color_B;
        else if (Color_Type == 4)
            this.gameObject.GetComponent<SpriteRenderer>().sprite = tear2_color_Y;
    }
}