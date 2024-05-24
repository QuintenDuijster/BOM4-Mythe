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

    private CardSettings cardType; 

    public void Init(CardSettings cardType) {

       this. cardType = cardType;

        ShowStats();
    }
  
   void ShowStats()
    {
       
        NameText.text = cardType.MName;
        PowerText.text =cardType.Power.ToString();
        HealthText.text = cardType.Health.ToString();
        ManaText.text = cardType.ManaCost.ToString();
        image.sprite = cardType.Image; 
    }
}
