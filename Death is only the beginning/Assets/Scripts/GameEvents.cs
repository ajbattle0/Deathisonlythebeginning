using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public delegate void MovementAction();
    public static event MovementAction OnBoatDeparter;
    public static event MovementAction OnBoatArrival;
    public static event MovementAction OnBoatStart;
    public static event MovementAction OnBoatStop;
    public static event MovementAction OnOpenPuzzle;
    public static event MovementAction OnClosePuzzle;



    public static void BoatStart()
    {
        if (OnBoatStart != null)
        {
            OnBoatStart();
        }
    }
    public static void BoatStop()
    {
        if (OnBoatStop != null)
        {
            OnBoatStop();
        }
    }
    public static void BoatDeparter()
    {
        if (OnBoatDeparter != null)
        {
            OnBoatDeparter();
        }
    }
    public static void BoatArrival()
    {
        if (OnBoatArrival != null)
        {
            OnBoatArrival();
        }
    }
    public static void OpenPuzzle()
    {
        if (OnOpenPuzzle != null)
        {
            OnOpenPuzzle();
        }
    }
    public static void ClosePuzzle()
    {
        if (OnClosePuzzle != null)
        {
            OnClosePuzzle();
        }
    }
 
}
