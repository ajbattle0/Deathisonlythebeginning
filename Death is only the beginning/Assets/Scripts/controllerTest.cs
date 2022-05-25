using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class controllerTest : MonoBehaviour
{
    public Movement movementScript;
    float timer = 0;
    public float timerDuration;
    bool running;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.G) && !running)
        {
            GameEvents.BoatStart();
            running = true;
        }
        if (Input.GetKeyDown(KeyCode.F) && !running)
        {
            GameEvents.BoatStop();
            running = true;
        }
        if (Input.GetKeyDown(KeyCode.L) && !running)
        {
            GameEvents.OpenPuzzle();
        }
        if (Input.GetKeyDown(KeyCode.O) && !running)
        {
            GameEvents.ClosePuzzle();
        }
        if (running)
        {
            timer += Time.deltaTime;
            if(timer >= timerDuration)
            {
                running = false;
            }
        }
    }
}
