using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunPickUp : MonoBehaviour
{
    public float distance;
    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject gunFake;
    public GameObject gunReal;
    public GameObject crosshair;


    // Update is called once per frame
    void Update()
    {
        distance = PlayerCasting.distanceFromTarget;

    }

    private void OnMouseOver()
    {
        if (distance <= 2f)
        {
            crosshair.SetActive(true);
            actionDisplay.SetActive(true);
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
