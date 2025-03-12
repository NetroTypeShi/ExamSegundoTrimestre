using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    // cos(radius),sin(radius)
    float angle;
    float timePassed = 0;
    [SerializeField] float maxTime = 0.2f;
    [SerializeField] GameObject enemyPrefab;
    GameObject gameStart;
    GameStart startScript;
    // Start is called before the first frame update
    void Start()
    {
        gameStart = GameObject.FindGameObjectWithTag("Start");
        startScript = gameStart.GetComponent<GameStart>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (startScript.gameStarted == true) 
        {
            timePassed = timePassed + Time.deltaTime;
            if (timePassed >= maxTime)
            {
                SpawnEnemy();
                timePassed = 0;
            }
        }
        
    }
    void SpawnEnemy()
    {    
        angle = Random.Range(0, 2*Mathf.PI);   
        Vector3 unitVector = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);  
        Vector3 spawnPosition = unitVector * 10.29f;
        Instantiate((enemyPrefab),(spawnPosition), Quaternion.identity);                              
    }
}
