using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameStart : MonoBehaviour
{
    GameObject enemy;
    GameObject player;
    PlayerAttributes playerAttributesScript;
    PlayerBehavior triangleScript;
    public bool gameStarted = false;
    [SerializeField] public TMP_Text gameStartAndOverText;
    // Start is called before the first frame update
    void Start()
    {
       gameStarted = false;       
    }

    // Update is called once per frame
    void Update()
    {        
        if (gameStarted == false)
        {
            gameStartAndOverText.text = ("PRESS SPACE TO START");
        }
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        player = GameObject.FindGameObjectWithTag("Player");
        playerAttributesScript = player.GetComponent<PlayerAttributes>();
        triangleScript = player.GetComponent<PlayerBehavior>();
        if (Input.GetKeyDown(KeyCode.Space))
        {
           GameEvents.GameStarted.Invoke();
           
        }
    }
    
}
