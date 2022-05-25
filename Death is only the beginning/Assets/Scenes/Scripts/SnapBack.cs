using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SnapBack : MonoBehaviour, IDropHandler
{
    
    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("droped");
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.transform.position = eventData.pointerDrag.GetComponent<DragDrop>().prevTrasformPos;
        }
    }


}
