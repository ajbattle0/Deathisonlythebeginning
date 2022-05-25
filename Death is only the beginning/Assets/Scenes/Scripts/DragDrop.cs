using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragDrop : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    RectTransform rectTransform;
    public Canvas myCanvas;
    CanvasGroup canvasGroup;
    CanvasGroup parentCanvasGroup;
    public int puzzlePieceNumber;
    Vector2 pos;
    public Vector3 prevTrasformPos;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        parentCanvasGroup = transform.parent.GetComponent<CanvasGroup>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        prevTrasformPos = transform.position;
    }

    public void OnDrag(PointerEventData eventData)
    {
        //RectTransformUtility.ScreenPointToLocalPointInRectangle(myCanvas.transform as RectTransform, Input.mousePosition, myCanvas.worldCamera, out pos);
        //transform.position = myCanvas.transform.TransformPoint(pos);
        rectTransform.anchoredPosition += eventData.delta / myCanvas.scaleFactor;
        canvasGroup.alpha = 0.6f;
        parentCanvasGroup.blocksRaycasts = false;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        canvasGroup.alpha = 1f;
        parentCanvasGroup.blocksRaycasts = true;
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("mouseButtonDown");
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("mouseButtonUp");
    }

    
}
