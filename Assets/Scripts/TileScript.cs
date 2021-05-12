using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileScript : MonoBehaviour
{
    public Point GridPosition { get; private set; }
    public Vector2 WorldPosition
    {
        get
        {
            return new Vector2(transform.position.x + (GetComponent<SpriteRenderer>().bounds.size.x),
                transform.position.y - (GetComponent<SpriteRenderer>().bounds.size.y));
        }
    }
    public Vector2 WorldPosition2
    {
        get
        {
            return new Vector2(transform.position.x + (GetComponent<SpriteRenderer>().bounds.size.x / 2),
                transform.position.y - (GetComponent<SpriteRenderer>().bounds.size.y / 2));
        }
    }
    [SerializeField]
    private bool have_tower = false;

    [SerializeField]
    private bool have_color = false;

    public void Setup(Point gridpos, Vector3 worldpos)
    {
        this.GridPosition = gridpos;
        transform.position = worldpos;

        LevelManager.Instance.Tiles.Add(gridpos, this);

    }

    private void OnMouseOver()
    {
        if (Manager.dragsangtea == true)
        {
            if (Input.GetMouseButtonUp(0))
            {
                if (this.gameObject.tag == "tower_tile")
                {
                    if (have_tower == false)
                    {
                        if (Manager.dreagtower == true)
                        {
                            if (Manager.money >= 80)
                            {
                                Manager.money -= 80;
                                placetower();
                            }
                        }
                    }
                    else if (have_tower == true)
                    {
                        if (Manager.dreagcolor_R == true)
                        {
                            if (Manager.color_R >= Manager.color_number && Manager.color_R > 0)
                            {
                                if (have_color == false)
                                {
                                    this.gameObject.transform.GetChild(0).gameObject.GetComponent<Tower_wizard>().getcolor(2, Manager.color_number);
                                    have_color = true;
                                }
                                else if (have_color == true)
                                    this.gameObject.transform.GetChild(0).gameObject.GetComponent<Tower_wizard>().color_add(Manager.color_number);
                            }
                        }
                        else if (Manager.dreagcolor_B == true)
                        {
                            if (Manager.color_B >= Manager.color_number && Manager.color_B > 0)
                            {
                                if (have_color == false)
                                {
                                    this.gameObject.transform.GetChild(0).gameObject.GetComponent<Tower_wizard>().getcolor(3, Manager.color_number);
                                    have_color = true;
                                }
                                else if (have_color == true)
                                    this.gameObject.transform.GetChild(0).gameObject.GetComponent<Tower_wizard>().color_add(Manager.color_number);
                            }
                        }
                        else if (Manager.dreagcolor_Y == true)
                        {
                            if (Manager.color_Y >= Manager.color_number && Manager.color_Y > 0)
                            {
                                if (have_color == false)
                                {
                                    this.gameObject.transform.GetChild(0).gameObject.GetComponent<Tower_wizard>().getcolor(4, Manager.color_number);
                                    have_color = true;
                                }
                                else if (have_color == true)
                                    this.gameObject.transform.GetChild(0).gameObject.GetComponent<Tower_wizard>().color_add(Manager.color_number);
                            }
                        }
                    }
                }
            }
        }
    }
    private void placetower()
    {
        have_tower = true;
        GameObject tower = (GameObject)Instantiate(Manager.Instance.TowerPrefab, transform.position, Quaternion.identity);
        tower.GetComponent<SpriteRenderer>().sortingOrder = GridPosition.Y;

        tower.transform.SetParent(transform);
    }
}