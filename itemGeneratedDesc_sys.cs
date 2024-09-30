using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class itemGeneratedDesc_sys : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] bool isDefault;
    [Space]
    public itemTYPE_im itemType_gr;
    public itemSET_im itemSet_gr;
    public accTYPE_im accType_gr;
    public accSET_im accSet_gr;
    public setTYPE_im setType_gr;
    public int itemLevel_gr;
    [Space]
    public itemSTAT_im itemMain_stat_gr;
    public int itemMain_value_gr;
    public itemSTAT_im itemSub01_stat_gr;
    public int itemSub01_value_gr;
    public itemSTAT_im itemSub02_stat_gr;
    public int itemSub02_value_gr;
    public itemSTAT_im itemSub03_stat_gr;
    public int itemSub03_value_gr;
    public itemSTAT_im itemSub04_stat_gr;
    public int itemSub04_value_gr;


    Inventory_Manager_sys im;

    void Awake()
    {
        im = GameObject.Find("sys").GetComponent<Inventory_Manager_sys>();
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (im.isSelectedPanel == false)
            {
                im.unSelectPanel();
                GameObject _panelSelected = gameObject.transform.GetChild(0).gameObject;
                GameObject _imgBackground = gameObject.transform.GetChild(1).gameObject;
                _panelSelected.SetActive(true);
                _imgBackground.SetActive(false);

                im.createTEMP(gameObject);
                im.displayDescription();

                im.tempSelectedPanel = gameObject;
                im.isSelectedPanel = true;
            }
            else if (im.isSelectedPanel == true && im.tempSelectedPanel != gameObject)
            {
                im.unSelectPanel();
                GameObject _panelSelected = gameObject.transform.GetChild(0).gameObject;
                GameObject _imgBackground = gameObject.transform.GetChild(1).gameObject;
                _panelSelected.SetActive(true);
                _imgBackground.SetActive(false);

                im.createTEMP(gameObject);
                im.displayDescription();

                im.tempSelectedPanel = gameObject;
                im.isSelectedPanel = true;
            }
            else
            {
                //im.emptyTEMP();

                //im.tempSelectedPanel = null;
                //im.isSelectedPanel = false;
                character_status_sys _cha = im.thisCharacter_forInventory.GetComponent<character_status_sys>();

                if (itemType_gr == itemTYPE_im.head) _cha.cha_usedHead_e = gameObject;
                else if (itemType_gr == itemTYPE_im.hand) _cha.cha_usedHand_e = gameObject;
                else if (itemType_gr == itemTYPE_im.body) _cha.cha_usedBody_e = gameObject;
                else if (itemType_gr == itemTYPE_im.feet) _cha.cha_usedFeet_e = gameObject;
                else if (accType_gr == accTYPE_im.sphere) _cha.cha_usedSphere_e = gameObject;
                else if (accType_gr == accTYPE_im.chain) _cha.cha_usedChain_e = gameObject;

                _cha.startCalculatingAllStat();
                im.updateInventoryDisplay_byCharacterCurrentEquipment();
            }
        }
    }
}
