using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

public class panel_movement_sys : MonoBehaviour
{
    //[Serializable]
    //public struct movementStay
    //{
    //    public GameObject moveset_user;
    //    public hitTYPE_ch moveset_action;
    //}

    public GameObject moveset_image;
    public TMP_Text moveset_tmp;
    //public List<movementStay> moveset_playerList = new List<movementStay>();
    //public List<movementStay> moveset_enemyList = new List<movementStay>();

    turnBase_sys tb;
    void Awake()
    {
        tb = GameObject.Find("ctrl_system").GetComponent<turnBase_sys>();
    }

    //public void moveset_addTHIS()
    //{

    //}
}
