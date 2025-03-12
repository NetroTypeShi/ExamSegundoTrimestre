using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EventBehavior : MonoBehaviour
{
    PlayerBehavior triangleScript;
    GameObject enemy;
    GameObject gameStart;
    GameObject player;
    GameStart startScript;
    PlayerAttributes playerAttributesScript;
    [SerializeField] TMP_Text scoreCounter;
    public int score = 0;
    void Start()
    {
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        gameStart = GameObject.FindGameObjectWithTag("Start");
        player = GameObject.FindGameObjectWithTag("Player");
        startScript = gameStart.GetComponent<GameStart>();
        playerAttributesScript = player.GetComponent<PlayerAttributes>();
        triangleScript = player.GetComponent<PlayerBehavior>();
        score = 0;
        scoreCounter.text = "Score: " + score;
        GameEvents.EnemyDied.AddListener(EnemyDying);
        GameEvents.PlayerDied.AddListener(PlayerDeath);
        GameEvents.GameStarted.AddListener(StartingGame);
    }

    
    void Update()
    {
       
    }
   
    void EnemyDying()
    {
        score = score + 1;
        scoreCounter.text = "Score: " + score;
    }

    void PlayerDeath()
    {
        startScript.gameStarted = false;        
    }
    void StartingGame()
    {        
        print("GameStarted");
        startScript.gameStarted = true;
        playerAttributesScript.health = playerAttributesScript.maxHealth;
        Destroy(enemy);
        player.transform.position = new Vector2(0, 0);
        startScript.gameStartAndOverText.text = ("");
        score = 0;
        scoreCounter.text = "Score: " + score;
        triangleScript.rend.color = triangleScript.healthColor.Evaluate(1f * playerAttributesScript.health / playerAttributesScript.maxHealth);
    }

}
