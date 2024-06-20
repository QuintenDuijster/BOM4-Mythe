using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
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

        //if (d != null && (this.name == "EnemyRangePlace1" || this.name == "EnemyRangePlace2") 
        //    && d.ismelee == false && this.tag == "EnemyCard")
        //{
        //    Debug.Log("mamam");
        //    d.parentToReturnTo = this.transform;
        //    d.ismelee = false;
        //}
        //else if (d != null && (d.tag == "EnemyRangeCard1" ||
        //    d.tag == "EnemyRangeCard2") && (this.name == "EnemyMeleePlace1" ||
        //    this.name == "EnemyMeleePlace2" ||
        //    this.name == "EnemyMeleePlace3")
        //    )
        //{
        //    d.parentToReturnTo = this.transform;
        //    d.ismelee = true;

        //}
        //if (this.name == "EnemyGraveyard" && this.tag == "EnemyCard")
        //{
        //    d.parentToReturnTo = this.transform;
        //}

    }

}

