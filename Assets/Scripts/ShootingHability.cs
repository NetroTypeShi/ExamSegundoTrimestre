using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ShootingHability : HabilitiesParent
{
    [SerializeField] float originalScale;    
    [SerializeField] Transform puntita;
    [SerializeField] GameObject bulletPrefab;
    GameObject gameStart;
    GameStart startScript;
    float cooldownTime = 0f;
    GameObject player;
    GameObject bulletInstantiated;
    BulletBehavior bulletScript;
    PlayerBehavior TriangleScript;
    PlayerAttributes playerAttributes;
    HabilityHolder HolderScript;
    private void FixedUpdate()
    {
        if (cooldownTime > 0f) 
        { 
            cooldownTime -= Time.deltaTime;
            icon.fillAmount=1 - (cooldownTime/cooldown);
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
                player = GameObject.FindGameObjectWithTag("Player");
                bulletInstantiated = Instantiate(bulletPrefab);
                bulletScript = bulletInstantiated.GetComponent<BulletBehavior>();
                TriangleScript = GetComponent<PlayerBehavior>();
                playerAttributes = player.GetComponent<PlayerAttributes>();
                bulletScript.direction = puntita.position;
                bulletScript.direction.Normalize();
                HolderScript = gameObject.GetComponent<HabilityHolder>();
                 
                bulletInstantiated.transform.localScale = Vector3.one*(originalScale*playerAttributes.strength);
                cooldownTime = cooldown;
                icon.fillAmount = 0;
            }
        }
                        
    }
}
