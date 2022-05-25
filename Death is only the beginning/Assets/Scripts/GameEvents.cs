using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public delegate void MovementAction();
    public static event MovementAction OnStartBoat;
    public static event MovementAction OnStopBoat;
    public static event MovementAction OnOpenPuzzle;
    public static event MovementAction OnClosePuzzle;



    public static void BoatStart()
    {
        if (OnStartBoat != null)
        {
            OnStartBoat();
        }
    }
    public static void BoatStop()
    {
        if (OnStopBoat != null)
        {
            OnStopBoat();
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
