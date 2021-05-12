using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class UI_drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public void OnDrag(PointerEventData eventData)
    {
        Manager.dragsangtea = true;

        if (transform.localScale.z == 1)
        {
            Manager.dreagtower = true;
            Manager.dreagcolor_R = false;
            Manager.dreagcolor_B = false;
            Manager.dreagcolor_Y = false;
        }
        else if (transform.localScale.z == 2)
        {
            Manager.dreagtower = false;
            Manager.dreagcolor_R = true;
            Manager.dreagcolor_B = false;
            Manager.dreagcolor_Y = false;
        }
        else if (transform.localScale.z == 3)
        {
            Manager.dreagtower = false;
            Manager.dreagcolor_R = false;
            Manager.dreagcolor_B = true;
            Manager.dreagcolor_Y = false;
        }
        else if (transform.localScale.z == 4)
        {
            Manager.dreagtower = false;
            Manager.dreagcolor_R = false;
            Manager.dreagcolor_B = false;
            Manager.dreagcolor_Y = true;
        }

        transform.position = eventData.position;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        //_startParent = transform.parent;
        //transform.SetParent(GameObject.FindGameObjectWithTag("UI Canvas").transform);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        //transform.SetParent(_startParent);
        transform.localPosition = Vector3.zero;
        Manager.dragsangtea = false;

        //if (transform.localScale.z == 1)
        //    Manager.dreagtower = false;
        //else if (transform.localScale.z == 2)
        //    Manager.dreagcolor_R = false;
        //else if (transform.localScale.z == 3)
        //    Manager.dreagcolor_B = false;
        //else if (transform.localScale.z == 4)
        //    Manager.dreagcolor_Y = false;
    }
}