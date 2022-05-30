using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Starter : MonoBehaviour
{

    public DialogueScript dialogueScript;
    public 
    void Start()
    {
        AudioController.Instance.PlayAmbient();
        AudioController.Instance.PlayMusic(AudioController.Instance.sad);
        if (SceneManager.GetActiveScene().buildIndex == 1)
        {
            StartCoroutine(StartIntro());
        }
        else
        {
            StartCoroutine(StartDepartcher());
        }
    }
    IEnumerator StartDepartcher()
    {
        yield return new WaitForSeconds(1);
        GameEvents.BoatDeparter();
        yield return new WaitForSeconds(6);
        GameEvents.BoatArrival();
    }
    IEnumerator StartIntro()
    {
        yield return new WaitForSeconds(1);
        dialogueScript.PlayIntroductionText();
    }


}
