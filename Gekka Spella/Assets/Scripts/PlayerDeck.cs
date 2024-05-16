using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeck : MonoBehaviour
{
    public List<Card> container = new List<Card>();
    public Card[] cardTypes = new Card[20];
    public int x;
    public int deckSize = 10;
    public List<Card> cards = new List<Card>();
    public GameObject CardToHand;
    void Start()
    {
<<<<<<< Updated upstream
        deckSize = 20;
        //Psychedeck.Count = deckSize;
=======
   
      
        for (int i = 0; i < deckSize; i++) { 
>>>>>>> Stashed changes
        
            CreateCard(0);
        }
        

    }

    void Update()
    {

    }
    public void CreateCard(int cardIndex)
    {
        Card card = new Card();
        card.Name = cardTypes[cardIndex].Name;
        card.Mana = cardTypes[cardIndex].Mana;
        card.Power = cardTypes[cardIndex].Power;
        card.Health = cardTypes[cardIndex].Health;
        card.Image = cardTypes[cardIndex].Image;

        cards.Add(card);


    }
    public void Shuffle()
    {
        for (int i = 0; i < deckSize; i++)
        {
            int randomIndex = Random.Range(0, deckSize-1);
            container[0] = cards[randomIndex];
        }
    }
    IEnumerator StartGame()
    {
        for (int i = 0; i <= 5; i++)
        {
            yield return new WaitForSeconds(1);

            //NEW
            Instantiate(CardToHand, transform.position, transform.rotation);
        }
    }

}
