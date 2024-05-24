using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerDeck : MonoBehaviour
{

    public GameObject CardPrefab;
    public GameObject Hand;
    //public List<CardSettings> container = new List<CardSettings>();
    [SerializeField]private List<CardSettings> deck;//don't alter/touch
    List<CardSettings> runDeck = new List<CardSettings>();
    public int beginningHand = 0;
   // public int deckSize;
    private List<GameObject> cardsInHand = new List<GameObject>();
    public GameObject CardToHand;
    void Start()
    {
        //beginningHand = 5;
        Shuffle(deck);

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
        dcs.Init(runDeck[cardIndex]);

        runDeck.RemoveAt(cardIndex);
        /*
        Debug.Log("!!");
        foreach (CardSettings settings in deck) {
            Debug.Log(settings.MName);
        }
       

        */
        

        //NewCard.GetComponent<CardHolder>().LoadCardData(CardData);
    }

    public void Shuffle(List<CardSettings> deck)
    {
        runDeck = deck.OrderBy(x => Random.value).ToList();



        ////Debug.Log("deck count " + deck.Count);
        //int random = Random.Range(0, deck.Count - 1);

        ////Debug.Log("random" + random);

        //CardSettings toSwap = deck[random];
        //tempList.Add(toSwap);
        //deck.RemoveAt(random);


        //if (deck.Count > 0)
        //{
        //    Shuffle(deck);

        //}
        //else
        //{
        //    //Debug.Log("templist count " + tempList.Count);

        //    deck = new List<CardSettings>();
        //    foreach (CardSettings s in tempList)
        //    {
        //        deck.Add(s);
        //    }
        //    tempList = null;
        //    tempList = new List<CardSettings>();

        //}
    }


    /* public void Shuffle()
      {
          for (int i = 0; i < deckSize; i++)
          {
              int randomIndex = Random.Range(0, deckSize-1);
              container[0] = deck[randomIndex];
          }
      }*/


    IEnumerator StartGame()
    {
        for (int i = 0; i < beginningHand; i++)
        {
            DrawCard(0);//use 0 only draw the top card
            yield return new WaitForSeconds(1);
        }
    }
}
