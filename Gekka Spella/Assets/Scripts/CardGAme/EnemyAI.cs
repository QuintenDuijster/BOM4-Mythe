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
        if (cardsInUse.Count > 0)
        {
			int random = Random.Range(0, cardsInUse.Count);
			return cardsInUse[random];
        }
        else
        {
            return null;
        }
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
            return true;
        }
        else if (number == 1 && enemymelee2.transform.childCount == 0)
        {
            IntantiateCard(enemymelee2, card);
            return true;
        }
        else if (number == 2 && enemymelee3.transform.childCount == 0)
        {
            IntantiateCard(enemymelee3, card);
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
                int index = Random.Range(0, EnemyCardsinHand.Count - 1);
                MoveCardToMelee(EnemyCardsinHand[index]);
                EnemyCardsinHand.RemoveAt(index);
            }
            else if (number == 1)
            {
                int index = Random.Range(0, EnemyCardsinHand.Count - 1);
                MoveCardToRange(EnemyCardsinHand[index]);
				EnemyCardsinHand.RemoveAt(index);
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
        Debug.Log("Attack");

        GameObject child = ChooseCard();
        if (child != null)
        {
            GameObject cardPlace = child.transform.parent.gameObject;
            GameObject card = GameObject.FindGameObjectWithTag(cardPlace.name.Replace("Place", "Card"));
            GameObject playerCard = GameObject.FindGameObjectWithTag(cardPlace.name.Replace("Enemy", "Player").Replace("Place", "Card"));
            EnemyDeck playerDeck = GameObject.FindGameObjectWithTag("PlayerDeck").GetComponent<EnemyDeck>();
            if (card != null)
            {
                DisplayCard cardData = card.GetComponent<DisplayCard>();

                if (cardData != null)
                {
                    return;
                }

                if (!cardData.canAttack)
                {
                    return;
                }
                
                cardData.canAttack = false;

                if (cardPlace.name is "EnemyRangePlace1" or "EnemyRangePlace2")
                {
                    GameObject playerCard1;
                    try
                    {
                        playerCard1 = GameObject.FindGameObjectWithTag("PlayerMeleePlace1");
                    }
                    catch
                    {
                        playerCard1 = null;
                    }
                    if (playerCard1 != null)
                    {
                        DisplayCard playerCard1Data = playerCard1.GetComponent<DisplayCard>();
						playerCard1Data.Damage(cardData.power);
                    }

                    GameObject playerCard2;
                    try
                    {
                        playerCard2 = GameObject.FindGameObjectWithTag("PlayerMeleePlace2");
                    }
                    catch
                    {
                        playerCard2 = null;
                    }
                    if (playerCard2 != null)
                    {
                        DisplayCard playerCard2Data = playerCard2.GetComponent<DisplayCard>();
                        playerCard2Data.Damage(cardData.power);
                    }

                    GameObject playerCard3;
                    try
                    {
                        playerCard3 = GameObject.FindGameObjectWithTag("PlayerMeleePlace3");
                    }
                    catch
                    {
                        playerCard3 = null;
                    }
                    if (playerCard3 != null)
                    {
                        DisplayCard playerCard3Data = playerCard3.GetComponent<DisplayCard>();
                        playerCard3Data.Damage(cardData.power);
                    }
                }
                else if (playerCard != null)
                {
                    DisplayCard playerCardData = playerCard.GetComponent<DisplayCard>();
					playerCardData.Damage(cardData.power);
                }
                else
                {
                    playerDeck.Damage(cardData.power);
                }
            }
        }
    }
}