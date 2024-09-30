using LP.turnBasedCombat;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class selectable_tb_sys : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private selectable_tb sl_selectionType;
    public GameObject sl_thisObject;

    turnBase_sys tb;

    void Awake()
    {
        tb = GameObject.Find("ctrl_system").GetComponent<turnBase_sys>();
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (sl_selectionType == selectable_tb.none)
                Debug.Log(gameObject);
            else if (sl_selectionType == selectable_tb.enemyTarget)
                tb.changeEnemyTarget(sl_thisObject);
            else if (sl_selectionType == selectable_tb.playerTarget)
                tb.changePlayerTarget(sl_thisObject);
            else if (sl_selectionType == selectable_tb.resetMovement)
                tb.resetMovementSet();
            else if (sl_selectionType == selectable_tb.pla_ultimate)
                tb.do_ultimate(sl_thisObject);
            else if (sl_selectionType == selectable_tb.pla_skill)
                tb.do_skill(sl_thisObject);
            else if (sl_selectionType == selectable_tb.pla_hitA)
                tb.do_hitA(sl_thisObject);
            else if (sl_selectionType == selectable_tb.pla_hitB)
                tb.do_hitB(sl_thisObject);
        }
    }
}

public enum selectable_tb { none, enemyTarget, playerTarget, resetMovement, pla_ultimate, pla_skill, pla_hitA, pla_hitB };