using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.VersionControl;
using UnityEngine;
using UnityEngine.UI;

public class turnBase_sys : MonoBehaviour
{
    [Serializable]
    public struct movementList_tbt
    {
        public GameObject fromThisGuy;
        public hitTYPE_ch hitType;
        public GameObject toThisGuy;
    }

    /// <summary>
    /// 
    /// </summary>

    public GameObject selected_player_tb;
    public GameObject selected_enemy_tb;
    public GameObject movementPanel_tb;
    public GameObject movementPrefab_tb;
    [Space]

    public List<GameObject> player_movementList_tb;
    public int player_movementAvailable_tb;
    public int player_total_tb;

    public int enemy_movementAvailable_tb;
    public int enemy_total_tb;

    //[HideInInspector] public targetList_tbt player_targetList;
    //[HideInInspector] public targetList_tbt enemy_targetList;
    public GameObject[] player_index = new GameObject[2];
    public GameObject[] enemy_index = new GameObject[9];
    public List<GameObject> target_single = new List<GameObject>();
    public List<GameObject> target_blast = new List<GameObject>();
    public List<GameObject> target_aoe = new List<GameObject>();
    //public GameObject[] target_randomSINGLE;
    //public GameObject[] target_randomAOE;

    //

    [Serializable]
    public struct movementStay
    {
        public GameObject moveset_user;
        public actionList_ch[] moveset_action;
    }
    public List<movementStay> moveset_playerList = new List<movementStay>();
    public List<movementStay> moveset_enemyList = new List<movementStay>();
    private int moveset_playerSUM;
    private int moveset_enemySUM;
    private float demage_totalSUM = 0;

    /// <summary>
    /// 
    /// </summary>
    /// 
    panel_movement_sys moveset;

    void Awake()
    {
        moveset = GameObject.Find("ctrl_system").GetComponent<panel_movement_sys>();

        // temp
        player_movementAvailable_tb = 3;
        enemy_movementAvailable_tb = 3;
        findTarget();

        clearThisChild(movementPanel_tb);
        createMovementPanel(player_movementAvailable_tb);
    }
    void clearThisChild(GameObject panel_generated)
    {
        int _num = panel_generated.transform.childCount;
        for (int i = 0; i < _num; i++)
        {
            GameObject _child = panel_generated.transform.GetChild(i).gameObject;
            Destroy(_child);
        }
    }
    void createMovementPanel(int _total)
    {
        for (int i = 0; i < _total; i++)
        {
            GameObject _newPanel = Instantiate(movementPrefab_tb, movementPanel_tb.transform);
            panel_movement_sys _newPanel_sys = _newPanel.GetComponent<panel_movement_sys>();
            TMP_Text _newPanel_tmp = _newPanel_sys.moveset_tmp;
            Image _newPanel_img = _newPanel_sys.moveset_image.GetComponent<Image>();
            player_movementList_tb.Add(_newPanel);
        }
    }


    /// <summary>
    /// 
    /// </summary>
    /// <param name="_theEnemy"></param>
    public void changeEnemyTarget(GameObject _theEnemy)
    {
        Debug.Log(_theEnemy);
    }
    public void changePlayerTarget(GameObject _thePlayer)
    {
        Debug.Log(_thePlayer);
    }
    public void resetMovementSet()
    {
        Debug.Log("Removed");
    }
    public void do_ultimate(GameObject _thePlayer)
    {
        player_sys _panelPlayer_sys = _thePlayer.GetComponent<player_sys>();
        character_status_sys _player_sys = _panelPlayer_sys.pla_thisCharacter.GetComponent<character_status_sys>();

        StartCoroutine(moveset_addTHIS(_thePlayer, _player_sys.cha_hitUltimate_action));
    }
    public void do_skill(GameObject _thePlayer)
    {
        player_sys _panelPlayer_sys = _thePlayer.GetComponent<player_sys>();
        character_status_sys _player_sys = _panelPlayer_sys.pla_thisCharacter.GetComponent<character_status_sys>();

        StartCoroutine(moveset_addTHIS(_thePlayer, _player_sys.cha_hitSkill_action));
    }
    public void do_hitA(GameObject _thePlayer)
    {
        player_sys _panelPlayer_sys = _thePlayer.GetComponent<player_sys>();
        character_status_sys _player_sys = _panelPlayer_sys.pla_thisCharacter.GetComponent<character_status_sys>();

        StartCoroutine(moveset_addTHIS(_thePlayer, _player_sys.cha_hitA_action));
    }
    public void do_hitB(GameObject _thePlayer)
    {
        player_sys _panelPlayer_sys = _thePlayer.GetComponent<player_sys>();
        character_status_sys _player_sys = _panelPlayer_sys.pla_thisCharacter.GetComponent<character_status_sys>();

        StartCoroutine(moveset_addTHIS(_thePlayer, _player_sys.cha_hitB_action));
    }

