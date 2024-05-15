using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> container = new List<Card>();
    public int x;
    public static int deckSize;
    public List<Card> Psychedeck = new List<Card>();
    public static List<Card> staticDeck = new List<Card>();
    // Start is called before the first frame update
    void Start()
    {
        deckSize = 20;
        //Psychedeck.Count = deckSize;
        
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void Shuffle()
    {
        for (int i = 0; i < deckSize; i++)
        {
            container[0] = Psychedeck[i];
            int randomIndex = Random.Range(i, deckSize);
            Psychedeck[i] = Psychedeck[randomIndex];
            Psychedeck[randomIndex] = container[0];
        }
    }

}
