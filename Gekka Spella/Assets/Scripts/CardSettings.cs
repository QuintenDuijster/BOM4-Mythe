using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

[CreateAssetMenu(fileName = "Card", menuName = "New Card")]
public class CardSettings : ScriptableObject
{
    public int Id;
    public string MName;
    public int Health;
    public int Power;
    public Sprite Image;
    public int ManaCost;



 

}