    /// <summary>
    /// 
    /// </summary>

    IEnumerator moveset_addTHIS(GameObject _thePlayer, actionList_ch[] _actionList)
    {
        player_sys _panelPlayer_sys = _thePlayer.GetComponent<player_sys>();
        character_status_sys _player_sys = _panelPlayer_sys.pla_thisCharacter.GetComponent<character_status_sys>();

        movementStay _temp = new movementStay();
        _temp.moveset_user = _thePlayer;
        _temp.moveset_action = _actionList;
        moveset_playerList.Add(_temp);

        panel_movement_sys _panelMove_sys = player_movementList_tb[moveset_playerSUM].GetComponent<panel_movement_sys>();
        Image _panelMove_image  = _panelMove_sys.moveset_image.GetComponent<Image>();
        TMP_Text _panelMove_text = _panelMove_sys.moveset_tmp.GetComponent<TMP_Text>();
        _panelMove_image.color = _panelPlayer_sys.pla_color;
        _panelMove_text.text = _actionList[0].actionType.ToString();

        moveset_playerSUM += 1;

        if (moveset_playerSUM == player_movementAvailable_tb)
        {
            for (int i = 0; i < player_movementAvailable_tb; i++)
            {
                StartCoroutine(doing_this_hit(moveset_playerList[i].moveset_user, moveset_playerList[i].moveset_action));
            }
            yield return new WaitForSeconds(1.2f);
            moveset_playerSUM = 0;
            moveset_playerList.Clear();
            clearThisChild(movementPanel_tb);
            player_movementList_tb.Clear();
            createMovementPanel(player_movementAvailable_tb);
        }
    }
    IEnumerator doing_this_hit(GameObject _thePlayer, actionList_ch[] _actionList)
    {
        player_sys _panelPlayer_sys = _thePlayer.GetComponent<player_sys>();
        character_status_sys _player_sys = _panelPlayer_sys.pla_thisCharacter.GetComponent<character_status_sys>();

        for (int i = 0; i < _actionList.Length; i++)
        {
            demage_totalSUM += _actionList[i].actionValue;
            if (_actionList[i].actionType == actionTYPE_ch._attack)
            {
                if (_actionList[i].actionTarget == actionTARGET_ch._single)
                {
                    doing_attack(_thePlayer, target_single[0], _actionList[i], true);
                    add_ultimate(_thePlayer, _actionList[i]);
                }
                else if (_actionList[i].actionTarget == actionTARGET_ch._blast)
                {
                    doing_attack(_thePlayer, target_single[0], _actionList[i], true);

                    for (int o = 0; o < (int)target_blast.Count; o++)
                    {
                        doing_attack(_thePlayer, target_blast[o], _actionList[i], true);
                    }

                    add_ultimate(_thePlayer, _actionList[i]);
                }
                else if (_actionList[i].actionTarget == actionTARGET_ch._aoe)
                {
                    for (int o = 0; o < (int)target_aoe.Count; o++)
                    {
                        doing_attack(_thePlayer, target_aoe[o], _actionList[i], true);
                    }

                    add_ultimate(_thePlayer, _actionList[i]);
                }
            }
        }

        // temp target
        // nanti dikalkulasikan
        // salah total gpp pake dulu lah
        yield return new WaitForSeconds(0.1f);
        createDemageView(target_single[0], demage_totalSUM);
        yield return new WaitForSecondsRealtime(1);
        clearDemageView(target_single[0]);
        yield return new WaitForSeconds(0.1f);
        //Debug.Log(demage_totalSUM);
        //Debug.Log("Finish");
        demage_totalSUM = 0;
    }
    void add_ultimate(GameObject _user, actionList_ch _actionList)
    {
        player_sys _user_panel = _user.GetComponent<player_sys>();
        character_status_sys _user_data = _user_panel.pla_thisCharacter.GetComponent<character_status_sys>();

        _user_panel.pla_ultimate_slider.value += _actionList.chargeUltimate;
    }
    void doing_attack(GameObject _player, GameObject _enemy, actionList_ch _actionList, bool whatToDo)
    {
        // whatToDo // true adalah menyerang musuh // false adalah menyerang player

        player_sys _player_panel = _player.GetComponent<player_sys>();
        character_status_sys _player_data = _player_panel.pla_thisCharacter.GetComponent<character_status_sys>();

        enemy_sys _target_panel = _enemy.GetComponent<enemy_sys>();
        enemy_status_sys _target_data = _target_panel.opp_thisCharacter.GetComponent<enemy_status_sys>();

        //

        float _dmgSource = _actionList.actionValue;
        float _dmgLeftover;

        if (whatToDo == true)   // player menyerang enemy
        {
            if (_target_panel.opp_shield_slider.value >= _dmgSource)
            {
                _target_panel.opp_shield_slider.value -= _dmgSource;
            }
            else if (_target_panel.opp_shield_slider.value < _dmgSource && _target_panel.opp_shield_slider.value != 0)
            {
                _dmgLeftover = _dmgSource - _target_panel.opp_health_slider.value;
                _target_panel.opp_shield_slider.value -= _dmgSource;
                _target_panel.opp_health_slider.value -= _dmgLeftover;
            }
            else
            {
                _target_panel.opp_health_slider.value -= _dmgSource;
            }
        }
        else if (whatToDo == false)   // enemy menyerang player
        {
            if (_player_panel.pla_shield_slider.value >= _dmgSource)
            {
                _player_panel.pla_shield_slider.value -= _dmgSource;
            }
            else if (_player_panel.pla_shield_slider.value < _dmgSource && _player_panel.pla_shield_slider.value != 0)
            {
                _dmgLeftover = _dmgSource - _player_panel.pla_shield_slider.value;
                _player_panel.pla_shield_slider.value -= _dmgSource;
                _player_panel.pla_health_slider.value -= _dmgLeftover;
            }
            else
            {
                _player_panel.pla_health_slider.value -= _dmgSource;
            }
        }

        //createDemageView(_enemy, _dmgSource);
        ////StartCoroutine(wait_aSecond(10.0f));
        //yield return new WaitForSecondsRealtime(1);
        //clearDemageView(_enemy);
        //Debug.Log(_dmgSource);
        //Debug.Log("Finish");
    }
    void clearDemageView(GameObject _enemy)
    {
        enemy_sys _target_panel = _enemy.GetComponent<enemy_sys>();
        enemy_status_sys _target_data = _target_panel.opp_thisCharacter.GetComponent<enemy_status_sys>();

        _target_panel.opp_demageImages.enabled = false;
        _target_panel.opp_demageText.enabled = false;
    }
    void createDemageView(GameObject _enemy, float _demageValue)
    {
        enemy_sys _target_panel = _enemy.GetComponent<enemy_sys>();
        enemy_status_sys _target_data = _target_panel.opp_thisCharacter.GetComponent<enemy_status_sys>();

        _target_panel.opp_demageImages.enabled = true;
        _target_panel.opp_demageText.enabled = true;
        _target_panel.opp_demageText.text = _demageValue.ToString();
    }
    void findTarget()
    {
        // Clear List
        target_single.Clear();
        target_blast.Clear();
        target_aoe.Clear();

        // Single Target
        target_single.Add(selected_enemy_tb);

        // Blast Target
        int _index = _arrayIndexCheck(enemy_index, selected_enemy_tb);
        if (enemy_index[_index - 1] != null) target_blast.Add(enemy_index[_index - 1]);
        if (enemy_index[_index + 1] != null) target_blast.Add(enemy_index[_index -+ 1]);

        // AOE Target
        for (int i = 0; i < enemy_index.Length; i++)
        {
            if (enemy_index[i] != null) target_aoe.Add(enemy_index[i]);
        }
    }
    int _arrayIndexCheck(GameObject[] _indexC, GameObject _checkThis)
    {
        for (int i = 0; i < _indexC.Length; i++) { if (_indexC[i] == _checkThis) return i; }
        return 4;
    }
    public IEnumerator wait_aSecond(float _second)
    {
        yield return new WaitForSeconds(_second);
    }
}

//// Bisa gini
//public GameObject[] player_movementList_tb;
//player_movementList_tb = new GameObject[1];
//player_movementList_tb[i] = _newPanel;
// Atau gini
//[HideInInspector] public List<GameObject> player_movementList_tb;
//player_movementList_tb.Add(_newPanel);

//// Bisa gini juga tapi ga keluar di inspector
//[SerializeField] public Dictionary<actionTYPE_ch, int> player_movementDictionary_tb;
//[Serializable]
//public struct NamedImage
//{
//    public string name;
//    public Texture2D image;
//    public int width;
//    public Sprite sprite;
//}

//public NamedImage[] pictures;
