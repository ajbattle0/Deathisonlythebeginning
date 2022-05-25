using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzleController : MonoBehaviour
{
    [SerializeField] GameObject puzzleBoxes;
    [SerializeField] GameObject dragDropCatcher;
    [SerializeField] CanvasGroup puzzleCanvasGroup;

    private void OnEnable()
    {
        GameEvents.OnOpenPuzzle += TransitionPuzzleIIn;
        GameEvents.OnClosePuzzle += TransitionPuzzleOut;

    }
    private void OnDisable()
    {
        GameEvents.OnOpenPuzzle -= TransitionPuzzleIIn;
        GameEvents.OnClosePuzzle -= TransitionPuzzleOut;

    }

    private void TransitionPuzzleOut()
    {
        
        StartCoroutine(Fade());
    }

    void TransitionPuzzleIIn()
    {
        puzzleBoxes.SetActive(true);
        dragDropCatcher.SetActive(true);
        StartCoroutine(Fade());
        
    }
    IEnumerator Fade()
    {
         
        if(puzzleCanvasGroup.alpha == 1)
        {
            while(puzzleCanvasGroup.alpha > 0)
            {
                puzzleCanvasGroup.alpha -= Time.deltaTime;
                yield return null;
            }
            puzzleCanvasGroup.alpha = 0;
            puzzleBoxes.SetActive(false);
            dragDropCatcher.SetActive(false);
        }
        else
        {
            while (puzzleCanvasGroup.alpha < 1)
            {

                puzzleCanvasGroup.alpha += Time.deltaTime;
                yield return null;
            }
            puzzleCanvasGroup.alpha = 1;
        }
    }

}
