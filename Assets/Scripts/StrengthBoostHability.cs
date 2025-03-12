using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StrengthBoostHability : HabilitiesParent
{
    float cooldownTime = 0f;
    GameStart gameStart;
    PlayerAttributes playerAttributes;
    GameObject gameStarter;
    GameObject player;
    [SerializeField] ParticleSystem strengthBoostParticles;
    [SerializeField] float strengthIncrement = 2;
    // Start is called before the first frame update
    private void Start()
    {
        
    }
    private void FixedUpdate()
    {
        gameStarter = GameObject.FindGameObjectWithTag("Start");
        player = GameObject.FindGameObjectWithTag("Player");
        playerAttributes = player.GetComponent<PlayerAttributes>();
        gameStart = gameStarter.GetComponent<GameStart>();
        if (gameStart.gameStarted == true)
        {
            if (cooldownTime > 0f)
            {
                cooldownTime -= Time.deltaTime;
                icon.fillAmount = 1 - (cooldownTime / cooldown);
            }
        }
    }
    public override void Trigger()
    {

        if (gameStart.gameObject == true)
        {
            if (cooldownTime <= 0)
            {
                strengthBoostParticles.Play();
                playerAttributes.strength = playerAttributes.strength * strengthIncrement;
                Invoke("StopBoost", 6);

                cooldownTime = cooldown;
                icon.fillAmount = 0;
            }
        }
    }
    void StopBoost()
    {
        playerAttributes.strength = playerAttributes.strength / strengthIncrement; 
    }
}
