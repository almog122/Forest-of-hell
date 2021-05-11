using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaintyBar : MonoBehaviour
{
    Player_manager playerManager;

    Player_Stats sainty;

    Text saintyBar;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = Player_manager.instance;

        sainty = playerManager.Player.GetComponent<Player_Stats>();

        saintyBar = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {

        saintyBar.text = sainty.currentSainty.ToString("F1") + "/" + sainty.maxSainty;
    }
}
