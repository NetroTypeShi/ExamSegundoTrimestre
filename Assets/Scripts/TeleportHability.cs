using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportHability : HabilitiesParent
{
    float cooldownTime = 0f;
    GameObject player;
    GameObject gameStart;
    GameStart startScript;
    HabilityHolder habilityScript;
    PlayerBehavior playerScript;
    [SerializeField] ParticleSystem teleportParticles;
    ParticleSystem.MainModule module; 
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerScript = player.GetComponent<PlayerBehavior>();
    }
    private void FixedUpdate()
    {
        if (cooldownTime > 0f)
        {
            cooldownTime -= Time.deltaTime;
            icon.fillAmount = 1 - (cooldownTime / cooldown);
        }

    }
    public override void Trigger()
    {
        gameStart = GameObject.FindGameObjectWithTag("Start");
        startScript = gameStart.GetComponent<GameStart>();
        if (startScript.gameStarted == true)         
        {
            if (cooldownTime <= 0)
            {
                module = teleportParticles.main;
                module.startColor = playerScript.rend.color;
                teleportParticles.Play();
                gameObject.transform.position = playerScript.point;
                habilityScript = gameObject.GetComponent<HabilityHolder>();           
                Invoke("RetunToOriginalPosition", 3f);
                cooldownTime = cooldown;
                icon.fillAmount = 0;
            }
        }
        
    }    
}
