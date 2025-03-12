using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    Rigidbody2D rb;
    [SerializeField] ParticleSystem damageParticles;
    float timePassed = 0;
    [SerializeField] float maxTime = 0.2f;
    [SerializeField] public SpriteRenderer rend;
    [SerializeField] public Gradient healthColor;
    [SerializeField] public ParticleSystem healthParticles;
    float healthPercent;
    GameObject gameStart;
    GameStart startScript;
    public Vector3 point;
    public Vector2 mouse;
    Camera cam;
    public float angle;
    public Vector2 direction;
    PlayerAttributes playerAttributesScript;
    EnemyBehavior enemyMovement;
    MovementStats stats;
    Vector2 movementInput;

    // Start is called before the first frame update
    void Start()
    {
        
        rb = gameObject.GetComponent<Rigidbody2D>();
        playerAttributesScript = gameObject.GetComponent<PlayerAttributes>();
        cam = Camera.main;
        playerAttributesScript.health = playerAttributesScript.maxHealth;
        gameStart = GameObject.FindGameObjectWithTag("Start");
        startScript = gameStart.GetComponent<GameStart>();
    }

    // Update is called once per frame
    void Update()
    {
        // Aplica la aceleración según la entrada


        
        if (rb.velocity.magnitude >= stats.maxSpeed)
        {
            rb.velocity = rb.velocity.normalized * stats.maxSpeed;
        }
        rb.velocity += movementInput * Time.deltaTime * stats.acceleration;
        movementInput = Vector2.zero;
        if (startScript.gameStarted == true) 
        {
            
            if (playerAttributesScript.health > 0)
            {
                if (playerAttributesScript.health > playerAttributesScript.maxHealth) { playerAttributesScript.health = playerAttributesScript.maxHealth; }

               point = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, transform.position.z - cam.transform.position.z));
                //(posición del raton x e y, vector unitario entre el eje z del point y el del cam) 

                Vector2 direction = point - transform.position;//Vector unitario entre el puntero y la posición inicial

                transform.rotation = Quaternion.Euler(0, 0, angle); //aplicar rotación

                angle = Vector3.SignedAngle(Vector3.up, direction, Vector3.forward); //calcuar el angulo negri
            }

            if (playerAttributesScript.health <= 0)
            {
                GameEvents.PlayerDied.Invoke(); 
            }
            if (Input.GetKey(KeyCode.W))
            {
                movementInput += Vector2.up;
            }
            if (Input.GetKey(KeyCode.A))
            {
                movementInput += Vector2.left;
            }
            if (Input.GetKey(KeyCode.S))
            {
                movementInput += Vector2.down;
            }
            if (Input.GetKey(KeyCode.D))
            {
                movementInput += Vector2.right;
            }

        }
        
    }
    void StopParticles()
    {
     damageParticles.Stop();
    }
    public void SetStats(MovementStats stats)
    {
        this.stats = stats;
        print("player received stats " + stats.name);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            playerAttributesScript = gameObject.GetComponent<PlayerAttributes>();
            enemyMovement = collision.gameObject.GetComponent<EnemyBehavior>();
            playerAttributesScript.health = playerAttributesScript.health - enemyMovement.damage;
            damageParticles.Play();
            rend.color = healthColor.Evaluate(1f * playerAttributesScript.health / playerAttributesScript.maxHealth);
            Invoke("StopParticles", 1f);

        }
    }
}
