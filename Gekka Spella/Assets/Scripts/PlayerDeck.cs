using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerDeck : MonoBehaviour
{
    public GameObject CardPrefab;
    public GameObject Hand;
    public List<CardSettings> container = new List<CardSettings>();
    public List <CardSettings> deck = new List<CardSettings>();
    public int beginningHand;
    public int deckSize;
    public List<GameObject> cardsInHand = new List<GameObject>();
    public GameObject CardToHand;
    void Start()
    {

            
        StartCoroutine(StartGame());
    }

    void Update()
    {

    }
    public void DrawCard(int cardIndex)
    {
        /* var a = new CardHolder(cards[cardIndex]);

         var b = Instantiate(CardPrefab);
         b.GetComponent<CardToHand>().Spawn(Hand);
         var CardObject = b.AddComponent<CardHolder>();
         CardObject = a;

         CardObject.card.Mana = cardTypes[cardIndex].Mana;
         CardObject.card.Power = cardTypes[cardIndex].Power;
         CardObject.card.Health = cardTypes[cardIndex].Health;
         CardObject.card.Image = cardTypes[cardIndex].Image;

         cards.Add(CardObject.card);*/

      

        
        var NewCard = Instantiate(CardToHand);

        
        NewCard.transform.position = new Vector3(-100, 0, 0);

        cardsInHand.Add(NewCard);

        DisplayCard dcs = NewCard.GetComponent<DisplayCard>();
        dcs.Init(deck[cardIndex]);

        deck.RemoveAt(cardIndex);


        

        //NewCard.GetComponent<CardHolder>().LoadCardData(CardData);
    }
        public void Shuffle(List<CardSettings> deck)
        {
            CardSettings cardsetting = deck[Random.Range(0, deck.Count)];
            
        }

    
  /*  public void Shuffle()
    {
        for (int i = 0; i < deckSize; i++)
        {
            int randomIndex = Random.Range(0, deckSize-1);
            container[0] = deck[randomIndex];
        }
    }*/


    IEnumerator StartGame()
    {
        //Shuffle(deck);
        for (int i = 0; i < beginningHand; i++) { 
            DrawCard(i);
            yield return new WaitForSeconds(1);
        }
    }

    
}
