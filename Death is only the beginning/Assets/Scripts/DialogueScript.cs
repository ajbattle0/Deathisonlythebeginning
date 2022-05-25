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



    // Start is called before the first frame update
    void Start()
    {
        IsInDialog = false;
        CollarTime = 0;
        CollarTimerOn = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (CollarTimerOn == true)
        {
            CollarTime = CollarTime +1;
          
        }
        if (CollarTime2 > 800)
        {
            Dogcollar2.SetActive(false);
        }
        if (CollarTimerOn2 == true)
        {
            CollarTime2 = CollarTime2 + 1;

        }
        if (Endgametime > 1000)
        {
            EndButton.SetActive(true);
        }
        if (Endtimer == true)
        {
            Endgametime = Endgametime + 1;

        }
        if (CollarTime > 1000)
        {
            Dogcollar.SetActive(false);
        }
    }

    [YarnCommand("displayBlankCollarImage")]
    public void DisplayBlankCollarImage()
    {
        Dogcollar.SetActive(true);
        Debug.Log("introduction text finished");
        CollarTime = 0;
        CollarTimerOn = true;
    }
    [YarnCommand("displayFinalPolaroid")]
    public void DisplayFinalPolaroid()
    {
        FinalPolaroid.SetActive(true);
        Debug.Log("final polaroid shows");
        Endgametime = 0;
        Endtimer = true;
    }

    
    [YarnCommand("moveBoat")]
    public void MoveBoat()
    {
        //GameEvents.BoatStart();
        Debug.Log("BOAT IS MOVING");
        //ChatScreen.SetActive(false);
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
        // Invoke("GameEvents.BoatStart", 1.0f);
        Debug.Log("Puzzle ONE IS STARTING");
        //ChatScreen.SetActive(false);  
    }

    [YarnCommand("startPuzzle2")]
    public void StartPuzzle2()
    {
        // Invoke("GameEvents.BoatStart", 1.0f);
        Debug.Log("Puzzle TWO IS STARTING");
        //ChatScreen.SetActive(false);  
    }

    [YarnCommand("startPuzzle3")]
    public void StartPuzzle3()
    {
        // Invoke("GameEvents.BoatStart", 1.0f);
        Debug.Log("Puzzle Three IS STARTING");
        //ChatScreen.SetActive(false);  
    }

    [YarnCommand("displayCollarWithName")]
    public void DisplayBlankCollarwithnameImage()
    {
        Dogcollar2.SetActive(true);
        Debug.Log("showing dog collar w name");
        CollarTime2 = 0;
        CollarTimerOn2 = true;
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
        ChatScreen.SetActive(true);
        if (IsInDialog == false)
        {
            Chat.StartDialogue("Location4Start");
        }
    }
    
}
