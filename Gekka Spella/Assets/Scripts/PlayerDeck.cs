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
    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;


    void Start()
    {
        Shuffle(deck);

        StartCoroutine(StartGame());
    }
    private void Update()
    {
        DeckVisuals();
    }
    public void DrawCard(int cardIndex)
    {   
        var NewCard = Instantiate(CardToHand);

        
        NewCard.transform.position = new Vector3(-100, 0, 0);

        cardsInHand.Add(NewCard);

        DisplayCard dcs = NewCard.GetComponent<DisplayCard>();
        dcs.Init(runDeck[cardIndex]);

        runDeck.RemoveAt(cardIndex);
    }

    public void Shuffle(List<CardSettings> deck)
    {
        runDeck = deck.OrderBy(x => Random.value).ToList();
    }

    IEnumerator StartGame()
    {
        for (int i = 0; i < beginningHand; i++)
        {
            DrawCard(0);//use 0 only draw the top card
            yield return new WaitForSeconds(1);
        }
    }
    public void DeckVisuals()
    {
        if (runDeck.Count < 20)
        {
            cardInDeck1.SetActive(false);
        }
        if (runDeck.Count < 13)
        {
            cardInDeck2.SetActive(false);
        }
        if (runDeck.Count < 7)
        {
            cardInDeck3.SetActive(false);
        }
        if (runDeck.Count < 1)
        {
            cardInDeck4.SetActive(false);
        }
    }
}
