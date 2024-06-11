using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnButton : MonoBehaviour
{

    public bool playerTurn = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnButtonClick()
    {
        if (playerTurn = true)
        {
            playerTurn = false;
            Console.WriteLine("playerTurn: false");
        }
        else
        {
            playerTurn = true;
            Console.WriteLine("playerTurn: true");
        }
    }
}
