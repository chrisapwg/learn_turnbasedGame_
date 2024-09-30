using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using static character_status_sys;

public class character_status_sys : MonoBehaviour
{
    public string cha_name;
    public string cha_longname;
    [TextArea] public string cha_description;
    public int cha_id;
    public Sprite cha_image;
    public string[] cha_tags;
    public chaTYPE_ch cha_type;
    public int cha_level;
    public int cha_hateStatus;
    public int cha_friendStatus;
    public int cha_romanceStatus;
    [Space]

    public tracesArray_ch[] cha_tracesArray = new tracesArray_ch[3];
    public insightArray_ch[] cha_insightArray = new insightArray_ch[3];
    public eidolonArray_ch[] cha_eidolonArray = new eidolonArray_ch[6];
    [Space]

    public GameObject cha_usedLightcone_e;
    public GameObject cha_usedHead_e;
    public GameObject cha_usedHand_e;
    public GameObject cha_usedBody_e;
    public GameObject cha_usedFeet_e;
    public GameObject cha_usedSphere_e;
    public GameObject cha_usedChain_e;

    public bool cha_setBody2pc_status;
    public bool cha_setBody4pc_status;
    public bool cha_setAcc2pc_status;
    [Space]

    [SerializeField] private int base_stat_shield;
    [SerializeField] private int base_stat_shield_start;
    [SerializeField] private int base_stat_ultimate;
    [SerializeField] private int base_stat_ultimate_start;
    [SerializeField] private int base_stat_break;

    [SerializeField] private int base_stat_ATK;
    [SerializeField] private int base_stat_DEF;
    [SerializeField] private int base_stat_HP;
    [SerializeField] private int base_stat_critRATE;
    [SerializeField] private int base_stat_critDMG;
    [SerializeField] private int base_stat_BREAK_bonus;
    [SerializeField] private int base_stat_FUA_bonus;
    [SerializeField] private int base_stat_DOT_bonus;
    [SerializeField] private int base_stat_HEALING_bonus;
    [SerializeField] private int base_stat_effRESIST;
    [SerializeField] private int base_stat_effHITRATE;
    [SerializeField] private int base_stat_energyREGEN;
    [SerializeField] private int base_stat_LIFESTEAL;
    [Space]


    public int cha_stat_shield;
    public int cha_stat_shield_start;
    public int cha_stat_ultimate;
    public int cha_stat_ultimate_start;
    public int cha_stat_break;

    public int cha_stat_ATK;
    public int cha_stat_DEF;
    public int cha_stat_HP;
    public int cha_stat_critRATE;
    public int cha_stat_critDMG;
    public int cha_stat_BREAK_bonus;
    public int cha_stat_FUA_bonus;
    public int cha_stat_DOT_bonus;
    public int cha_stat_HEALING_bonus;
    public int cha_stat_effRESIST;
    public int cha_stat_effHITRATE;
    public int cha_stat_energyREGEN;
    public int cha_stat_LIFESTEAL;
    [Space]

    public string cha_hitA_name;
    public string cha_hitA_desc;
    public actionList_ch[] cha_hitA_action;

    public string cha_hitB_name;
    public string cha_hitB_desc;
    public actionList_ch[] cha_hitB_action;

    public string cha_hitSkill_name;
    public string cha_hitSkill_desc;
    public int cha_hitSkill_cooldown;
    public actionList_ch[] cha_hitSkill_action;

    public string cha_hitUltimate_name;
    public string cha_hitUltimate_desc;
    public actionList_ch[] cha_hitUltimate_action;

    public string cha_hitPassive_name;
    public string cha_hitPassive_desc;
    public actionList_ch[] cha_hitPassive_action;
    [Space]

    [HideInInspector] public whatSCENE cha_whatScene;
    [HideInInspector] public GameObject cha_sceneSystem;

