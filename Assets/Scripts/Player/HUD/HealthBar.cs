using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    Player_manager playerManager;

    Player_Stats health;

    Text Healthbar;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = Player_manager.instance;

        health = playerManager.Player.GetComponent<Player_Stats>();

        Healthbar = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        Healthbar.text = health.currentHealth + "/" + health.maxHealth;
    }
}
