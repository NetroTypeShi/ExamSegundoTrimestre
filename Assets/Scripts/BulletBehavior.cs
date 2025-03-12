using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    
    [SerializeField] public float damage;
    [SerializeField] public float speed;
    [HideInInspector] public Vector3 direction;
    GameObject player;
    GameObject enemy;
    Transform playerPosition;
    PlayerBehavior playerScript;
    PlayerAttributes playerAttributesScript;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerBehavior>();
        playerPosition = player.GetComponent<Transform>();
        gameObject.transform.position = playerPosition.position;
        direction = playerScript.point - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position += direction * speed * Time.deltaTime;
        //print(direction);

        if (gameObject.transform.position.x >= 12 || gameObject.transform.position.x <= -12)
        {
            Destroy(gameObject); // Destruye el objeto cuando llega al límite
        }

        if (gameObject.transform.position.y >= 8 || gameObject.transform.position.y <= -8)
        {
            Destroy(gameObject); // Destruye el objeto cuando llega al límite
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        playerAttributesScript = player.GetComponent<PlayerAttributes>();
        if (collision.gameObject.CompareTag("Enemy"))
        {
            enemy = GameObject.FindGameObjectWithTag("Enemy");
            if (collision.gameObject.CompareTag("Enemy")) { enemy.GetComponent<EnemyBehavior>().health = enemy.GetComponent<EnemyBehavior>().health - damage*playerAttributesScript.strength; }
            Destroy(gameObject);
        }
    }
}
