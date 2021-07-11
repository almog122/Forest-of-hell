using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;

public class RabbitPickUp : MonoBehaviour
{
    public float distance;
    public GameObject actionDisplay;
    public GameObject actionText;

    

    // Start is called before the first frame update
    void Update()
    {
        distance = PlayerCasting.distanceFromTarget;
    }

    // Update is called once per frame
    private void OnMouseOver()
    {
        if (distance <= 2f)
        {
            actionText.GetComponent<Text>().text = "Pick up the rabbit";
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

            if (distance <= 2f )
            {
                this.GetComponent<BoxCollider>().enabled = false;
                actionDisplay.SetActive(false);
                actionText.SetActive(false);

                StartCoroutine(playVidoe());
            }

        }
    }

    private void OnMouseExit()
    {
        actionDisplay.SetActive(false);
        actionText.SetActive(false);
    }

    IEnumerator playVidoe()
    {

        this.GetComponent<VideoPlayer>().Play();

        yield return new WaitForSeconds(7f);

        this.GetComponent<VideoPlayer>().Stop();
    }
}
