using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    internal List<GameObject> EnemyCardsinHand= new List<GameObject>();
    internal List<GameObject> EnemyCardsinRanged = new List<GameObject>();
    internal List<GameObject> EnemyCardsinMelee = new List<GameObject>();

    [SerializeField]private int numberofactions;

    private GameObject movedrangecard;
    private GameObject movedmeleecard;

    [SerializeField]private GameObject enemyrange1;
    [SerializeField]private GameObject enemyrange2;
    [SerializeField]private GameObject enemymelee1;
    [SerializeField]private GameObject enemymelee2;
    [SerializeField]private GameObject enemymelee3;
    [SerializeField]private GameObject enemydeck;
    [SerializeField]private GameObject Turnsystem;

    private TurnSystem turn;
    private EnemyDeck deck;

    // Start is called before the first frame update
    void Start()
    {
        turn = Turnsystem.GetComponent<TurnSystem>();
        deck = enemydeck.GetComponent<EnemyDeck>();


        TurnSystem.OnEndTurn += handleOnEndTurn;

    }

    // Update is called once per frame
    void Update()
    {
        
        

    }
    private void ChooseRangeCard()
    {
        
        GameObject chosencard;
        if (EnemyCardsinHand.Count > 0)
        {
            if (EnemyCardsinHand[0] != null)
            {
                chosencard = EnemyCardsinHand[0];
                EnemyCardsinHand.RemoveAt(0);
                movedrangecard = chosencard;
                
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
            EnemyCardsinRanged.Add(movedrangecard);
            Debug.Log("ranfe1");

        }
        
        else if ((number > 3 || isgood == true) && enemyrange2.transform.childCount == 0)
        {
            
            movedrangecard.transform.SetParent(enemyrange2.transform);
            movedrangecard.transform.localPosition = new Vector3(0, 0, 0);
            EnemyCardsinRanged.Add(movedrangecard);
            Debug.Log("range2");
        }
        else
        {
            Debug.Log("skill issue");
        }
    }

    private void ChooseMeleeCard()
    {
        int number = Randomizer(1, 2);
        int number2 = Randomizer(1, 2);
        int spot1 = 0;
        int spot2 = 1;
        
        GameObject chosencard;
        if (EnemyCardsinRanged != null && EnemyCardsinRanged.Count > 0)
        {
            if (number == 1)
            {
                chosencard = EnemyCardsinRanged[spot1];
                EnemyCardsinRanged.RemoveAt(spot1);
                movedmeleecard = chosencard;
                
            } else if (number == 2)
            {
                chosencard = EnemyCardsinRanged[spot2];
                EnemyCardsinRanged.RemoveAt(spot2);
                movedmeleecard = chosencard;
                
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
    private void MoveCardToMelee(bool isgood)
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
            EnemyCardsinMelee.Add(movedmeleecard);
            Debug.Log("meelee1");
        }
        else if ((number > 2 && isgood == true) && number < 4 && enemymelee2.transform.childCount == 0)
        {
            movedmeleecard.transform.SetParent(enemymelee2.transform);
            movedmeleecard.transform.localPosition = new Vector3(0, 0, 0);
            EnemyCardsinMelee.Add(movedmeleecard);
            Debug.Log("meelee2");
        }
        else if (number > 4 && enemymelee3.transform.childCount == 0)
        {
            movedmeleecard.transform.SetParent(enemymelee3.transform);
            movedmeleecard.transform.localPosition = new Vector3(0, 0, 0);
            EnemyCardsinMelee.Add(movedmeleecard);
            Debug.Log("meelee3");
        }
        else
        {
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
                MoveCardToRange(true);
            }
            else {
                ChooseMeleeCard();
                MoveCardToMelee(true);
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
