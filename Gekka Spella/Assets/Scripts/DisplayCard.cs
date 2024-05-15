using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCard : MonoBehaviour
{
    public List<Card> displayCard = new List<Card>();
    public int displayId;

    public int id;
    public string cardName;
    public int cost;
    public int power;
    public int health;
    private Sprite spriteimage;


    public TextMeshProUGUI NameText;
    public TextMeshProUGUI PowerText;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI ManaText;
    public Image image;


    public Card[] cards;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        CreateCard(id);
    }
    public void CreateCard(int cardIndex)
    {
        id = displayCard[0].Id;
        cardName = displayCard[0].Name;
        cost = displayCard[0].Mana;
        power = displayCard[0].Mana;
        health = displayCard[0].Mana;
        spriteimage = displayCard[0].Image;

        NameText.text = cards[cardIndex].Name;
        PowerText.text = cards[cardIndex].Power.ToString();
        HealthText.text = cards[cardIndex].Health.ToString();
        ManaText.text = cards[cardIndex].Mana.ToString();
        image.sprite = cards[cardIndex].Image;
    }
}
