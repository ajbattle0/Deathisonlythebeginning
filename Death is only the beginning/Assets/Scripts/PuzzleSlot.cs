using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PuzzleSlot : MonoBehaviour, IDropHandler
{
    public int SlotNumber;
    public bool correct;
    public GameObject currentPuzzlePiece;
    public GameObject WinImage;
    
    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
            currentPuzzlePiece.transform.position = eventData.pointerDrag.GetComponent<DragDrop>().prevTrasformPos;
            eventData.pointerDrag.GetComponent<DragDrop>().prevTrasformPos = eventData.pointerDrag.transform.position;
            var newPuzzlePiece = eventData.pointerDrag.gameObject;
            var allPuzzleSlots = transform.parent.GetComponentsInChildren<PuzzleSlot>();
            var prePuzzleSlot = this;
            for (int i = 0; i < allPuzzleSlots.Length; i++)
            {
                if (allPuzzleSlots[i].currentPuzzlePiece == newPuzzlePiece)
                {
                    allPuzzleSlots[i].currentPuzzlePiece = this.currentPuzzlePiece;
                    prePuzzleSlot = allPuzzleSlots[i];
                    break;
                }
            }
            currentPuzzlePiece = newPuzzlePiece;
            if (currentPuzzlePiece.GetComponent<DragDrop>().puzzlePieceNumber == SlotNumber)
            {
                correct = true;
            }
            else
            {
                correct = false;
            }
            if (prePuzzleSlot != this && prePuzzleSlot.currentPuzzlePiece.GetComponent<DragDrop>().puzzlePieceNumber == prePuzzleSlot.SlotNumber)
            {
                prePuzzleSlot.correct = true;
            }
            else if (prePuzzleSlot != this)
            {
                prePuzzleSlot.correct = false;
            }
            int numerCorrect = 0;
            for (int i = 0; i < allPuzzleSlots.Length; i++)
            {
                if (allPuzzleSlots[i].correct == true)
                {
                    numerCorrect++;
                }
            }
            if(numerCorrect == allPuzzleSlots.Length)
            {
                WinImage.SetActive(true);

                GameEvents.ClosePuzzle();
            }
        }
    }

    
}
