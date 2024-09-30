using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class enemy_status_sys : MonoBehaviour
{
    public string enemy_name;
    public string enemy_longname;
    [TextArea] public string enemy_description;
    public int enemy_id;
    public Sprite enemy_image;
    public string[] enemy_tags;
    public chaTYPE_ch enemy_type;
    public enemyRARITY_en enemy_rarity;
    public int enemy_level;
    [Space]


    public tracesArray_ch[] enemy_tracesArray = new tracesArray_ch[3];
    public insightArray_ch[] enemy_insightArray = new insightArray_ch[3];
    [Space]

    //

    [Space]

    public int enemy_stat_shield;
    public int enemy_stat_shield_start;
    public int enemy_stat_ultimate;
    public int enemy_stat_ultimate_start;
    public int enemy_stat_break;

    public int enemy_stat_ATK;
    public int enemy_stat_DEF;
    public int enemy_stat_HP;
    public int enemy_stat_critRATE;
    public int enemy_stat_critDMG;
    public int enemy_stat_BREAK_bonus;
    public int enemy_stat_FUA_bonus;
    public int enemy_stat_DOT_bonus;
    public int enemy_stat_HEALING_bonus;
    public int enemy_stat_effRESIST;
    public int enemy_stat_effHITRATE;
    public int enemy_stat_energyREGEN;
    public int enemy_stat_LIFESTEAL;
    [Space]

    public string enemy_hitA_name;
    public string enemy_hitA_desc;
    public actionList_ch[] enemy_hitA_action;

    public string enemy_hitB_name;
    public string enemy_hitB_desc;
    public actionList_ch[] enemy_hitB_action;

    public string enemy_hitSkill_name;
    public string enemy_hitSkill_desc;
    public int enemy_hitSkill_cooldown;
    public actionList_ch[] enemy_hitskill_action;

    public string enemy_hitUltimate_name;
    public string enemy_hitUltimate_desc;
    public actionList_ch[] enemy_hitUltimate_action;

    public string enemy_hitPassive_name;
    public string enemy_hitPassive_desc;
    public actionList_ch[] enemy_hitPassive_action;

    void Awake()
    {

    }
}