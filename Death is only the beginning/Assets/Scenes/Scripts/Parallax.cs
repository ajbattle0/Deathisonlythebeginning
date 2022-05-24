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
        if (Input.GetKeyDown(KeyCode.X) && !stopping && Moving)
        {
            stopping = true;
            StartCoroutine("StopParallaxSmooth");
        }
        else if (Input.GetKeyDown(KeyCode.X) && !starting && !Moving)
        {
            starting = true;
            StartCoroutine("StartParallaxSmooth");
        }
        transform.position = new Vector3(transform.position.x  - (currentParrallax * Time.deltaTime)  ,transform.position.y, transform.position.z);
        if(transform.position.x < -35f)
        {
            transform.position = new Vector3(25f, transform.position.y, transform.position.z);
        }
    }
    IEnumerator StopParallaxSmooth()
    {
        var startParallax = currentParrallax;
        float waitTime = 0;
        while (waitTime < stopTime)
        {
            currentParrallax = Mathf.Lerp(startParallax, 0f, (waitTime / stopTime));
            yield return null;
            waitTime += Time.deltaTime;
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

}
