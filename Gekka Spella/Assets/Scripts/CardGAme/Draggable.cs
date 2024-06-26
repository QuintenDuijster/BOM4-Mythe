using UnityEngine;
using UnityEngine.EventSystems;

public class Draggable : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    DropHere dropscript;
    
    public Transform parentToReturnTo = null;
    internal int turnsexisted = 0;
    internal bool ismelee;
    
    void Start()
    {
        dropscript = GetComponentInParent<DropHere>();
        TurnSystem.OnEndTurn += IncrementTurnExisted;
    }
    void Update() 
    { 
        if (tag == "PlayerGraveCard" ||  tag == "EnemyGraveCard")
        {
            Destroy(this);
        }
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
            parentToReturnTo = transform.parent;
            transform.SetParent(transform.parent.parent);

            GetComponent<CanvasGroup>().blocksRaycasts = false;
    }

    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(parentToReturnTo);

        CanvasGroup canvasGroup = GetComponent<CanvasGroup>();
        canvasGroup.blocksRaycasts = true;
        string parentname;
        parentname = transform.parent.name;
        switch (parentname)
        {
            case "PlayerMeleePlace1":
            case "PlayerMeleePlace2":
            case "PlayerMeleePlace3":
            case "PlayerRangePlace1":
            case "PlayerRangePlace2":
            case "EnemyMeleePlace1":
            case "EnemyMeleePlace2":
            case "EnemyMeleePlace3":
            case "EnemyRangePlace1":
            case "EnemyRangePlace2":
                TurnSystem.cardsInPlay.Add(transform.gameObject);
                transform.tag = parentname.Replace("Place", "Card");
                break;
            case "PlayerGraveyard":
            case "EnemyGraveyard":
                TurnSystem.cardsInPlay.Remove(transform.gameObject);
                transform.gameObject.tag = "PlayerGraveCard";
                break;
        }
    }

    public void IncrementTurnExisted()
    {
        if (transform.tag == "PlayerRangeCard1" 
            || transform.tag == "PlayerRangeCard2" 
            || transform.tag == "EnemyRangeCard1" 
            || transform.tag == "EnemyRangeCard2") 
        { 
            turnsexisted++; 
        }
    }
}