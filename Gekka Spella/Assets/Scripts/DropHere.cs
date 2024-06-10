using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropHere : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{


    public void OnPointerEnter(PointerEventData eventData)
    {

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (transform.childCount == 0)
        {
            if (d != null && this.name == "PlayerRangePlace1" && d.ismelee == false || 
                this.name == "PlayerRangePlace2" && 
                d.ismelee == false)
            {
                d.parentToReturnTo = this.transform;
                d.ismelee = false;
            }
            else if (d != null && (d.tag == "PlayerRangeCard1" ||
                d.tag == "PlayerRangeCard2") && (this.name == "PlayerMeleePlace1" || 
                this.name == "PlayerMeleePlace2" || 
                this.name == "PlayerMeleePlace3")
                ) 
            { 
                d.parentToReturnTo = this.transform;
                d.ismelee = true;
            }
        }
        if (this.name == "PlayerGraveyard")
        {
            d.parentToReturnTo = this.transform;
        }

    }
}
