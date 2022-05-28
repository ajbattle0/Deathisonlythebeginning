using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Parallax : MonoBehaviour
{
    public float length;
    public float parrallaxAmount ;
    public float currentParrallax;
    public bool stopping;
    public bool starting;
    public bool Moving;
    public float stopTime;
    static bool introDiologPlayed;
     
    float startXPos;
    Vector3 startpos;

    [SerializeField] DialogueScript dialogueScript;
    int scene; 


    // Start is called before the first frame update
    void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
        introDiologPlayed = false;
        startpos = transform.position;
        startXPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        currentParrallax = 0;
        Moving = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        transform.position = new Vector3(transform.position.x  - (currentParrallax * Time.deltaTime)  ,transform.position.y, transform.position.z);
        if(transform.position.x < -35f)
        {
            transform.position = new Vector3(25f, transform.position.y, transform.position.z);
        }
    }
    IEnumerator StopParallaxSmooth()
    {
        yield return new WaitForSeconds(4);
        var startParallax = currentParrallax;
        float waitTime = 0;
        while (waitTime < stopTime)
        {
            
            waitTime += Time.deltaTime;
            currentParrallax = Mathf.Lerp(startParallax, 0f, (waitTime / stopTime));
            
            
            yield return null;
        }
        currentParrallax = 0f;
        Moving = false;
        stopping = false;
        yield return new WaitForSeconds(2);
        WhichScene();
    }
    IEnumerator StartParallaxSmooth()
    {
       
        var startParallax = 0f;
        float waitTime = 0;
        while (waitTime < stopTime)
        {
            currentParrallax = Mathf.Lerp(startParallax, parrallaxAmount, (waitTime / stopTime));
            yield return null;
            waitTime += Time.deltaTime;
        }
        currentParrallax = parrallaxAmount;
        Moving = true;
        starting = false;
    }
    public void StartParallax()
    {
        StartCoroutine(StartParallaxSmooth());
    }
    public void StopParallax()
    {
        StartCoroutine(StopParallaxSmooth());
    }
    private void OnEnable()
    {
        GameEvents.OnBoatDeparter += StartParallax;
        GameEvents.OnBoatArrival += StopParallax;
        GameEvents.OnBoatStart += StartParallax;
        GameEvents.OnBoatStop += StopParallax;
        GameEvents.OnResetParallax += ResetThisParallax;
    }
    private void OnDisable()
    {

        GameEvents.OnBoatDeparter -= StartParallax;
        GameEvents.OnBoatArrival -= StopParallax;
        GameEvents.OnBoatStart -= StartParallax;
        GameEvents.OnBoatStop -= StopParallax;
        GameEvents.OnResetParallax -= ResetThisParallax;
    }
    void WhichScene()
    {
        if (!introDiologPlayed)
        {
            switch (scene)
            {
                case 1:
                    dialogueScript.PlayLocation1StartText();
                    introDiologPlayed = true;
                    Debug.Log("1");
                    break;
                case 2:
                    dialogueScript.PlayLocation2StartText();
                    introDiologPlayed = true;
                    Debug.Log("2");
                    break;
                case 3:
                    dialogueScript.PlayLocation3StartText();
                    introDiologPlayed = true;
                    break;
                case 4:
                    dialogueScript.PlayLocation4StartText();
                    introDiologPlayed = true;
                    break;
            }
        }
        
    }
    void ResetThisParallax()
    {
        transform.position = startpos;
    }
}
