//using System;
//using System.Collections;
//using System.Collections.Generic;
//using Unity.VisualScripting;
//using UnityEditor.Experimental.GraphView;
//using UnityEngine;
//using UnityEngine.EventSystems;
//using UnityEngine.UI;


//public class EnemyClickToAttack : MonoBehaviour, IPointerClickHandler
//{

//    internal int healthTarget;
//    internal int newHealth;
//    internal int attacker;
//    internal bool attack = true;
//    internal GameObject target;
//    public GameObject attackData;
//    DisplayCard DisplayCard;



//    public void OnPointerClick(PointerEventData eventData)
//    {
//        attackData = GameObject.Find("data");
//        bool attacking = attackData.GetComponent<AttackData>().attack;
//        bool playerCard = gameObject.GetComponent<MyCard>().playercard;
//        if (attackData.GetComponent<AttackData>().attack && !playerCard)
//        {

//            attackData.GetComponent<AttackData>().power = gameObject.GetComponent<DisplayCard>().power;

//            attackData.GetComponent<AttackData>().attack = false;


//        }

//        if (!attackData.GetComponent<AttackData>().attack && playerCard)
//        {


//            healthTarget = this.gameObject.GetComponent<DisplayCard>().health;

//            this.gameObject.GetComponent<DisplayCard>().health = healthTarget - attackData.GetComponent<AttackData>().power;
//            attackData.GetComponent<AttackData>().attack = true;
//            if (gameObject.GetComponent<DisplayCard>().health <= 0)
//            {
//                Destroy(gameObject);

//            }

//        }


//    }

//}
