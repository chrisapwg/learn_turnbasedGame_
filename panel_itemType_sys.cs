using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class panel_itemType_sys : MonoBehaviour, IPointerClickHandler
{
    Inventory_Manager_sys im;
    [SerializeField] GameObject myPanel;
    void Awake()
    {
        im = GameObject.Find("sys").GetComponent<Inventory_Manager_sys>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            im.switchPanelType(myPanel);
        }
    }
}
