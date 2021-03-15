using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpeningSeq : MonoBehaviour
{

    public GameObject player;

    public GameObject fadeBlackScreen;

    public GameObject talkTextBox;

    Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        player.GetComponent<PlayerController>().enabled = false;

        textBox = talkTextBox.GetComponent<Text>();

        StartCoroutine(screenPlayer());
    }

    IEnumerator screenPlayer()
	{
        yield return new WaitForSeconds(1.5f);

        fadeBlackScreen.SetActive(false);
        textBox.text = "Where - where am i?!";

        yield return new WaitForSeconds(2f);

        textBox.text = "";
        player.GetComponent<PlayerController>().enabled = true;
    }

}
