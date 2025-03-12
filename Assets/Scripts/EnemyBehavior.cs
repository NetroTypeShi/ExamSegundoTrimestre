using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyBehavior : MonoBehaviour
{
    [SerializeField] SpriteRenderer rend;
    [SerializeField] Gradient healthColor;
    public float health = 10;
    [SerializeField] float maxHealth;
    public float damage = 2;
    Vector3 direction;
    Transform playerPosition;
    [SerializeField] float speed;
    GameObject player;
    PlayerBehavior triangleScript;
    PlayerAttributes playerAttributesScript;
    void Start()
    {        
        health = maxHealth;
        player = GameObject.FindGameObjectWithTag("Player");
        triangleScript = player.GetComponent<PlayerBehavior>();
        playerAttributesScript = player.GetComponent<PlayerAttributes>();
    }

    // Update is called once per frame
    void Update()
    {
        
        rend.color = healthColor.Evaluate(1f * health / maxHealth);        
        playerPosition = player.transform;
        direction = (playerPosition.position - transform.position).normalized;
        if (playerAttributesScript.health > 0) { gameObject.transform.position += direction * speed * Time.deltaTime; }
        if (playerAttributesScript.health <= 0) { gameObject.transform.position -= direction * speed * Time.deltaTime;}
        if (health <= 0) { Destroy(gameObject); EnemyDeath(); }
                
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet")) { rend.color = healthColor.Evaluate(1f * health / maxHealth); }
        if (collision.gameObject.CompareTag("Area")) { Destroy(gameObject); EnemyDeath(); }
        if (collision.gameObject.CompareTag("Player")) { Destroy(gameObject); }
    }
    void EnemyDeath()
    {
      GameEvents.EnemyDied.Invoke();
    } 
}
