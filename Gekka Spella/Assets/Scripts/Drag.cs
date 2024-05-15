using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class Drag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{
    Vector2 relativeStartPosition;
    public Image image;
    [HideInInspector] public Transform parentToReturnTo = null;
    public void OnBeginDrag(PointerEventData eventData)
    {
        parentToReturnTo = this.transform.parent;
        this.transform.SetParent(this.transform.parent.parent);
        relativeStartPosition = transform.position - Input.mousePosition;
        image.raycastTarget = false;
    }
    public void OnDrag(PointerEventData eventData)
    {
        this.transform.position = eventData.position + relativeStartPosition;
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        this.transform.SetParent(parentToReturnTo);
        image.raycastTarget = true;
    }
}
