using UnityEngine;

public class ForceFieldHability : HabilitiesParent
{
    float cooldownTime = 0f;
    GameObject gameStart;
    GameStart startScript;
    GameObject[] allObjects;
    GameObject circle;
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

        allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        
        circle = System.Array.Find(allObjects, obj => obj.CompareTag("Area"));
        if (startScript.gameStarted == true)
        {
            if (cooldownTime <= 0)
            {
                if (circle != null)
                {
                    
                    circle.SetActive(true);
                    Invoke("NoArea", 3f);

                }

                cooldownTime = cooldown;
                icon.fillAmount = 0;
            }
        }
    }
    void NoArea()
    {
        allObjects = Resources.FindObjectsOfTypeAll<GameObject>();
        circle = System.Array.Find(allObjects, obj => obj.CompareTag("Area"));
        circle.SetActive(false);
    }
}

