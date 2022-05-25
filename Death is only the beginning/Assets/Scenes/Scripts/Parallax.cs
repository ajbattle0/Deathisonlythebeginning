using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    public float startpos, length;
    public float parrallaxAmount ;
    public float currentParrallax;
    public bool stopping;
    public bool starting;
    public bool Moving;
    public float stopTime;


    // Start is called before the first frame update
    void Start()
    {
        startpos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x;
        currentParrallax = parrallaxAmount;
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
        GameEvents.OnStartBoat += StartParallax;
        GameEvents.OnStopBoat += StopParallax;
    }
    private void OnDisable()
    {

        GameEvents.OnStartBoat -= StartParallax;
        GameEvents.OnStopBoat -= StopParallax;
    }
}
