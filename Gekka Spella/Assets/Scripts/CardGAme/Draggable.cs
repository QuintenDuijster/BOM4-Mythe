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
                transform.gameObject.tag = "PlayerMeleeCard1";
                    break;
            case "PlayerMeleePlace2":
                transform.gameObject.tag = "PlayerMeleeCard2";
                break;
            case "PlayerMeleePlace3":
                transform.gameObject.tag = "PlayerMeleeCard3";
                break;
            case "PlayerRangePlace1":
                transform.gameObject.tag = "PlayerRangeCard1";
                break;
            case "PlayerRangePlace2":
                transform.gameObject.tag = "PlayerRangeCard2";
                break;
            case "EnemyMeleePlace1":
                transform.gameObject.tag = "EnemyMeleeCard1";
                break;
            case "EnemyMeleePlace2":
                transform.gameObject.tag = "EnemyMeleeCard2";
                break;
            case "EnemyMeleePlace3":
                transform.gameObject.tag = "EnemyMeleeCard3";
                break;
            case "EnemyRangePlace1":
                transform.gameObject.tag = "EnemyRangeCard1";
                break;
            case "EnemyRangePlace2":
                transform.gameObject.tag = "EnemyRangeCard2";
                break;
            case "PlayerGraveyard":
                transform.gameObject.tag = "PlayerGraveCard";
                break;
            case "EnemyGraveyard":
                transform.gameObject.tag = "EnemyGraveCard";
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