using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DigitalLock : MonoBehaviour
{

    public float distance;
    public GameObject actionDisplay;
    public GameObject actionText;

    public GameObject Lock;
    public GameObject gun;

    GameObject player;

	void Start()
	{
        player = Player_manager.instance.Player;

    }
	// Start is called before the first frame update
	void Update()
    {
        distance = PlayerCasting.distanceFromTarget;
    }

    private void OnMouseOver()
    {
        if (distance <= 2f)
        {
            actionText.GetComponent<Text>().text = "Check Lock";
            actionDisplay.SetActive(true);
            actionText.SetActive(true);

        }

        if (distance > 2f)
        {
            actionDisplay.SetActive(false);
            actionText.SetActive(false);

        }

        if (Input.GetButtonDown("Action"))
        {

            if (distance <= 2f)
            {
                actionDisplay.SetActive(false);
                actionText.SetActive(false);

                Lock.SetActive(true);
                Cursor.lockState = CursorLockMode.Confined;
                gun.GetComponent<FireGun>().enabled = false;
                player.GetComponent<PlayerController>().enabled = false;
                player.GetComponentInChildren<CameraController>().enabled = false;
            }

            

        }



    }

    private void OnMouseExit()
    {
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
    }

}
