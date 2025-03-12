using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttributes : MonoBehaviour
{
    float timePassed = 0;
    [SerializeField] float maxTime = 0.2f;
    [SerializeField] public float health;
    [SerializeField] public float maxHealth = 20;
    [SerializeField] public float strength = 1;
    [SerializeField] public float maxStrength = 2.5f;
    [SerializeField] public float upgradeHealing = 0.2f;
    [SerializeField] public float upgradeStrength = 0.1f;
    GameObject gameStart;
    GameStart startScript;
    PlayerBehavior triangleScript;
    // Start is called before the first frame update
    void Start()
    {
        gameStart = GameObject.FindGameObjectWithTag("Start");
        startScript = gameStart.GetComponent<GameStart>();
        triangleScript = gameObject.GetComponent<PlayerBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startScript.gameStarted == true)
        {
            timePassed = timePassed + Time.deltaTime;

            if (timePassed >= 0.5f) { timePassed = 0; }
            if (timePassed == 0)
            {              
                health = health + upgradeHealing;
                triangleScript.rend.color = triangleScript.healthColor.Evaluate(1f * health / maxHealth);
            }
            if (strength >= maxStrength) { strength = maxStrength; }
            
        }
    }
}
