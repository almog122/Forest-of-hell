using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoBar : MonoBehaviour
{
    Player_manager playerManager;

    Player_Stats ammo;

    Text ammoBar;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = Player_manager.instance;

        ammo = playerManager.Player.GetComponent<Player_Stats>();

        ammoBar = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        ammoBar.text = ammo.currentAmmo + "X";
    }
}
