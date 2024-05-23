using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Collections.LowLevel.Unsafe;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCard : MonoBehaviour
{
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI PowerText;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI ManaText;
    public Image image;

    private CardSettings _cardType; 

    public void Init(CardSettings cardType) {

        _cardType = cardType;

        ShowStats();
    }
  
   void ShowStats()
    {
       
        NameText.text = _cardType.MName;
        PowerText.text = _cardType.Power.ToString();
        HealthText.text = _cardType.Health.ToString();
        ManaText.text = _cardType.ManaCost.ToString();
        image.sprite = _cardType.Image; 
    }
}
