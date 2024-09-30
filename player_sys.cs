using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class player_sys : MonoBehaviour
{
    public GameObject pla_thisCharacter;
    public playerINDEX pla_index;
    public bool pla_aliveStatus;
    public Color pla_color;
    [Space]
    public GameObject pla_selection;
    public bool pla_selected;
    public GameObject pla_images;

    public Slider pla_shield_slider;
    public Slider pla_health_slider;
    public Slider pla_break_slider;
    public GameObject pla_buffDebuff_panel;
    [Space]
    public GameObject pla_ultimate_selection;
    public GameObject pla_ultimate_image;
    public Slider pla_ultimate_slider;

    public GameObject pla_skill_selection;
    public GameObject pla_skill_image;

    public GameObject pla_hitA_selection;
    public GameObject pla_hitA_image;

    public GameObject pla_hitB_selection;
    public GameObject pla_hitB_image;

    void Start()
    {
        selectable_tb_sys _sel_player = pla_selection.GetComponent<selectable_tb_sys>();
        selectable_tb_sys _sel_ultimate = pla_ultimate_selection.GetComponent<selectable_tb_sys>();
        selectable_tb_sys _sel_skill = pla_skill_selection.GetComponent<selectable_tb_sys>();
        selectable_tb_sys _sel_hitA = pla_hitA_selection.GetComponent<selectable_tb_sys>();
        selectable_tb_sys _sel_hitB = pla_hitB_selection.GetComponent<selectable_tb_sys>();

        //_sel_player.sl_thisObject = pla_thisCharacter;
        //_sel_ultimate.sl_thisObject = pla_thisCharacter;
        //_sel_skill.sl_thisObject = pla_thisCharacter;
        //_sel_hitA.sl_thisObject = pla_thisCharacter;
        //_sel_hitB.sl_thisObject = pla_thisCharacter;
        _sel_player.sl_thisObject = gameObject;
        _sel_ultimate.sl_thisObject = gameObject;
        _sel_skill.sl_thisObject = gameObject;
        _sel_hitA.sl_thisObject = gameObject;
        _sel_hitB.sl_thisObject = gameObject;

        character_status_sys _player_sys = pla_thisCharacter.GetComponent<character_status_sys>();

        pla_health_slider.maxValue = _player_sys.cha_stat_HP;
        pla_shield_slider.maxValue = _player_sys.cha_stat_shield;
        pla_break_slider.maxValue = _player_sys.cha_stat_break;
        pla_ultimate_slider.maxValue = _player_sys.cha_stat_ultimate;

        pla_health_slider.value = _player_sys.cha_stat_HP;
        pla_shield_slider.value = _player_sys.cha_stat_shield;
        pla_break_slider.value = _player_sys.cha_stat_break;
        pla_ultimate_slider.value = _player_sys.cha_stat_ultimate;
    }
}

public enum playerINDEX { none, playerA, playerB };