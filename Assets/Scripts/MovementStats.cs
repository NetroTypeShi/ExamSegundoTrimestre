using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu]
public class MovementStats : ScriptableObject
{
    [SerializeField] public float acceleration;
    [SerializeField] public float maxSpeed;
    [SerializeField] public float friction;
}
