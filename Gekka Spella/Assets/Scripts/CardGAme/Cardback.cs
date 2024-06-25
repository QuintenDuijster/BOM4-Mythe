using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Cardback : MonoBehaviour
{
    public GameObject cardback;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
     
    }


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
