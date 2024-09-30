using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// namespace itu kaya library biar nama dari class/def yg sama ga bikin error
namespace LP.turnBasedCombat
{
    public class turnBase_OLD_sys : MonoBehaviour
    {
        // [HideInInspector] public GameObject playerA;   // untuk hide variable ini dari properties di unity walau public
        // [SerializeField] private GameObject playerA;   // untuk show variable ini dari properties di unity walau private
        // public string testing { get; set; }   // apa ini
        [SerializeField] private GameObject playerA;
        [SerializeField] private GameObject playerB;
        [SerializeField] private GameObject enemyBossA;
        [SerializeField] private Slider playerAHealth;
        [SerializeField] private Slider playerBHealth;
        [SerializeField] private Slider enemyBossAHealth;
        [SerializeField] private Slider playerAMana;
        [SerializeField] private Slider playerBMana;
        [SerializeField] private Slider enemyBossABreak;
        [SerializeField] private Button btnAttack;
        [SerializeField] private Button btnHeal;

        private bool isPlayerTurn = true;

        
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
            Debug.Log(_thePlayer);
        }
        public void do_skill(GameObject _thePlayer)
        {
            Debug.Log(_thePlayer);
        }
        public void do_hitA(GameObject _thePlayer)
        {
            Debug.Log(_thePlayer);
        }
        public void do_hitB(GameObject _thePlayer)
        {
            Debug.Log(_thePlayer);
        }


























        private void attacking(GameObject target, float demage)
        {
            if (target == enemyBossA)
            {
                enemyBossAHealth.value -= demage;
            }
            // if (target == enemyBossA) { enemyBossAHealth.value -= demage; }   // bisa begini juga buat ringkas
            // else if (target == playerB)
            // {
            //     playerBHealth.value -= demage;
            // }
            else
            {
                playerAHealth.value -= demage;
            }
            // wait ga bisa elif   ternyata else if

            changeTurn();
        }
        private void healing(GameObject target, float heal)
        {
            if (target == enemyBossA)
            {
                enemyBossAHealth.value += heal;
            }
            else
            {
                playerAHealth.value += heal;
            }

            changeTurn();
        }
        public void btnAttacking()
        {
            attacking(enemyBossA, 10);
        }
        public void btnHealing()
        {
            healing(playerA, 10);
        }
        private void changeTurn()
        {
            isPlayerTurn = !isPlayerTurn;

            // if ( !isPlayerTurn )   // bisa begini juga
            if (isPlayerTurn == false)
            {
                btnAttack.interactable = false;
                btnHeal.interactable = false;

                StartCoroutine(enemyTurn());
            }
            else
            {
                btnAttack.interactable = true;
                btnHeal.interactable = true;
            }
        }
        private IEnumerator enemyTurn()
        {
            yield return new WaitForSeconds(3);

            int random = 0;

            random = Random.Range(1, 3);
            if (random == 1)
            {
                attacking(playerA, 20);
            }
            else
            {
                healing(enemyBossA, 5);
            }
        }
    }
}

