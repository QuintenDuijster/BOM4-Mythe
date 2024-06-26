using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cardback : MonoBehaviour
{
    public GameObject cardback;

    public void TurnCard(bool up) {
        if (up == false)
        {
            cardback.SetActive(false);
        }
        else {
            cardback.SetActive(true);
        }
    }
}