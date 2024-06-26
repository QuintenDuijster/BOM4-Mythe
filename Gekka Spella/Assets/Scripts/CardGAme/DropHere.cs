using UnityEngine;
using UnityEngine.EventSystems;

public class DropHere : MonoBehaviour, IDropHandler
{
    private TurnSystem turnSystem;
    internal int childcount;

    void Update()
    {
        turnSystem = GameObject.FindGameObjectWithTag("TurnSystem").GetComponent<TurnSystem>();
        childcount = transform.childCount;
    }

    public void OnDrop(PointerEventData eventData)
    {
        Draggable draggable = eventData.pointerDrag.GetComponent<Draggable>();
        if (childcount == 0)
        {
            if (draggable != null && turnSystem.currentMana > 1 &&
                (name == "PlayerRangePlace1" && draggable.ismelee == false) ||
                (name == "PlayerRangePlace2" && draggable.ismelee == false))

            {
                draggable.parentToReturnTo = transform;
                draggable.ismelee = false;
                turnSystem.AddMana(-2);
            }
            else if (draggable != null 
                && turnSystem.currentMana > 1 && (
                name == "PlayerMeleePlace1" ||
                name == "PlayerMeleePlace2" ||
                name == "PlayerMeleePlace3"))
            {
                draggable.parentToReturnTo = transform;
                draggable.ismelee = true;
                turnSystem.AddMana(-2);
            }
        }
        if (name == "PlayerGraveyard")
        {
            draggable.parentToReturnTo = transform;
        }
    }
}