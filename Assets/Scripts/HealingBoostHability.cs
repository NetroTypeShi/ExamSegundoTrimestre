using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingBoostHability : HabilitiesParent
{
    float cooldownTime = 0f;
    [SerializeField] ParticleSystem healingUpgradeParticles;
    bool healingUpgrade = false;
    [SerializeField] float healingBoost = 0;
    GameObject gameStart;
    GameStart startScript;
    GameObject player;
    PlayerAttributes attributes;
    void Start()
    {
        
    }

    // Update is called once per frame
    private void FixedUpdate()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        attributes = player.GetComponent<PlayerAttributes>();
        gameStart = GameObject.FindGameObjectWithTag("Start");
        startScript = gameStart.GetComponent<GameStart>();        
        if (cooldownTime > 0f)
        {
            cooldownTime -= Time.deltaTime;
            icon.fillAmount = 1 - (cooldownTime / cooldown);
        }
    }

    public override void Trigger()
    {                       
        if (startScript.gameStarted == true)
        {
            if (cooldownTime <= 0f)
            {
                healingUpgradeParticles.Play();                                
                attributes.upgradeHealing = attributes.upgradeHealing * healingBoost;
                Invoke("StopBoost", 2.5f);
                cooldownTime = cooldown;
                icon.fillAmount = 0;
            }
        }
    }
    void StopBoost()
    {                                       
        attributes.upgradeHealing = attributes.upgradeHealing/healingBoost;
        healingUpgrade = false ;
    }
}