    private void Awake()
    {
        startCalculatingAllStat();
    }
    public void startCalculatingAllStat()
    {
        int doNot0(int _this)
        {
            if (_this == 0) return 1;
            else return _this;
        }

        int _sum_ATK = findThisStatFromScript(itemSTAT_im.atk_plus);
        int _sum_ATK_mult = findThisStatFromScript(itemSTAT_im.atk_mult);
        int _sum_DEF = findThisStatFromScript(itemSTAT_im.def_plus);
        int _sum_DEF_mult = findThisStatFromScript(itemSTAT_im.def_mult);
        int _sum_HP = findThisStatFromScript(itemSTAT_im.hp_plus);
        int _sum_HP_mult = findThisStatFromScript(itemSTAT_im.hp_mult);
        int _sum_critRATE = findThisStatFromScript(itemSTAT_im.crit_rate);
        int _sum_critDMG = findThisStatFromScript(itemSTAT_im.crit_dmg);
        int _sum_BREAK_bonus = findThisStatFromScript(itemSTAT_im.break_bonus);
        int _sum_FUA_bonus = findThisStatFromScript(itemSTAT_im.fua_bonus);
        int _sum_DOT_bonus = findThisStatFromScript(itemSTAT_im.dot_bonus);
        int _sum_HEALING_bonus = findThisStatFromScript(itemSTAT_im.healing_bonus);
        int _sum_effRESIST = findThisStatFromScript(itemSTAT_im.effect_res);
        int _sum_effHITRATE = findThisStatFromScript(itemSTAT_im.effect_hitrate);
        int _sum_energyREGEN = findThisStatFromScript(itemSTAT_im.energy_regenrate);
        int _sum_LIFESTEAL = findThisStatFromScript(itemSTAT_im.lifesteal);

        cha_stat_shield = base_stat_shield;
        cha_stat_shield_start = base_stat_shield_start;
        cha_stat_ultimate = base_stat_ultimate;
        cha_stat_ultimate_start = base_stat_ultimate_start;
        cha_stat_break = base_stat_break;

        cha_stat_ATK = (base_stat_ATK + _sum_ATK) * doNot0(_sum_ATK_mult);
        cha_stat_DEF = (base_stat_DEF + _sum_DEF) * doNot0(_sum_DEF_mult);
        cha_stat_HP = (base_stat_HP + _sum_HP) * doNot0(_sum_HP_mult);
        cha_stat_critRATE = base_stat_critRATE + _sum_critRATE;
        cha_stat_critDMG = base_stat_critDMG + _sum_critDMG;
        cha_stat_BREAK_bonus = base_stat_BREAK_bonus + _sum_BREAK_bonus;
        cha_stat_FUA_bonus = base_stat_FUA_bonus + _sum_FUA_bonus;
        cha_stat_DOT_bonus = base_stat_DOT_bonus + _sum_DOT_bonus;
        cha_stat_HEALING_bonus = base_stat_HEALING_bonus + _sum_HEALING_bonus;
        cha_stat_effRESIST = base_stat_effRESIST + _sum_effRESIST;
        cha_stat_effHITRATE = base_stat_effHITRATE + _sum_effHITRATE;
        cha_stat_energyREGEN = base_stat_energyREGEN + _sum_energyREGEN;
        cha_stat_LIFESTEAL = base_stat_LIFESTEAL + _sum_LIFESTEAL;
    }
    int findThisStatFromScript(itemSTAT_im _findThis)
    {

        int findFrom_itemSTAT(itemSTAT_im _data, itemSTAT_im _pleaseFindThis, int _value)
        {
            if (_data == _pleaseFindThis) return _value;
            else return 0;
        }

        int findFrom_itemTYPE(GameObject _thisType)
        {
            if (_thisType != null)
            {
                itemGeneratedDesc_sys _data = _thisType.GetComponent<itemGeneratedDesc_sys>();

                int _find_main = findFrom_itemSTAT(_data.itemMain_stat_gr, _findThis, _data.itemMain_value_gr);
                int _find_sub01 = findFrom_itemSTAT(_data.itemSub01_stat_gr, _findThis, _data.itemSub01_value_gr);
                int _find_sub02 = findFrom_itemSTAT(_data.itemSub02_stat_gr, _findThis, _data.itemSub02_value_gr);
                int _find_sub03 = findFrom_itemSTAT(_data.itemSub03_stat_gr, _findThis, _data.itemSub03_value_gr);
                int _find_sub04 = findFrom_itemSTAT(_data.itemSub04_stat_gr, _findThis, _data.itemSub04_value_gr);

                int _sum = _find_main + _find_sub01 + _find_sub02 + _find_sub03 + _find_sub04;

                return _sum;
            }
            else
            { 
                return 0;
            }
        }

        int _sumLightcone = findFrom_itemTYPE(cha_usedLightcone_e);
        int _sumHead = findFrom_itemTYPE(cha_usedHead_e);
        int _sumHand = findFrom_itemTYPE(cha_usedHand_e);
        int _sumBody = findFrom_itemTYPE(cha_usedBody_e);
        int _sumFeet = findFrom_itemTYPE(cha_usedFeet_e);
        int _sumSphere = findFrom_itemTYPE(cha_usedSphere_e);
        int _sumChain = findFrom_itemTYPE(cha_usedChain_e);

        int _sum = _sumLightcone + _sumHead + _sumHand + _sumBody + _sumFeet + _sumSphere + _sumChain;

        return _sum;
    }
}

public enum chaTYPE_ch { none, attacker, support, tank };
public enum chaEIDOLON_ch { none, eidolon01, eidolon02, eidolon03, eidolon04, eidolon05, eidolon06 };
public enum chaINSIGHT_ch { none, insight01, insight02, insight03 };
public enum actionTYPE_ch { none, _attack, _heal, _buff, _debuff, _dot, _fua, _break };
public enum actionTARGET_ch { none, _single, _blast, _aoe, _randomSINGLE, _randomAOE };
public enum actionFIELD_ch { none, enemy_shield, enemy_health, enemy_break, enemy_buffDebuff, player_shield, player_health, player_break, player_buffDebuff };
public enum hitTYPE_ch { none, hitA, hitB, skill, ultimate };
public enum listBUFF_ch { none };
public enum listDEBUFF_ch { none };
public enum whatSCENE { none, story, inventory, battle };



[Serializable]
public struct tracesArray_ch
{
    //public string traces;
    public bool traces_status;
    public string traces_name;
    [TextArea] public string traces_desc;
}
[Serializable]
public struct insightArray_ch
{
    public chaINSIGHT_ch insight;
    public bool insight_status;
    public string insight_name;
    [TextArea] public string insight_desc;
}
[Serializable]
public struct eidolonArray_ch
{
    public chaEIDOLON_ch eidolon;
    public bool eidolon_status;
    public string eidolon_name;
    [TextArea] public string eidolon_desc;
}
[Serializable]
public struct actionList_ch
{
    public actionTYPE_ch actionType;
    public actionTARGET_ch actionTarget;
    public actionFIELD_ch actionField;
    public listBUFF_ch actionBuff;
    public listDEBUFF_ch actionDebuff;
    public float actionValue;
    public float chargeUltimate;
}