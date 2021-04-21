using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FirstDoorExit : MonoBehaviour
{

    public GameObject player;

    public GameObject talkTextBox;

    public GameObject flashlight;

    public GameObject lightSource;

    public GameObject head;

    Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        textBox = talkTextBox.GetComponent<Text>();
    }

    private void OnTriggerEnter(Collider other)
    {
        player.GetComponent<PlayerController>().enabled = false;

        StartCoroutine(screenPlayer());


    }

    IEnumerator screenPlayer()
    {
        yield return new WaitForSeconds(1f);
        flashlight.SetActive(false);
        textBox.text = "Whats going on?!";

        yield return new WaitForSeconds(1f);
        lightSource.SetActive(true);
        textBox.text = "Huh";

        yield return new WaitForSeconds(0.5f);
        lightSource.SetActive(false);
        yield return new WaitForSeconds(0.5f);
        lightSource.SetActive(true);

        yield return new WaitForSeconds(2f);

        head.SetActive(true);

        textBox.text = "Make it stoop ";

        yield return new WaitForSeconds(1f);
        head.SetActive(false);
        textBox.text = "";
        lightSource.SetActive(false);
        flashlight.SetActive(true);
        player.GetComponent<PlayerController>().enabled = true;
    }
}
