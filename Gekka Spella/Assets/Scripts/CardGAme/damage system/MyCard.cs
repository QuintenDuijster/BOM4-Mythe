using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MyCard : MonoBehaviour
{
    DisplayCard card;
    ClickToAttack clckToAttake;
    internal bool playercard;
     void Update()
    {
        switch (gameObject.tag)
        {
            case "PlayerMeleeCard1": 
                playercard = true;
                break;
            case "PlayerMeleeCard2":
                playercard = true;
                break;
            case "PlayerMeleeCard3":
                playercard = true;
                break;
            case "PlayerRangeCard1":
                playercard = true;
                break;
            case "PlayerRangeCard2":
                playercard = true;
                break;
            case "EnemyMeleeCard1":
                playercard = false;
                break;
            case "EnemyMeleeCard2":
                playercard = false;
                break;
            case "EnemyMeleeCard3":
                playercard = false;
                break;
            case "EnemyRangeCard1":
                playercard = false;
                break;
            case "EnemyRangeCard2":
                playercard = false;
                break;

        }
    }
}
