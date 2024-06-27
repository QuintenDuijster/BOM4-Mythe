using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DisplayCard : MonoBehaviour
{
    public TextMeshProUGUI NameText;
    public TextMeshProUGUI PowerText;
    public TextMeshProUGUI HealthText;
    public TextMeshProUGUI ManaText;
    public Image image;
    public bool canAttack = true;

    private CardSettings cardType;

    internal int health;
    internal int mana;
    internal int power;
    private void Update()
    {
        HealthText.text = health.ToString();
        PowerText.text = power.ToString();
        ManaText.text = mana.ToString();
    }

    public void Init(CardSettings cardType) {

       this.cardType = cardType;

        NameText.text = cardType.MName;
        power = cardType.Power;
        health = cardType.Health;
        mana = cardType.ManaCost;
        image.sprite = cardType.Image;
    }

    public void Damage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
			if (transform.tag.Contains("Enemy"))
			{
				EnemyAI ai = GameObject.FindGameObjectWithTag("EnemyAi").GetComponent<EnemyAI>();

				if (transform.tag.Contains("Melee"))
				{
                    ai.EnemyCardsinMelee.Remove(transform.gameObject);
                }
                else
                {
					ai.EnemyCardsinRanged.Remove(transform.gameObject);
				}
			}

			Destroy(gameObject);
        }
    }
}