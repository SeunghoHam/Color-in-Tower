using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public float MoveSpeed = 0.03f;
    void Update()
    {
        transform.position += new Vector3(MoveSpeed, 0, 0);
    }
}
