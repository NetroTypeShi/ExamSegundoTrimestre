using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HabilityHolder : MonoBehaviour
{
    public bool habilitiesOn = true;
    [SerializeField] HabilitiesParent[] abilities;
    public int abilityNumber;
    // Start is called before the first frame update
    void Start()
    {
        habilitiesOn = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (habilitiesOn == true)
        {
            if (Input.GetMouseButtonDown(0))
            {
                abilities[abilityNumber].Trigger();
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            abilityNumber = 0;
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            abilityNumber = 1;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            abilityNumber = 2;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            abilityNumber = 3;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            abilityNumber = 4;
        }
        if(Input.GetKeyDown(KeyCode.Alpha6)) 
        { 
            abilityNumber = 5; 
        }

        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            abilityNumber = 6;
        }
    }
}
