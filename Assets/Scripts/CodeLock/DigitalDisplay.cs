using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DigitalDisplay : MonoBehaviour
{
    [SerializeField]
    private Text codeSequence;

    public GameObject door;
    public GameObject gun;
    public AudioSource openDoorSound;

    GameObject player;

    public GameObject Lock;
    public GameObject realLock;

    // Start is called before the first frame update
    void Start()
    {
        codeSequence.text = "";
        player = Player_manager.instance.Player;

        PushButton.ButtonPressed += addDigitToCodeSeq;
    }

    private void addDigitToCodeSeq(string digitEntered)
	{
        if (digitEntered == "del")
        {
            codeSequence.text = "";
            return;
        }

        if (digitEntered == "check")
        {
            CheckResult();
            return;
        }
        if (digitEntered == "back")
        {
            
            Lock.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            player.GetComponent<PlayerController>().enabled = true;
            player.GetComponentInChildren<CameraController>().enabled = true;
            gun.GetComponent<FireGun>().enabled = true;
            return;
        }

        if (codeSequence.text.Length < 4)
		{
            codeSequence.text += digitEntered;
		}

       
    }

    private void CheckResult()
	{
        if(codeSequence.text == "2376")
		{
            realLock.GetComponent<BoxCollider>().enabled = false;
            Lock.SetActive(false);
            Cursor.lockState = CursorLockMode.Locked;
            player.GetComponent<PlayerController>().enabled = true;
            player.GetComponentInChildren<CameraController>().enabled = true;
            gun.GetComponent<FireGun>().enabled = true;
            door.GetComponent<Animation>().Play("DoorOpen");
            openDoorSound.Play();
        }
		else
		{
            codeSequence.text = "";
            //error sound
        }

	}


	private void OnDestroy()
	{
        PushButton.ButtonPressed -= addDigitToCodeSeq;
	}
}
