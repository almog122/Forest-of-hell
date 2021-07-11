using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AmmoPickUp : MonoBehaviour
{
    public float distance;
    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject crosshair;

    Player_Stats ammo;

    // Update is called once per frame
    void Update()
    {
        distance = PlayerCasting.distanceFromTarget;

    }

	public void Start()
	{
        ammo = Player_manager.instance.Player.GetComponent<Player_Stats>();


    }

	private void OnMouseOver()
    {
        if (distance <= 2f)
        {
            crosshair.SetActive(true);
            actionDisplay.SetActive(true);
            actionText.GetComponent<Text>().text = "Pick up Ammo";
            actionText.SetActive(true);

        }

        if (distance > 2f)
        {
            crosshair.SetActive(false);
            actionDisplay.SetActive(false);
            actionText.SetActive(false);

        }

        if (Input.GetButtonDown("Action"))
        {

            if (distance <= 2f)
            {
                this.GetComponent<BoxCollider>().enabled = false;
                actionDisplay.SetActive(false);
                actionText.SetActive(false);
                ammo.pickUpAmmo();
                Destroy(transform.parent.gameObject);
            }

        }

    }

    private void OnMouseExit()
    {
        crosshair.SetActive(false);
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
    }
}
