using UnityEngine;

public class CardFieldChecker : MonoBehaviour
{
    public GameObject[] cardFields; // Array to hold the card fields to check
    public TurnSystem turnSystem; // Reference to the TurnSystem script

    public void CheckCardFieldsAndUpdateMana()
    {
        int cardsWithChildrenCount = 0; // Reset the counter

        foreach (GameObject field in cardFields)
        {
            if (field.transform.childCount > 0)
            {
                cardsWithChildrenCount++;
            }
        }

        // Update the mana system with the new count
        turnSystem.AddMana(cardsWithChildrenCount);
    }
}
