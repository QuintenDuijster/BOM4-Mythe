using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToEnemyHand : MonoBehaviour
{
    public GameObject EnemyHand;
    public GameObject HandCard;
    public GameObject CardBack;
    private GameObject enemyai;
    // Update is called once per frame
    private void Start()
    {
        enemyai = GameObject.Find("EnemyAI");

        EnemyAI ai = enemyai.GetComponent<EnemyAI>();
        ai.EnemyCardsinHand.Add(HandCard);
        EnemyHand = GameObject.Find("EnemyHand");
        HandCard.transform.SetParent(EnemyHand.transform);
        HandCard.transform.localScale = new Vector3(1.2f, 1.2f, 1.2f);
        HandCard.transform.position = new Vector3(transform.position.x, transform.position.y, 0);
        HandCard.transform.eulerAngles = new Vector3(0, 0, 180);
        CardBack.gameObject.SetActive(true);
        HandCard.tag = "EnemyCard";
    }
}