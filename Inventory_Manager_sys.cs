using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using TMPro;
using UnityEditor;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class Inventory_Manager_sys : MonoBehaviour
{
    [SerializeField] private GameObject panel_menu;
    [SerializeField] private GameObject panel_inventory;
    [SerializeField] private GameObject panel_generated;
    [SerializeField] private GameObject panel_generatedItem;
    [SerializeField] private GameObject panel_generatedClose;

    [SerializeField] private GameObject panel_typeHead;
    [SerializeField] private GameObject panel_typeHand;
    [SerializeField] private GameObject panel_typeBody;
    [SerializeField] private GameObject panel_typeFeet;
    [SerializeField] private GameObject panel_typeSphere;
    [SerializeField] private GameObject panel_typeChain;
    [Space]
    [SerializeField] private GameObject itemAutoGen;
    [SerializeField] public GameObject[] setDataBody;
    [SerializeField] public GameObject[] setDataAcc;
    [SerializeField] public Sprite emptySprite;
    [Space]

    // TEMP Data

    public GameObject tempSelectedPanel;
    public bool isSelectedPanel;

    public itemTYPE_im itemType_temp;
    public itemSET_im itemSet_temp;
    public accTYPE_im accType_temp;
    public accSET_im accSet_temp;
    public setTYPE_im setType_temp;
    public int itemLevel_temp;

    public itemSTAT_im itemMain_stat_temp;
    public int itemMain_value_temp;
    public itemSTAT_im itemSub01_stat_temp;
    public int itemSub01_value_temp;
    public itemSTAT_im itemSub02_stat_temp;
    public int itemSub02_value_temp;
    public itemSTAT_im itemSub03_stat_temp;
    public int itemSub03_value_temp;
    public itemSTAT_im itemSub04_stat_temp;
    public int itemSub04_value_temp;
    public Sprite itemSprite_temp;
    [Space]

    // Description Menu

    public TMP_Text desc_itemName;
    public TMP_Text desc_itemLevel;
    public TMP_Text desc_itemMain_stat;
    public TMP_Text desc_itemMain_value;
    public TMP_Text desc_itemSub01_stat;
    public TMP_Text desc_itemSub01_value;
    public TMP_Text desc_itemSub02_stat;
    public TMP_Text desc_itemSub02_value;
    public TMP_Text desc_itemSub03_stat;
    public TMP_Text desc_itemSub03_value;
    public TMP_Text desc_itemSub04_stat;
    public TMP_Text desc_itemSub04_value;
    public TMP_Text desc_setName;
    public TMP_Text desc_setName_2pc;
    public TMP_Text desc_setName_4pc;
    public TMP_Text desc_setDescription;
    [Space]

    // Description Menu
    public GameObject thisCharacter_forInventory;

    public TMP_Text im_stat_ATK;
    public TMP_Text im_stat_DEF;
    public TMP_Text im_stat_HP;
    public TMP_Text im_stat_critRATE;
    public TMP_Text im_stat_critDEMAGE;
    public TMP_Text im_stat_BREAK_bonus;
    public TMP_Text im_stat_FUA_bonus;
    public TMP_Text im_stat_DOT_bonus;
    public TMP_Text im_stat_HEALING_bonus;
    public TMP_Text im_stat_effRESIST;
    public TMP_Text im_stat_effHITRATE;
    public TMP_Text im_stat_energyREGEN;
    public TMP_Text im_stat_LIFESTEAL;

    public GameObject im_positionHead;
    public GameObject im_positionHand;
    public GameObject im_positionBody;
    public GameObject im_positionFeet;
    public GameObject im_positionSphere;
    public GameObject im_positionChain;





















    /// <summary>
    /// 
    /// </summary>
    void Start()
    {
        panel_menu.SetActive(true);
        panel_inventory.SetActive(false);
        panel_generated.SetActive(false);
        panel_typeHead.SetActive(true);
        panel_typeHand.SetActive(false);
        panel_typeBody.SetActive(false);
        panel_typeFeet.SetActive(false);
        panel_typeSphere.SetActive(false);
        panel_typeChain.SetActive(false);

        updateInventoryDisplay_byCharacterCurrentEquipment();
    }

    public void updateInventoryDisplay_byCharacterCurrentEquipment()
    {
        clearThisChild(im_positionHead);
        clearThisChild(im_positionHand);
        clearThisChild(im_positionBody);
        clearThisChild(im_positionFeet);
        clearThisChild(im_positionSphere);
        clearThisChild(im_positionChain);

        character_status_sys _thisCha = thisCharacter_forInventory.GetComponent<character_status_sys>();

        im_stat_ATK.text = _thisCha.cha_stat_ATK.ToString();
        im_stat_DEF.text = _thisCha.cha_stat_DEF.ToString();
        im_stat_HP.text = _thisCha.cha_stat_HP.ToString();
        im_stat_critRATE.text = _thisCha.cha_stat_critRATE.ToString();
        im_stat_critDEMAGE.text = _thisCha.cha_stat_critDMG.ToString();
        im_stat_BREAK_bonus.text = _thisCha.cha_stat_BREAK_bonus.ToString();
        im_stat_FUA_bonus.text = _thisCha.cha_stat_FUA_bonus.ToString();
        im_stat_DOT_bonus.text = _thisCha.cha_stat_DOT_bonus.ToString();
        im_stat_HEALING_bonus.text = _thisCha.cha_stat_HEALING_bonus.ToString();
        im_stat_effRESIST.text = _thisCha.cha_stat_effRESIST.ToString();
        im_stat_effHITRATE.text = _thisCha.cha_stat_effHITRATE.ToString();
        im_stat_energyREGEN.text = _thisCha.cha_stat_energyREGEN.ToString();
        im_stat_LIFESTEAL.text = _thisCha.cha_stat_LIFESTEAL.ToString();

        //

        copyToEquipment(_thisCha.cha_usedHead_e, im_positionHead);
        copyToEquipment(_thisCha.cha_usedHand_e, im_positionHand);
        copyToEquipment(_thisCha.cha_usedBody_e, im_positionBody);
        copyToEquipment(_thisCha.cha_usedFeet_e, im_positionFeet);
        copyToEquipment(_thisCha.cha_usedSphere_e, im_positionSphere);
        copyToEquipment(_thisCha.cha_usedChain_e, im_positionChain);
    }

    /// 
    /// Calling
    /// 
    public void open_menu()
    {
        checkPanel(panel_menu);
        clearThisChild(panel_generatedItem);
    }
    public void open_inventory()
    {
        checkPanel(panel_inventory);
    }
    public void open_generated()
    {
        checkPanel(panel_generated);
        startGenerated();
    }
    public void switchPanelType(GameObject _thisPanel)
    {
        panel_typeHead.SetActive(false);
        panel_typeHand.SetActive(false);
        panel_typeBody.SetActive(false);
        panel_typeFeet.SetActive(false);
        panel_typeSphere.SetActive(false);
        panel_typeChain.SetActive(false);

        _thisPanel.SetActive(true);
    }
    public void unSelectPanel()
    {
        if (tempSelectedPanel != null)
        {
            GameObject _panelSelected = tempSelectedPanel.transform.GetChild(0).gameObject;
            GameObject _imgBackground = tempSelectedPanel.transform.GetChild(1).gameObject;
            _panelSelected.SetActive(false);
            _imgBackground.SetActive(true);
        }
    }

    /// 
    /// System
    /// 
    void clearThisChild(GameObject panel_generated)
    {
        int _num = panel_generated.transform.childCount;
        for (int i = 0; i < _num; i++)
        {
            GameObject _child = panel_generated.transform.GetChild(i).gameObject;
            Destroy(_child);
        }
    }
    void checkPanel(GameObject panelOpen)
    {
        panel_menu.SetActive(false);
        panel_inventory.SetActive(false);
        panel_generated.SetActive(false);

        panelOpen.SetActive(true);
    }
    int getSTAT_value(itemSTAT_im _type)
    {
        if (_type == itemSTAT_im.atk_plus)
        {
            int[] _value = { 50, 60, 70, 80, 90, 100 };
            return _value[UnityEngine.Random.Range(0, _value.Length)];
        }
        else if (_type == itemSTAT_im.atk_mult)
        {
            int[] _value = { 5, 6, 7, 8, 9, 10 };
            return _value[UnityEngine.Random.Range(0, _value.Length)];
        }
        else if (_type == itemSTAT_im.def_plus)
        {
            int[] _value = { 50, 60, 70, 80, 90, 100 };
            return _value[UnityEngine.Random.Range(0, _value.Length)];
        }
        else if (_type == itemSTAT_im.def_mult)
        {
            int[] _value = { 5, 6, 7, 8, 9, 10 };
            return _value[UnityEngine.Random.Range(0, _value.Length)];
        }
        else if (_type == itemSTAT_im.hp_plus)
        {
            int[] _value = { 50, 60, 70, 80, 90, 100 };
            return _value[UnityEngine.Random.Range(0, _value.Length)];
        }
        else if (_type == itemSTAT_im.hp_mult)
        {
            int[] _value = { 5, 6, 7, 8, 9, 10 };
            return _value[UnityEngine.Random.Range(0, _value.Length)];
        }
        else if (_type == itemSTAT_im.crit_rate)
        {
            int[] _value = { 5, 8, 12, 16, 20 };
            return _value[UnityEngine.Random.Range(0, _value.Length)];
        }
        else if (_type == itemSTAT_im.crit_dmg)
        {
            int[] _value = { 5, 8, 12, 16, 20 };
            return _value[UnityEngine.Random.Range(0, _value.Length)];
        }
        else if (_type == itemSTAT_im.break_bonus)
        {
            int[] _value = { 5, 8, 12, 16, 20 };
            return _value[UnityEngine.Random.Range(0, _value.Length)];
        }
        else if (_type == itemSTAT_im.dot_bonus)
        {
            int[] _value = { 5, 8, 12, 16, 20 };
            return _value[UnityEngine.Random.Range(0, _value.Length)];
        }
        else if (_type == itemSTAT_im.fua_bonus)
        {
            int[] _value = { 5, 8, 12, 16, 20 };
            return _value[UnityEngine.Random.Range(0, _value.Length)];
        }
        else if (_type == itemSTAT_im.healing_bonus)
        {
            int[] _value = { 5, 8, 12, 16, 20 };
            return _value[UnityEngine.Random.Range(0, _value.Length)];
        }
        else if (_type == itemSTAT_im.effect_res)
        {
            int[] _value = { 5, 8, 12, 16, 20 };
            return _value[UnityEngine.Random.Range(0, _value.Length)];
        }
        else if (_type == itemSTAT_im.effect_hitrate)
        {
            int[] _value = { 5, 8, 12, 16, 20 };
            return _value[UnityEngine.Random.Range(0, _value.Length)];
        }
        else if (_type == itemSTAT_im.energy_regenrate)
        {
            int[] _value = { 5, 6, 7, 8, 9, 10 };
            return _value[UnityEngine.Random.Range(0, _value.Length)];
        }
        else if (_type == itemSTAT_im.lifesteal)
        {
            int[] _value = { 5, 6, 7, 8, 9, 10 };
            return _value[UnityEngine.Random.Range(0, _value.Length)];
        }
        else
        {
            return 0;
        }
    }
    Sprite getSpriteMore(setData_sys setData_sys, itemTYPE_im itemType, accTYPE_im accType)
    {
        if (itemType == itemTYPE_im.head) return setData_sys.headSprite_dc;
        else if (itemType == itemTYPE_im.hand) return setData_sys.handSprite_dc;
        else if (itemType == itemTYPE_im.body) return setData_sys.bodySprite_dc;
        else if (itemType == itemTYPE_im.feet) return setData_sys.feetSprite_dc;
        else if (accType == accTYPE_im.sphere) return setData_sys.sphereSprite_dc;
        else if (accType == accTYPE_im.chain) return setData_sys.chainSprite_dc;
        else return emptySprite;
    }
    public Sprite getSprite(itemTYPE_im itemType, itemSET_im itemSet, accTYPE_im accType, accSET_im accSet, setTYPE_im setType)
    {
        if (setType == setTYPE_im.setBody)
        {
            GameObject _setData = Instantiate(setDataBody[(int)itemSet-1]);
            setData_sys _setData_sys = _setData.GetComponent<setData_sys>();
            Sprite _sprite = getSpriteMore(_setData_sys, itemType, accType);
            Destroy(_setData);
            return _sprite;
        }
        else if (setType == setTYPE_im.setAcc)
        {
            GameObject _setData = Instantiate(setDataAcc[(int)accSet-1]);
            setData_sys _setData_sys = _setData.GetComponent<setData_sys>();
            Sprite _sprite = getSpriteMore(_setData_sys, itemType, accType);
            Destroy(_setData);
            return _sprite;
        }
        return emptySprite;
    }
    static T GetRandomEnum<T>(int _num)
    {
        System.Array A = System.Enum.GetValues(typeof(T));
        T V = (T)A.GetValue(UnityEngine.Random.Range(_num, A.Length));
        return V;
    }
    public void startGenerated()
    {
        int randomAutoGen = UnityEngine.Random.Range(1, 5);
        for (int i = 0; i < randomAutoGen; i++)
        {
            GameObject autoGen = Instantiate(itemAutoGen, panel_generatedItem.transform);
            itemGeneratedDesc_sys autoGen_sys = autoGen.GetComponent<itemGeneratedDesc_sys>();
            GameObject autoGen_imgData = autoGen.transform.GetChild(2).gameObject;
            Image autoGen_img = autoGen_imgData.GetComponent<Image>();

            // Find Type
            int _random12 = UnityEngine.Random.Range(1, 3);
            if (_random12 == 1)
            {
                itemTYPE_im itemType = GetRandomEnum<itemTYPE_im>(1);
                itemSET_im itemSet = GetRandomEnum<itemSET_im>(1);
                autoGen_sys.itemType_gr = itemType;
                autoGen_sys.itemSet_gr = itemSet;
                autoGen_sys.setType_gr = setTYPE_im.setBody;
            }
            else if (_random12 == 2)
            {
                accTYPE_im accType = GetRandomEnum<accTYPE_im>(1);
                accSET_im accSet = GetRandomEnum<accSET_im>(1);
                autoGen_sys.accType_gr = accType;
                autoGen_sys.accSet_gr = accSet;
                autoGen_sys.setType_gr = setTYPE_im.setAcc;
            }
            itemTYPE_im _itemType = autoGen_sys.itemType_gr;
            itemSET_im _itemSet = autoGen_sys.itemSet_gr;
            accTYPE_im _accType = autoGen_sys.accType_gr;
            accSET_im _accSet = autoGen_sys.accSet_gr;
            setTYPE_im _setType = autoGen_sys.setType_gr;

            itemSTAT_im _itemSTAT_main = GetRandomEnum<itemSTAT_im>(1);
            itemSTAT_im _itemSTAT_sub01 = GetRandomEnum<itemSTAT_im>(1);
            itemSTAT_im _itemSTAT_sub02 = GetRandomEnum<itemSTAT_im>(1);
            itemSTAT_im _itemSTAT_sub03 = GetRandomEnum<itemSTAT_im>(1);
            itemSTAT_im _itemSTAT_sub04 = GetRandomEnum<itemSTAT_im>(1);
            int _itemV_main = getSTAT_value(_itemSTAT_main);
            int _itemV_sub01 = getSTAT_value(_itemSTAT_sub01);
            int _itemV_sub02 = getSTAT_value(_itemSTAT_sub02);
            int _itemV_sub03 = getSTAT_value(_itemSTAT_sub03);
            int _itemV_sub04 = getSTAT_value(_itemSTAT_sub04);

            autoGen_sys.itemMain_stat_gr = _itemSTAT_main;
            autoGen_sys.itemSub01_stat_gr = _itemSTAT_sub01;
            autoGen_sys.itemSub02_stat_gr = _itemSTAT_sub02;
            autoGen_sys.itemSub03_stat_gr = _itemSTAT_sub03;
            autoGen_sys.itemSub04_stat_gr = _itemSTAT_sub04;
            autoGen_sys.itemMain_value_gr = _itemV_main;
            autoGen_sys.itemSub01_value_gr = _itemV_sub01;
            autoGen_sys.itemSub02_value_gr = _itemV_sub02;
            autoGen_sys.itemSub03_value_gr = _itemV_sub03;
            autoGen_sys.itemSub04_value_gr = _itemV_sub04;

            Sprite _sprite = getSprite(_itemType, _itemSet, _accType, _accSet, _setType);
            autoGen_img.sprite = _sprite;

            copyToInventory(_itemType, _itemSet, _accType, _accSet, _setType, _itemSTAT_main, _itemSTAT_sub01, _itemSTAT_sub02, _itemSTAT_sub03, _itemSTAT_sub04, _itemV_main, _itemV_sub01, _itemV_sub02, _itemV_sub03, _itemV_sub04, _sprite);
        }
    }
    void copyToInventory(itemTYPE_im _itemType, itemSET_im _itemSet, accTYPE_im _accType, accSET_im _accSet, setTYPE_im _setType, itemSTAT_im _itemSTAT_main, itemSTAT_im _itemSTAT_sub01, itemSTAT_im _itemSTAT_sub02, itemSTAT_im _itemSTAT_sub03, itemSTAT_im _itemSTAT_sub04, int _itemV_main, int _itemV_sub01, int _itemV_sub02, int _itemV_sub03, int _itemV_sub04, Sprite _sprite)
    {
        GameObject _newItem = Instantiate(itemAutoGen);
        itemGeneratedDesc_sys _newItem_sys = _newItem.GetComponent<itemGeneratedDesc_sys>();
        GameObject _newItem_imgData = _newItem.transform.GetChild(2).gameObject;
        Image _newItem_img = _newItem_imgData.GetComponent<Image>();

        // _newItem.transform.parent = panel_typeHand.transform   // begitu juga bisa
        if (_itemType == itemTYPE_im.head) _newItem.transform.SetParent(panel_typeHead.transform, false);
        else if (_itemType == itemTYPE_im.hand) _newItem.transform.SetParent(panel_typeHand.transform, false);
        else if (_itemType == itemTYPE_im.body) _newItem.transform.SetParent(panel_typeBody.transform, false);
        else if (_itemType == itemTYPE_im.feet) _newItem.transform.SetParent(panel_typeFeet.transform, false);
        else if (_accType == accTYPE_im.sphere) _newItem.transform.SetParent(panel_typeSphere.transform, false);
        else if (_accType == accTYPE_im.chain) _newItem.transform.SetParent(panel_typeChain.transform, false);

        _newItem_sys.itemType_gr = _itemType;
        _newItem_sys.itemSet_gr = _itemSet;
        _newItem_sys.accType_gr = _accType;
        _newItem_sys.accSet_gr = _accSet;
        _newItem_sys.setType_gr = _setType;
        _newItem_sys.itemMain_stat_gr = _itemSTAT_main;
        _newItem_sys.itemSub01_stat_gr = _itemSTAT_sub01;
        _newItem_sys.itemSub02_stat_gr = _itemSTAT_sub02;
        _newItem_sys.itemSub03_stat_gr = _itemSTAT_sub03;
        _newItem_sys.itemSub04_stat_gr = _itemSTAT_sub04;
        _newItem_sys.itemMain_value_gr = _itemV_main;
        _newItem_sys.itemSub01_value_gr = _itemV_sub01;
        _newItem_sys.itemSub02_value_gr = _itemV_sub02;
        _newItem_sys.itemSub03_value_gr = _itemV_sub03;
        _newItem_sys.itemSub04_value_gr = _itemV_sub04;
        _newItem_img.sprite = _sprite;
    }
    void copyToEquipment(GameObject _thisItem, GameObject _copyHere)
    {
        itemGeneratedDesc_sys _sourceData = _thisItem.GetComponent<itemGeneratedDesc_sys>();
        GameObject _sourceData_imgData = _thisItem.transform.GetChild(2).gameObject;
        Image _sourceData_img = _sourceData_imgData.GetComponent<Image>();

        itemTYPE_im _itemType = _sourceData.itemType_gr;
        itemSET_im _itemSet = _sourceData.itemSet_gr;
        accTYPE_im _accType = _sourceData.accType_gr;
        accSET_im _accSet = _sourceData.accSet_gr;
        setTYPE_im _setType = _sourceData.setType_gr;
        itemSTAT_im _itemSTAT_main = _sourceData.itemMain_stat_gr;
        itemSTAT_im _itemSTAT_sub01 = _sourceData.itemSub01_stat_gr;
        itemSTAT_im _itemSTAT_sub02 = _sourceData.itemSub02_stat_gr;
        itemSTAT_im _itemSTAT_sub03 = _sourceData.itemSub03_stat_gr;
        itemSTAT_im _itemSTAT_sub04 = _sourceData.itemSub04_stat_gr;
        int _itemV_main = _sourceData.itemMain_value_gr;
        int _itemV_sub01 = _sourceData.itemSub01_value_gr;
        int _itemV_sub02 = _sourceData.itemSub02_value_gr;
        int _itemV_sub03 = _sourceData.itemSub03_value_gr;
        int _itemV_sub04 = _sourceData.itemSub04_value_gr;
        Sprite _sprite = getSprite(_itemType, _itemSet, _accType, _accSet, _setType);

        GameObject _newItem = Instantiate(itemAutoGen);
        itemGeneratedDesc_sys _newItem_sys = _newItem.GetComponent<itemGeneratedDesc_sys>();
        GameObject _newItem_imgData = _newItem.transform.GetChild(2).gameObject;
        Image _newItem_img = _newItem_imgData.GetComponent<Image>();

        _newItem.transform.SetParent(_copyHere.transform, false);
        //_newItem.transform.position = new Vector3(0, 0, 0);

        _newItem_sys.itemType_gr = _itemType;
        _newItem_sys.itemSet_gr = _itemSet;
        _newItem_sys.accType_gr = _accType;
        _newItem_sys.accSet_gr = _accSet;
        _newItem_sys.setType_gr = _setType;
        _newItem_sys.itemMain_stat_gr = _itemSTAT_main;
        _newItem_sys.itemSub01_stat_gr = _itemSTAT_sub01;
        _newItem_sys.itemSub02_stat_gr = _itemSTAT_sub02;
        _newItem_sys.itemSub03_stat_gr = _itemSTAT_sub03;
        _newItem_sys.itemSub04_stat_gr = _itemSTAT_sub04;
        _newItem_sys.itemMain_value_gr = _itemV_main;
        _newItem_sys.itemSub01_value_gr = _itemV_sub01;
        _newItem_sys.itemSub02_value_gr = _itemV_sub02;
        _newItem_sys.itemSub03_value_gr = _itemV_sub03;
        _newItem_sys.itemSub04_value_gr = _itemV_sub04;
        _newItem_img.sprite = _sprite;
    }

    /// <summary>
    /// 
    /// </summary>

    public void displayDescription()
    {
        void setTheData(itemTYPE_im itemType, itemSET_im itemSet, accTYPE_im accType, accSET_im accSet, setTYPE_im setType)
        {
            if (setType == setTYPE_im.setBody)
            {
                GameObject _setData = Instantiate(setDataBody[(int)itemSet - 1]);
                setData_sys _setData_sys = _setData.GetComponent<setData_sys>();
                string _itemName = findNameByType(_setData_sys, itemType, accType);
                setTheDataMore(_setData_sys, _itemName);
                Destroy(_setData);
            }
            else if (setType == setTYPE_im.setAcc)
            {
                GameObject _setData = Instantiate(setDataAcc[(int)accSet - 1]);
                setData_sys _setData_sys = _setData.GetComponent<setData_sys>();
                string _itemName = findNameByType(_setData_sys, itemType, accType);
                setTheDataMore(_setData_sys, _itemName);
                Destroy(_setData);
            }
        }
        string findNameByType(setData_sys _object, itemTYPE_im itemType, accTYPE_im accType)
        {
            if (itemType == itemTYPE_im.head)
            {
                string _name = _object.headName_dc;
                return _name;
            }
            else if (itemType == itemTYPE_im.hand)
            {
                string _name = _object.handName_dc;
                return _name;
            }
            else if (itemType == itemTYPE_im.body)
            {
                string _name = _object.bodyName_dc;
                return _name;
            }
            else if (itemType == itemTYPE_im.feet)
            {
                string _name = _object.feetName_dc;
                return _name;
            }
            else if (accType == accTYPE_im.sphere)
            {
                string _name = _object.sphereName_dc;
                return _name;
            }
            else if (accType == accTYPE_im.chain)
            {
                string _name = _object.chainName_dc;
                return _name;
            }
            else
            {
                string _name = "_error";
                return _name;
            }
        }
        void setTheDataMore(setData_sys _this, string _itemName)
        {
            desc_itemName.text = _itemName;
            desc_setName.text = _this.setName_dc;
            desc_setName_2pc.text = _this.set2pc_dc;
            desc_setName_4pc.text = _this.set4pc_dc;
            desc_setDescription.text = _this.setDesc_dc;
        }

        setTheData(itemType_temp, itemSet_temp, accType_temp, accSet_temp, setType_temp);

        //desc_itemName.text =
        desc_itemLevel.text = itemLevel_temp.ToString();
        desc_itemMain_stat.text = itemMain_stat_temp.ToString();
        desc_itemMain_value.text = itemMain_value_temp.ToString();
        desc_itemSub01_stat.text = itemSub01_stat_temp.ToString();
        desc_itemSub02_stat.text = itemSub02_stat_temp.ToString();
        desc_itemSub03_stat.text = itemSub03_stat_temp.ToString();
        desc_itemSub04_stat.text = itemSub04_stat_temp.ToString();
        desc_itemSub01_value.text = itemSub01_value_temp.ToString();
        desc_itemSub02_value.text = itemSub02_value_temp.ToString();
        desc_itemSub03_value.text = itemSub03_value_temp.ToString();
        desc_itemSub04_value.text = itemSub04_value_temp.ToString();
        //desc_setName.text =
        //desc_setName_2pc.text =
        //desc_setName_4pc.text =
        //desc_setDescription.text =
    }
    public void createTEMP(GameObject _this)
    {
        itemGeneratedDesc_sys _ig = _this.GetComponent<itemGeneratedDesc_sys>();

        Sprite _sprite = getSprite(_ig.itemType_gr, _ig.itemSet_gr, _ig.accType_gr, _ig.accSet_gr, _ig.setType_gr);

        transferDataToTemp(_ig.itemType_gr, _ig.itemSet_gr, _ig.accType_gr, _ig.accSet_gr, _ig.setType_gr, _ig.itemLevel_gr, _ig.itemMain_stat_gr, _ig.itemSub01_stat_gr, _ig.itemSub02_stat_gr, _ig.itemSub03_stat_gr, _ig.itemSub04_stat_gr, _ig.itemMain_value_gr, _ig.itemSub01_value_gr, _ig.itemSub02_value_gr, _ig.itemSub03_value_gr, _ig.itemSub04_value_gr, _sprite);
    }
    void transferDataToTemp(itemTYPE_im _itemType, itemSET_im _itemSet, accTYPE_im _accType, accSET_im _accSet, setTYPE_im _setType, int _itemLevel, itemSTAT_im _itemSTAT_main, itemSTAT_im _itemSTAT_sub01, itemSTAT_im _itemSTAT_sub02, itemSTAT_im _itemSTAT_sub03, itemSTAT_im _itemSTAT_sub04, int _itemV_main, int _itemV_sub01, int _itemV_sub02, int _itemV_sub03, int _itemV_sub04, Sprite _sprite)
    {
        itemType_temp = _itemType;
        itemSet_temp = _itemSet;
        accType_temp = _accType;
        accSet_temp = _accSet;
        setType_temp = _setType;
        itemLevel_temp = _itemLevel;
        itemMain_stat_temp = _itemSTAT_main;
        itemSub01_stat_temp = _itemSTAT_sub01;
        itemSub02_stat_temp = _itemSTAT_sub02;
        itemSub03_stat_temp = _itemSTAT_sub03;
        itemSub04_stat_temp = _itemSTAT_sub04;
        itemMain_value_temp = _itemV_main;
        itemSub01_value_temp = _itemV_sub01;
        itemSub02_value_temp = _itemV_sub02;
        itemSub03_value_temp = _itemV_sub03;
        itemSub04_value_temp = _itemV_sub04;
        itemSprite_temp = _sprite;
    }
    void emptyTEMP()
    {
        itemType_temp = itemTYPE_im.none;
        itemSet_temp = itemSET_im.none;
        accType_temp = accTYPE_im.none;
        accSet_temp = accSET_im.none;
        setType_temp = setTYPE_im.none;
        itemLevel_temp = 0;
        itemMain_stat_temp = itemSTAT_im.none;
        itemSub01_stat_temp = itemSTAT_im.none;
        itemSub02_stat_temp = itemSTAT_im.none;
        itemSub03_stat_temp = itemSTAT_im.none;
        itemSub04_stat_temp = itemSTAT_im.none;
        itemMain_value_temp = 0;
        itemSub01_value_temp = 0;
        itemSub02_value_temp = 0;
        itemSub03_value_temp = 0;
        itemSub04_value_temp = 0;
        itemSprite_temp = emptySprite;
    }
}

public enum itemTYPE_im {none, head, hand, body, feet};
public enum itemSET_im {none, setBody_01, setBody_02};
public enum accTYPE_im {none, sphere, chain};
public enum accSET_im {none, setAcc_01, setAcc_02};
public enum setTYPE_im {none, setBody, setAcc};
public enum itemSTAT_im
{
    none,
    atk_plus,
    atk_mult,
    def_plus,
    def_mult,
    hp_plus,
    hp_mult,
    crit_rate,
    crit_dmg,
    break_bonus,
    dot_bonus,
    fua_bonus,
    healing_bonus,
    effect_res,
    effect_hitrate,
    energy_regenrate,
    lifesteal
};

//// for learn later
//public enum MyEnum
//{
//    MyValue1 = 34,
//    MyValue2 = 27
//}

//(int)MyEnum.MyValue2 == 27; // True