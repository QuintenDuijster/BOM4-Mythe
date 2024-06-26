using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TurnSystem : MonoBehaviour
{
    public static List<GameObject> cardsInPlay = new List<GameObject>();

    public bool isYourTurn;
    public int yourTurn;
    public int yourOpponentTurn;
    
    public GameObject playerturnimage;
    public GameObject enemyturnimage;
    public int maxMana;
    public int currentMana;
    public TextMeshProUGUI manaText;

    public static Action OnEndTurn;

    void Start()
    {
        isYourTurn = true;
        yourTurn = 1;
        yourOpponentTurn = 0;

        maxMana = 10;
        currentMana = 5;
    }

    void Update()
    {
        if(isYourTurn == true)
        {
            enemyturnimage.SetActive(false);
            playerturnimage.SetActive(true);
        }
        else
        {
            playerturnimage.SetActive(false);
            enemyturnimage.SetActive(true);
        }

        manaText.text = currentMana + "/" + maxMana;
    }

    public void EndYourTurn()
    {
        if (isYourTurn == true)
        {
            isYourTurn = false;
            yourOpponentTurn += 1;

            OnEndTurn?.Invoke();
        }

        foreach (GameObject card in cardsInPlay)
        {
            try
            {
                DisplayCard cardData = card.GetComponent<DisplayCard>();
                if (cardData != null)
                {
                    cardData.canAttack = true;
                }
            }
            catch
            {
                Debug.Log("what");
            }
        }
    }

    public void EndyourOponentTurn()
    {
        if (isYourTurn == false)
        {
            isYourTurn = true;
            yourTurn += 1;

            if (currentMana < maxMana)
            {
                FindObjectOfType<CardFieldChecker>().CheckCardFieldsAndUpdateMana();
            }

            ResetEnemyAttack();
        }
    }

    private void ResetEnemyAttack()
    {

    }

    // Method to add mana
    public void AddMana(int amount)
    {
        currentMana += amount;
        if (currentMana < 0)
        {
            currentMana = 0;
        }

        if (currentMana > maxMana)
        {
            currentMana = maxMana;
        }
    }
}