using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class puzzleController : MonoBehaviour
{
    [SerializeField] GameObject puzzleBoxes;
    [SerializeField] GameObject dragDropCatcher;
    [SerializeField] CanvasGroup puzzleCanvasGroup;
    [SerializeField] DialogueScript dialogueScript;
    int scene;

    [SerializeField] Canvas UiCanvas;

    public void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
    }
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
        yield return new WaitForSeconds(2);
        if(puzzleCanvasGroup.alpha == 1)
        {
            puzzleBoxes.SetActive(false);
            dragDropCatcher.SetActive(false);
            while (puzzleCanvasGroup.alpha > 0)
            {
                puzzleCanvasGroup.alpha -= Time.deltaTime;
                yield return null;
            }
            puzzleCanvasGroup.alpha = 0;
            
            yield return new WaitForSeconds(1);
            WhichScene();

        }
        else
        {
            while (puzzleCanvasGroup.alpha < 1)
            {

                puzzleCanvasGroup.alpha += Time.deltaTime;
                yield return null;
            }
            puzzleCanvasGroup.alpha = 1;
            GameEvents.ResetParallax();
        }
    }
    void WhichScene()
    {
        switch (scene)
        {
            case 1:
                dialogueScript.PlayLocation1EndText();
                Debug.Log("1");
                break;
            case 2:
                dialogueScript.PlayLocation2EndText();
                Debug.Log("2");
                break;
            case 3:
                dialogueScript.PlayLocation3EndText();
                Debug.Log("3");
                break;
            
        }
    }

}
