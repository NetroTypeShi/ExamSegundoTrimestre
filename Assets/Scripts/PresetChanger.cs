using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PresetChanger : MonoBehaviour
{
    [SerializeField] MovementStats[] presets;
    int currentIndex = 0;
    // Start is called before the first frame update
    void Start()
    {
        SendStatS();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            currentIndex++;
            if (currentIndex == 2)
            {
                currentIndex = 0;
            }
        }
        SendStatS();
    }
    void SendStatS()
    {
        GetComponent<PlayerBehavior>().SetStats(presets[currentIndex]);
    }
}
