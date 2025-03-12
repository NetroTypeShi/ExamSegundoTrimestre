using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class HabilitiesParent : MonoBehaviour  
{
    [SerializeField] protected string abilityName;
    [SerializeField] protected Image icon;
    [SerializeField] protected float cooldown;
    // Start is called before the first frame update
    public abstract void Trigger();
}
