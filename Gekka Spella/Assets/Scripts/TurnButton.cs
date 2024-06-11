using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnButton : MonoBehaviour
{
    [SerializeField] public bool isPlayerTurn = true;

    public void TogglePlayerTurn()
    {

        isPlayerTurn = !isPlayerTurn;

        if (isPlayerTurn == false)
        {
            Console.WriteLine("false");
        }
        else { Console.WriteLine("true"); }
    }
}
