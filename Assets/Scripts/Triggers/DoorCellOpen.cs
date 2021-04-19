using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DoorCellOpen : MonoBehaviour
{
    public float distance;
    public GameObject actionDisplay;
    public GameObject actionText;
    public GameObject door;
    public AudioSource openDoorSound;

    public bool hasKey = false;
    public GameObject talkTextBox;

    // Update is called once per frame
    void Update()
    {
        distance = PlayerCasting.distanceFromTarget;
        
    }

	private void OnMouseOver()
	{
		if(distance <= 2f)
		{
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

            if(distance <= 2f && hasKey)
			{
                this.GetComponent<BoxCollider>().enabled = false;
                actionDisplay.SetActive(false);
                actionText.SetActive(false);
                door.GetComponent<Animation>().Play("DoorOpen");
                openDoorSound.Play();
            }

            else{

                StartCoroutine(noKeyPlayer());

            }

		}
         
	}

	private void OnMouseExit()
	{
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
    }

    IEnumerator noKeyPlayer(){

        talkTextBox.GetComponent<Text>().text = "Dammit, The Door is locked";
        
        yield return new WaitForSeconds(1.2f);

        talkTextBox.GetComponent<Text>().text ="";
    }
}
