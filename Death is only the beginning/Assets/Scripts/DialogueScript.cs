using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogueScript : MonoBehaviour
{
    public DialogueRunner Chat;
    public bool IsInDialog;
    public GameObject Dogcollar;
    public float CollarTime;
    public bool CollarTimerOn;
    public float CollarTime2;
    public bool CollarTimerOn2;
    public float Endgametime;
    public bool Endtimer;
    public GameObject ChatScreen;
    public GameObject Dogcollar2;
    public GameObject FinalPolaroid;
    public GameObject EndButton;
    public GameObject hoodUp;
    public GameObject hoodDown;
    public GameObject sticksNoCollar;
    public GameObject sticksCollar;

    public bool isInIntro;

    // Start is called before the first frame update
    void Start()
    {
        IsInDialog = false;
        CollarTime = 0;
        CollarTimerOn = false;
    }

    // Update is called once per frame
    

    [YarnCommand("displayBlankCollarImage")]
    public void DisplayBlankCollarImage()
    {
        Dogcollar.SetActive(true);
        Debug.Log("introduction text finished");
        StartCoroutine(DisplayImage(Dogcollar));

    }
    [YarnCommand("displayCollarWithName")]
    public void DisplayBlankCollarwithnameImage()
    {
        Dogcollar2.SetActive(true);
        Debug.Log("showing dog collar w name");
        StartCoroutine(DisplayImage(Dogcollar2));
    }
    [YarnCommand("displayFinalPolaroid")]
    public void DisplayFinalPolaroid()
    {
        FinalPolaroid.SetActive(true);
        Debug.Log("final polaroid shows");
        StartCoroutine(DisplayImage(EndButton, true));
    }
    IEnumerator DisplayImage(GameObject image, bool final =false)
    {
        yield return new WaitForSeconds(5);
        if (final)
        {
            image.SetActive(true);
        }
        else
        {
            image.SetActive(false);
        }
        
    }
    [YarnCommand("changeScene")]
    public void ChangeScene()
    {
        StartCoroutine(ChangeSceneCoro());
    }
    IEnumerator ChangeSceneCoro()
    {
        yield return new WaitForSeconds(1);
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (SceneManager.sceneCountInBuildSettings > nextSceneIndex)
        {
            SceneManager.LoadScene(nextSceneIndex);

        }
        else
        {
            Debug.Log(nextSceneIndex);
            Debug.LogError("sceneNotFound");
        }
    }

[YarnCommand("moveBoat")]
    public void MoveBoat()
    {
        if (isInIntro)
        {
            GameEvents.BoatStart();
            isInIntro = false;
        }
        else
        {
            GameEvents.BoatDeparter();
        }
        StartCoroutine(arriveAtLocation());



        Debug.Log("BOAT IS MOVING");
        //ChatScreen.SetActive(false);
    }
    IEnumerator arriveAtLocation()
    {
        yield return new WaitForSeconds(5);
        GameEvents.BoatArrival();
    }
      
        [YarnCommand("stopBoat")]
    public void StopBoat()
    {
       //GameEvents.BoatStop();
        Debug.Log("BOAT IS NOT MOVING");
        //ChatScreen.SetActive(false);  
    }
    [YarnCommand("startPuzzle1")]
    public void StartPuzzle1()
    {
        GameEvents.OpenPuzzle();
    }

    [YarnCommand("startPuzzle2")]
    public void StartPuzzle2()
    {
        GameEvents.OpenPuzzle();
    }

    [YarnCommand("startPuzzle3")]
    public void StartPuzzle3()
    {
        GameEvents.OpenPuzzle();
    }

    

    public void PlayIntroductionText()
    {
        ChatScreen.SetActive(true);
        if (IsInDialog == false)
        {
            Chat.StartDialogue("Intro");
        }
    }
    //SCENE 1
    public void PlayLocation1StartText()
    {
        Debug.Log("HI");
        ChatScreen.SetActive(true);
        if (IsInDialog == false)
        {
            Chat.StartDialogue("Location1Start");
            
        }
    }

    public void PlayLocation1EndText()
    {
        ChatScreen.SetActive(true);
        if (IsInDialog == false)
        {
            Chat.StartDialogue("Location1End");
        }
    }
    //SCENE 2
    public void PlayLocation2StartText()
    {
        ChatScreen.SetActive(true);
        if (IsInDialog == false)
        {
            Chat.StartDialogue("Location2Start");
        }
    }

    public void PlayLocation2EndText()
    {
        ChatScreen.SetActive(true);
        if (IsInDialog == false)
        {
            Chat.StartDialogue("Location2End");
        }
    }
    //SCENE 3
    public void PlayLocation3StartText()
    {
        ChatScreen.SetActive(true);
        if (IsInDialog == false)
        {
            Chat.StartDialogue("Location3Start");
        }
    }

    public void PlayLocation3EndText()
    {
        ChatScreen.SetActive(true);
        if (IsInDialog == false)
        {
            Chat.StartDialogue("Location3End");
        }
    }
    //SCENE 4
    public void PlayLocation4StartText()
    {
        StartCoroutine(QuickFadeIn(hoodUp, hoodDown));
        ChatScreen.SetActive(true);

        if (IsInDialog == false)
        {
            Chat.StartDialogue("Location4Start");
        }
    }
    IEnumerator QuickFadeIn(GameObject firstPic, GameObject secondPic)
    {
        Color firstPicCol = firstPic.GetComponent<SpriteRenderer>().color;
        Color SecondPicCol = secondPic.GetComponent<SpriteRenderer>().color;
        float fadeDuration = 0.3f;
        float elapsedTime = 0f;
        while (elapsedTime < fadeDuration)
        {
            elapsedTime += Time.deltaTime;
            firstPicCol.a = Mathf.Lerp(1f, 0f, elapsedTime / fadeDuration);
            SecondPicCol.a = Mathf.Lerp(0f, 1f, elapsedTime / fadeDuration);
            firstPic.GetComponent<SpriteRenderer>().color = firstPicCol;
            secondPic.GetComponent<SpriteRenderer>().color = SecondPicCol;
            yield return null;
        }
    }
    
}
