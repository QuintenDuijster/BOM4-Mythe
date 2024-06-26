using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyDeck : MonoBehaviour
{
    public TMP_Text healthText;
    public int health = 10;

    public GameObject CardPrefab;
    public GameObject Hand;
    //public List<CardSettings> container = new List<CardSettings>();
    [SerializeField] private List<CardSettings> deck;//don't alter/touch
    List<CardSettings> runDeck = new List<CardSettings>();
    public int beginningHand = 0;
    // public int deckSize;
    public List<GameObject> cardsInHand = new List<GameObject>();
    public GameObject CardToEnemyHand;
    public GameObject cardInDeck1;
    public GameObject cardInDeck2;
    public GameObject cardInDeck3;
    public GameObject cardInDeck4;

    void Start()
    {
        runDeck = deck.OrderBy(x => Random.value).ToList();

        StartCoroutine(StartGame());
    }
    private void Update()
    {
        healthText.text = health.ToString();

        DeckVisuals();
    }

    IEnumerator StartGame()
    {
        for (int i = 0; i < beginningHand; i++)
        {
            DrawCard(0);//use 0 only draw the top card
            yield return new WaitForSeconds(1);
        }
    }

    public void DrawCard(int cardIndex)
    {
        if (cardsInHand.Count < 5)
        {
            var NewCard = Instantiate(CardToEnemyHand);


            NewCard.transform.position = new Vector3(-100, 0, 0);

            cardsInHand.Add(NewCard);

            DisplayCard dcs = NewCard.GetComponent<DisplayCard>();
            dcs.Init(runDeck[cardIndex]);

            runDeck.RemoveAt(cardIndex);
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

    public void Damage(int damage)
    {
        health -= damage;
        if (health <= 0)
        {
            SceneManager.LoadScene(2);
        }
    }
}