using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    internal List<GameObject> EnemyCardsinHand = new List<GameObject>();
    internal List<GameObject> EnemyCardsinRanged = new List<GameObject>();
    internal List<GameObject> EnemyCardsinMelee = new List<GameObject>();

    [SerializeField] private int numberofactions;

    [SerializeField] private GameObject enemyrange1;
    [SerializeField] private GameObject enemyrange2;
    [SerializeField] private GameObject enemymelee1;
    [SerializeField] private GameObject enemymelee2;
    [SerializeField] private GameObject enemymelee3;
    [SerializeField] private GameObject enemydeck;
    [SerializeField] private GameObject Turnsystem;


    private TurnSystem turn;
    private EnemyDeck deck;

    void Start()
    {
        turn = Turnsystem.GetComponent<TurnSystem>();
        deck = enemydeck.GetComponent<EnemyDeck>();

        TurnSystem.OnEndTurn += handleOnEndTurn;
    }

    void handleOnEndTurn()
    {
        StartCoroutine(YIPPPEEE());
    }

    private GameObject ChooseCard() 
    {
        List<GameObject> cardsInUse = new List<GameObject>(EnemyCardsinMelee);
        cardsInUse.AddRange(EnemyCardsinRanged);
        int random = Random.Range(0, cardsInUse.Count);
        return cardsInUse[random];
    }

    private void MoveCardFromRangeToMelee()
    {
        int number = Random.Range(0, 1);

        if (number == 0 && enemyrange1.transform.childCount > 0)
        {
            GameObject card = enemyrange1.transform.GetChild(0).gameObject;
            bool movedCard = MoveCardToMelee(card);
            if(movedCard)
            {
                EnemyCardsinRanged.Remove(card);
            }
        }
        else if (number == 1 && enemyrange2.transform.childCount > 0)
        {
            GameObject card = enemyrange2.transform.GetChild(0).gameObject;
            bool movedCard = MoveCardToMelee(card);
            if (movedCard)
            {
                EnemyCardsinRanged.Remove(card);
            }
        }
    }

    private void MoveCardToRange(GameObject card)
    {
        int number = Random.Range(0, 1);

        if (number == 0 && enemyrange1.transform.childCount == 0)
        {
            IntantiateCard(enemyrange1, card);
            EnemyCardsinRanged.Add(card);
        }
        else if (number == 1 && enemyrange2.transform.childCount == 0)
        {
            IntantiateCard(enemyrange2, card);
            EnemyCardsinRanged.Add(card);
        }
    }

    private bool MoveCardToMelee(GameObject card)
    {
        int number = Random.Range(0, 5);

        if (number == 0 && enemymelee1.transform.childCount == 0)
        {
            IntantiateCard(enemymelee1, card);
            EnemyCardsinMelee.Add(card);
            return true;
        }
        else if (number == 1 && enemymelee2.transform.childCount == 0)
        {
            IntantiateCard(enemymelee2, card);
            EnemyCardsinMelee.Add(card);
            return true;
        }
        else if (number == 2 && enemymelee3.transform.childCount == 0)
        {
            IntantiateCard(enemymelee3, card);
            EnemyCardsinMelee.Add(card);
            return true;
        }

        return false;
    }

    private void IntantiateCard(GameObject parent, GameObject card)
    {
        card.transform.SetParent(parent.transform);
        card.transform.localPosition = new Vector3(0, 0, 0);
        card.GetComponent<Cardback>().TurnCard(false);
        card.transform.tag = parent.name.Replace("Place", "Card");
        EnemyCardsinMelee.Add(card);
    }

    IEnumerator YIPPPEEE()
    {
        for (int i = 0; i < numberofactions; i++)
        {
            int number = Random.Range(0, 5);
            yield return new WaitForSeconds(2);
            if (number == 0)
            {
                int index = Random.Range(0, 5);
                MoveCardToMelee(EnemyCardsinHand[index]);
            }
            else if (number == 1)
            {
                int index = Random.Range(0, 5);
                MoveCardToRange(EnemyCardsinHand[index]);
            }
            else if (number == 2)
            {
                MoveCardFromRangeToMelee();
            }
            else if (number == 3)
            {
                Debug.Log("Attack");
                Attack();
            }
            else
            {
                deck.DrawCard(0);
            }
        }
        turn.EndyourOponentTurn();
    }

    private void Attack()
    {
        GameObject child = ChooseCard();
        if (child != null)
        {
            GameObject cardPlace = child.transform.parent.gameObject;
            GameObject card = GameObject.FindGameObjectWithTag(cardPlace.name.Replace("Place", "Card"));
            GameObject enemyCard = GameObject.FindGameObjectWithTag(cardPlace.name.Replace("Enemy", "Player").Replace("Place", "Card"));
            EnemyDeck enemyDeck = GameObject.FindGameObjectWithTag("PlayerDeck").GetComponent<EnemyDeck>();
            if (card != null)
            {
                DisplayCard cardData = card.GetComponent<DisplayCard>();

                Debug.Log("test");

                if (cardData != null || !cardData.canAttack)
                {
                    return;
                }
                
                cardData.canAttack = false;

                if (cardPlace.name is "EnemyRangePlace1" or "EnemyRangePlace2")
                {
                    GameObject enemyCard1;
                    try
                    {
                        enemyCard1 = GameObject.FindGameObjectWithTag("PlayerMeleePlace1");
                    }
                    catch
                    {
                        enemyCard1 = null;
                    }
                    if (enemyCard1 != null)
                    {
                        DisplayCard enemyCard1Data = enemyCard1.GetComponent<DisplayCard>();
                        enemyCard1Data.Damage(cardData.power);
                    }

                    GameObject enemyCard2;
                    try
                    {
                        enemyCard2 = GameObject.FindGameObjectWithTag("PlayerMeleePlace2");
                    }
                    catch
                    {
                        enemyCard2 = null;
                    }
                    if (enemyCard2 != null)
                    {
                        DisplayCard enemyCard2Data = enemyCard2.GetComponent<DisplayCard>();
                        enemyCard2Data.Damage(cardData.power);
                    }

                    GameObject enemyCard3;
                    try
                    {
                        enemyCard3 = GameObject.FindGameObjectWithTag("PlayerMeleePlace3");
                    }
                    catch
                    {
                        enemyCard3 = null;
                    }
                    if (enemyCard3 != null)
                    {
                        DisplayCard enemyCard3Data = enemyCard3.GetComponent<DisplayCard>();
                        enemyCard3Data.Damage(cardData.power);

                        Debug.Log("Damage Card1");
                    }
                }
                else if (enemyCard != null)
                {
                    Debug.Log("Damage Card2");
                    DisplayCard enemyData = enemyCard.GetComponent<DisplayCard>();
                    enemyData.Damage(cardData.power);
                }
                else
                {
                    Debug.Log("Damage Player");
                    enemyDeck.Damage(cardData.power);
                }
            }
        }
    }
}