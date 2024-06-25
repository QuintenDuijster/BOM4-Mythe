using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropHere : MonoBehaviour, IDropHandler, IPointerEnterHandler, IPointerExitHandler
{

    internal int childcount;
    void Update()
    {
        childcount = transform.childCount;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {

    }
    public void OnPointerExit(PointerEventData eventData)
    {
        
    }

    public void OnDrop(PointerEventData eventData)
    {
        Draggable d = eventData.pointerDrag.GetComponent<Draggable>();
        if (childcount == 0)
        {
            if (d != null && this.name == "PlayerRangePlace1" && d.ismelee == false ||
                this.name == "PlayerRangePlace2" &&
                d.ismelee == false)
                
            {
                d.parentToReturnTo = this.transform;
                d.ismelee = false;
                
            }
            else if (d != null && (d.tag == "PlayerRangeCard1" || d.tag == "PlayerRangeCard2") && (
                this.name == "PlayerMeleePlace1" && d.turnsexisted >= 1 || 
                this.name == "PlayerMeleePlace2" && d.turnsexisted >= 1 || 
                this.name == "PlayerMeleePlace3" && d.turnsexisted >= 1)
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

