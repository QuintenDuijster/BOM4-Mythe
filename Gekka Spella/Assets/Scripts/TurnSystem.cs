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
    public int yourOponentTurn;
    public TextMeshProUGUI turnText;
    public int maxMana;
    public int currentMana;
    public TextMeshProUGUI manaText;



    void Start()
    {
        isYourTurn = true;
        yourTurn = 1;
        yourOponentTurn = 0;

        maxMana = 10;
        currentMana = 5;
    }

    void Update()
    {
        if(isYourTurn == true)
        {
            turnText.text = "your turn";
        }
        else
        {
            turnText.text = "your opponent turn";
        }

        manaText.text = currentMana + "/" + maxMana;
    }

    public void EndYourTurn()
    {
        if (isYourTurn == true)
        {
            isYourTurn = false;
            yourOponentTurn += 1;
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
