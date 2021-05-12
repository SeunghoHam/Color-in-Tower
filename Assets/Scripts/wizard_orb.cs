using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wizard_orb : MonoBehaviour
{
    public float speed = 3;

    private int damage;
    private bool getPos = false;

    private GameObject target;

    public void getposition(GameObject monster, int _damage)
    {
        target = monster;
        damage = _damage;
        getPos = true;
    }
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
        if (getPos == true)
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, Time.deltaTime * speed);
        if(transform.position == target.transform.position)
        {
            target.GetComponent<eeeaeaaeea>().HPless(damage);
            Destroy(gameObject);

        }
    }
}
