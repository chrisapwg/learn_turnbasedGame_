using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class enemy_sys : MonoBehaviour
{
    public GameObject opp_thisCharacter;
    public enemyINDEX_en opp_index;
    public enemyRARITY_en enemy_rarity;
    public bool opp_aliveStatus;
    [Space]
    public GameObject opp_selection;
    public bool opp_selected;
    public GameObject opp_images;

    public Slider opp_shield_slider;
    public Slider opp_health_slider;
    public Slider opp_break_slider;
    public Slider opp_ultimate_slider;
    public GameObject opp_buffDebuff_panel;
    public Image opp_demageImages;
    public TMP_Text opp_demageText;

    /// <summary>
    /// 
    /// </summary>

    void Start()
    {
        selectable_tb_sys _sel_enemy = opp_selection.GetComponent<selectable_tb_sys>();
        _sel_enemy.sl_thisObject = opp_thisCharacter;

        enemy_status_sys _enemy_sys = opp_thisCharacter.GetComponent<enemy_status_sys>();

        opp_health_slider.maxValue = _enemy_sys.enemy_stat_HP;
        opp_shield_slider.maxValue = _enemy_sys.enemy_stat_shield;
        opp_break_slider.maxValue = _enemy_sys.enemy_stat_break;
        opp_ultimate_slider.maxValue = _enemy_sys.enemy_stat_ultimate;

        opp_health_slider.value = _enemy_sys.enemy_stat_HP;
        opp_shield_slider.value = _enemy_sys.enemy_stat_shield;
        opp_break_slider.value = _enemy_sys.enemy_stat_break;
        opp_ultimate_slider.value = _enemy_sys.enemy_stat_ultimate;
    }
}

public enum enemyINDEX_en { none, left03, left02, left01, middle, right01, right02, right03, noneLast };
public enum enemyRARITY_en { none, creep, miniBoss, bigBoss };