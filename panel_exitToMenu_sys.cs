using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class panel_exitToMenu_sys : MonoBehaviour, IPointerClickHandler
{
    Inventory_Manager_sys im;
    void Awake()
    {
        im = GameObject.Find("sys").GetComponent<Inventory_Manager_sys>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            im.open_menu();
        }
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            im.open_menu();
        }
    }
}
