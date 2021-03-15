using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class OpeningSeq_1 : MonoBehaviour
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

        yield return new WaitForSeconds(1f);

        textBox.text = "What with this photo , A chip in my barin? ";

        yield return new WaitForSeconds(1f);

        textBox.text = "I gotta get out of here ";

        yield return new WaitForSeconds(1f);

        textBox.text = "";
        player.GetComponent<PlayerController>().enabled = true;
    }

}
