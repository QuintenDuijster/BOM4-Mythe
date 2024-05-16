using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCard : MonoBehaviour
{
    // Mogelijke kaarttypes
    



    public TextMeshProUGUI NameText;
    public TextMeshProUGUI PowerText;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI ManaText;
    public Image image;

    // kaarten die dan gemaakt woorden
  
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        ShowStats();
    }
   void ShowStats()
    {
      /*  NameText.text = PlayerDeck.cards[PlayerDeck.cards.Count - 1].Name;
        PowerText.text = PlayerDeck.cards[PlayerDeck.cards.Count - 1].Power.ToString();
        HealthText.text = PlayerDeck.cards[PlayerDeck.cards.Count - 1].Health.ToString();
        ManaText.text = PlayerDeck.cards[PlayerDeck.cards.Count - 1].Mana.ToString();
        image.sprite = PlayerDeck.cards[PlayerDeck.cards.Count - 1].Image; */
    }
}
