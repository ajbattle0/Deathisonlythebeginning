using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEvents : MonoBehaviour
{
    public delegate void MovementAction();
    public static event MovementAction OnStartBoat;
    public static event MovementAction OnStopBoat;
    


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
}
