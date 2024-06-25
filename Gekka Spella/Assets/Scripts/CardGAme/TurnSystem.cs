using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditorInternal;
using UnityEngine;
using UnityEngine.UI;

public class TurnSystem : MonoBehaviour
{
    public static int cardsInPlay;


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
    }

    public void EndyourOponentTurn()
    {
        if (isYourTurn == false)
        {
            isYourTurn = true;
            yourTurn += 1;

            if (currentMana < maxMana)
            {

                //currentMana += 1;
                FindObjectOfType<CardFieldChecker>().CheckCardFieldsAndUpdateMana();
            }
        }
    }

    // Method to add mana
    public void AddMana(int amount)
    {
        currentMana += amount;
        Debug.Log("Mana added: " + amount + ", Total mana: " + currentMana);
    }
}
