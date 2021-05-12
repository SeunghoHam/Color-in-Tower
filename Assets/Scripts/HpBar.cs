using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class HpBar : MonoBehaviour
{

    public GameObject hpBarLeft = null;
    public GameObject hpBarMiddle = null;
    public GameObject hpBarRight = null;

    private GameObject Left = null;
    private GameObject Middle = null;
    private GameObject Right = null;

    // 0.5배한 기준
    private float halfLR = 0.0225f;
    private float halfmiddle = 0.045f;

    public float HpPercent = 1.0f;
    // Use this for initialization
    void Start()
    {
        Middle = Instantiate(hpBarMiddle, transform);
        Left = Instantiate(hpBarLeft, transform);
        Right = Instantiate(hpBarRight, transform);

        Middle.transform.localScale = new Vector3(Middle.transform.localScale.x * 6.0f, Middle.transform.localScale.y);
        Middle.transform.position = new Vector3(transform.position.x, transform.position.y + 0.5f);
        Left.transform.position = Middle.transform.position - new Vector3(halfLR + halfmiddle * 6.0f, 0.0f);
        Right.transform.position = Middle.transform.position + new Vector3(halfLR + halfmiddle * 6.0f, 0.0f);
    }

    // Update is called once per frame
    void Update()
    {
        // 프리팹의 스케일을 0.5배 해놨으므로 0.5를 곱해줌. 그리고 6배한것(실제로는 3배)
        Middle.transform.localScale = new Vector3(0.5f * HpPercent * 6.0f, Middle.transform.localScale.y);

        Vector3 MiddlePos = Left.transform.position + new Vector3(halfLR + halfmiddle * 6.0f * HpPercent, 0.0f);
        Middle.transform.position = MiddlePos;

        Vector3 RightPos = Middle.transform.position + new Vector3(halfLR + halfmiddle * 6.0f * HpPercent, 0.0f);
        Right.transform.position = RightPos;
    }
}
