using UnityEngine;

public class ClickToAttack : MonoBehaviour
{
    public void onClick(GameObject cardPlace)
    {
        GameObject card = GameObject.FindGameObjectWithTag(cardPlace.name.Replace("Place", "Card"));
        GameObject enemyCard = GameObject.FindGameObjectWithTag(cardPlace.name.Replace("Player", "Enemy").Replace("Place", "Card"));
        EnemyDeck enemyDeck = GameObject.FindGameObjectWithTag("EnemyDeck").GetComponent<EnemyDeck>();

        if (card != null) 
        {
            DisplayCard cardData = card.GetComponent<DisplayCard>();
            if (cardData == null)
            {
                return;
            }

            if (!cardData.canAttack)
            {
                return;
            }

            cardData.canAttack = false;

            if (cardPlace.name is "PlayerRangePlace1" or "PlayerRangePlace2")
            {
                GameObject enemyCard1;
                try
                {
                    enemyCard1 = GameObject.FindGameObjectWithTag("EnemyMeleePlace1");
                }
                catch
                {
                    enemyCard1 = null;
                }
                if (enemyCard1 != null)
                {
                    DisplayCard enemyCard1Data = enemyCard1.GetComponent<DisplayCard>();
                    enemyCard1Data.Damage(cardData.power);
                }

                GameObject enemyCard2;
                try
                {
                    enemyCard2 = GameObject.FindGameObjectWithTag("EnemyMeleePlace2");
                }
                catch
                {
                    enemyCard2 = null;
                }
                if (enemyCard2 != null)
                {
                    DisplayCard enemyCard2Data = enemyCard2.GetComponent<DisplayCard>();
                    enemyCard2Data.Damage(cardData.power);
                }

                GameObject enemyCard3;
                try
                {
                    enemyCard3 = GameObject.FindGameObjectWithTag("EnemyMeleePlace3");
                }
                catch
                {
                    enemyCard3 = null;
                }
                if (enemyCard3 != null)
                {
                    DisplayCard enemyCard3Data = enemyCard3.GetComponent<DisplayCard>();
                    enemyCard3Data.Damage(cardData.power);
                }
            }
            else if (enemyCard != null)
            {
                DisplayCard enemyData = enemyCard.GetComponent<DisplayCard>();
                enemyData.Damage(cardData.power); 
            }
            else
            {
                enemyDeck.Damage(cardData.power);
            }
        }
    }
}
