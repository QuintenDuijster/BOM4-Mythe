using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    internal List<GameObject> EnemyCardsinHand = new List<GameObject>();
    internal List<GameObject> EnemyCardsinRanged = new List<GameObject>();
    internal List<GameObject> EnemyCardsinMelee = new List<GameObject>();

    [SerializeField]private int numberofactions;

    private GameObject movedrangecard;
    private GameObject movedmeleecard;
    private GameObject chosencard;

    [SerializeField]private GameObject enemyrange1;
    [SerializeField]private GameObject enemyrange2;
    [SerializeField]private GameObject enemymelee1;
    [SerializeField]private GameObject enemymelee2;
    [SerializeField]private GameObject enemymelee3;
    [SerializeField]private GameObject enemygrave;
    [SerializeField]private GameObject enemydeck;
    [SerializeField]private GameObject Turnsystem;

    private TurnSystem turn;
    private EnemyDeck deck;
    private Draggable drag;

    void Start()
    {
        turn = Turnsystem.GetComponent<TurnSystem>();
        deck = enemydeck.GetComponent<EnemyDeck>();

        TurnSystem.OnEndTurn += handleOnEndTurn;
    }

    private void ChooseRangeCard()
    {
        if (EnemyCardsinHand.Count > 0)
        {
            if (EnemyCardsinHand[0] != null)
            {
                chosencard = EnemyCardsinHand[0];
                EnemyCardsinHand.RemoveAt(0);
                movedrangecard = chosencard;
                drag = movedrangecard.GetComponent<Draggable>();
            }
            else
            {
                deck.DrawCard(0);
                Debug.Log("issue in the skill");
            }
        }
    }

    private void MoveCardToRange(bool isgood)
    {
        int number = Randomizer(1, 6);
        
        if (number < 3)
        {
            isgood = true;
        } else if (number > 3)
        {
            isgood = false;
        }
        if (number < 3 && enemyrange1.transform.childCount == 0)
        {
            movedrangecard.transform.SetParent(enemyrange1.transform);
            movedrangecard.transform.localPosition = new Vector3(0,0,0);
            movedrangecard.GetComponent<Cardback>().TurnCard(false);
            movedrangecard.transform.tag = "EnemyRangeCard1";
            EnemyCardsinRanged.Add(movedrangecard);
            Debug.Log("ranfe1");
        }
        else if ((number > 3 || isgood == true) && enemyrange2.transform.childCount == 0)
        {
            movedrangecard.transform.SetParent(enemyrange2.transform);
            movedrangecard.transform.localPosition = new Vector3(0, 0, 0);
            movedrangecard.GetComponent<Cardback>().TurnCard(false);
            movedrangecard.transform.tag = "EnemyRangeCard2";
            EnemyCardsinRanged.Add(movedrangecard);
            Debug.Log("range2");
        }
        else
        {
            movedrangecard.transform.SetParent(enemygrave.transform);
            movedrangecard.transform.localPosition = new Vector3(0, 0, 0);
            Debug.Log("skill issue");
        }
    }

    private void Attack(GameObject cardPlace)
    {
        GameObject card = GameObject.FindGameObjectWithTag(cardPlace.name.Replace("Place", "Card"));
        GameObject enemyCard = GameObject.FindGameObjectWithTag(cardPlace.name.Replace("Enemy", "Player").Replace("Place", "Card"));
        EnemyDeck enemyDeck = GameObject.FindGameObjectWithTag("PlayerDeck").GetComponent<EnemyDeck>();
        if (card != null)
        {
            DisplayCard cardData = card.GetComponent<DisplayCard>();
            if (cardPlace.name is "EnemyRangePlace1" or "EnemyRangePlace2")
            {
                GameObject enemyCard1 = GameObject.FindGameObjectWithTag("PlayerMeleePlace1");
                if (enemyCard1 != null)
                {
                    DisplayCard enemyCard1Data = enemyCard1.GetComponent<DisplayCard>();
                    enemyCard1Data.Damage(cardData.power);
                }

                GameObject enemyCard2 = GameObject.FindGameObjectWithTag("PlayerMeleePlace2");
                if (enemyCard2 != null)
                {
                    DisplayCard enemyCard2Data = enemyCard2.GetComponent<DisplayCard>();
                    enemyCard2Data.Damage(cardData.power);
                }

                GameObject enemyCard3 = GameObject.FindGameObjectWithTag("PlayerMeleePlace3");
                if (enemyCard3 != null)
                {
                    DisplayCard enemyCard3Data = enemyCard3.GetComponent<DisplayCard>();
                    enemyCard3Data.Damage(cardData.power);
                }
            }
            else if (enemyCard != null)
            {
                DisplayCard enemyData = enemyCard.GetComponent<DisplayCard>();
                enemyData.Damage(cardData.power);
            }
            else
            {
                enemyDeck.Damage(cardData.power);
            }
        }
    }

    private void ChooseMeleeCard() // Chposes a Range card to move to Melee
    {
        int number = Randomizer(1, 2);
        int number2 = Randomizer(1, 2);
        int spot1 = 0;
        int spot2 = 1;
        
        
        if (EnemyCardsinRanged != null && EnemyCardsinRanged.Count > 0)
        {
            if (number == 1 && drag.turnsexisted == 1)
            {
                chosencard = EnemyCardsinRanged[spot1];
                EnemyCardsinRanged.RemoveAt(spot1);
                movedmeleecard = chosencard;
                drag = movedmeleecard.GetComponent<Draggable>();
            } else if (number == 2 && drag.turnsexisted == 1)
            {
                chosencard = EnemyCardsinRanged[spot2];
                EnemyCardsinRanged.RemoveAt(spot2);
                movedmeleecard = chosencard;
                drag = movedmeleecard.GetComponent<Draggable>();
            }
        } 
        else 
        {
            if (number2 == 1 && EnemyCardsinHand != null)
            {
                ChooseRangeCard();
                MoveCardToRange(true);
            }
            else if (number2 == 2 && EnemyCardsinHand.Count < 7)
            {
                deck.DrawCard(0);
            }
        }
    }
    private void MoveCardToMelee(bool isgood) // Moves the chosen card to Melee
    {
        int number = Randomizer(1, 6);
        if (number < 4)
        {
            isgood = false;
        }
        else if (number > 4)
        {
            isgood = true;
        }
        if (number < 2 && enemymelee1.transform.childCount == 0)
        {
            movedmeleecard.transform.SetParent(enemymelee1.transform);
            movedmeleecard.transform.localPosition = new Vector3(0, 0, 0);
            movedmeleecard.GetComponent<Cardback>().TurnCard(false);
            movedmeleecard.transform.tag = "EnemyMeleeCard1";
            EnemyCardsinMelee.Add(movedmeleecard);
            Debug.Log("meelee1");
        }
        else if ((number > 2 && isgood == true) && number < 4 && enemymelee2.transform.childCount == 0)
        {
            movedmeleecard.transform.SetParent(enemymelee2.transform);
            movedmeleecard.transform.localPosition = new Vector3(0, 0, 0);
            movedmeleecard.GetComponent<Cardback>().TurnCard(false);
            movedmeleecard.transform.tag = "EnemyMeleeCard2";
            EnemyCardsinMelee.Add(movedmeleecard);
            Debug.Log("meelee2");
        }
        else if (number > 4 && enemymelee3.transform.childCount == 0)
        {
            movedmeleecard.transform.SetParent(enemymelee3.transform);
            movedmeleecard.transform.localPosition = new Vector3(0, 0, 0);
            movedmeleecard.GetComponent<Cardback>().TurnCard(false);
            movedmeleecard.transform.tag = "EnemyMeleeCard3";
            EnemyCardsinMelee.Add(movedmeleecard);
            Debug.Log("meelee3");
        }
        else
        {
            movedmeleecard.transform.SetParent(enemygrave.transform);
            movedmeleecard.transform.localPosition = new Vector3(0, 0, 0);
            Debug.Log("skill issue");
        }
    }
    private int Randomizer(int Min, int Max)
    {
        int number = UnityEngine.Random.Range(Min, Max);
        return number;
    }

    IEnumerator YIPPPEEE()
    {
        for (int i = 0; i < numberofactions; i++)
        {
            int number = Randomizer(1, 4);
            yield return new WaitForSeconds(2);
            if (EnemyCardsinRanged.Count == 0)
            {
                ChooseRangeCard();
                if (movedrangecard != null)
                {
                    MoveCardToRange(true);
                }
                else
                {
                    deck.DrawCard(0);
                }
            }
            else {
                ChooseMeleeCard();
                if (movedmeleecard != null)
                {
                    MoveCardToMelee(true);
                }
                else
                {
                    deck.DrawCard(0);
                }
            } 
        }
        turn.EndyourOponentTurn();
    }

    void handleOnEndTurn() 
    {
        if (turn.isYourTurn == false)
        {
            StartCoroutine(YIPPPEEE());
        }
        else if (turn.isYourTurn == true)
        {
            StopCoroutine(YIPPPEEE());
        }
    }
}