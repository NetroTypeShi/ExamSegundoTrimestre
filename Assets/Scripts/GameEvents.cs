using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents
{

    public class RotationMacroEvent : UnityEvent<int[], float[]> { };
    // Start is called before the first frame update
    public static UnityEvent PlayerDied = new UnityEvent();
    public static UnityEvent EnemyDied = new UnityEvent();
    public static UnityEvent GameStarted = new UnityEvent();
}
