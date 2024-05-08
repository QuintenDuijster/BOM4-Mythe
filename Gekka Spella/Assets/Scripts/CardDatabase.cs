using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CardDatabase : MonoBehaviour
{
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI PowerText;
    public TextMeshProUGUI HealthText;
    public Image image;
    public int id;
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
        NameText.text = cards[cardIndex].Name;
        PowerText.text = cards[cardIndex].Power.ToString();
        HealthText.text = cards[cardIndex].Health.ToString();
        image.sprite = cards[cardIndex].Image;
    }
}
