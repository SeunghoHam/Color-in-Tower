using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class tower_drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GameObject tower_ui;
    public void OnDrag(PointerEventData eventData)
    {

        transform.position = eventData.position;
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        Instantiate(tower_ui, Vector3.zero, Quaternion.identity);
        //_startParent = transform.parent;
        //transform.SetParent(GameObject.FindGameObjectWithTag("UI_Canvas").transform);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
       // transform.SetParent(_startParent);
        transform.localPosition = Vector3.zero;
    }

    public void OnTriggerStay2D(UnityEngine.Collider2D other)
    {
        if(other.tag == "tower_tile")
        {
            Debug.Log("한별이에휴");
        }
    }
}
