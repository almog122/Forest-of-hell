using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFIrstNote : MonoBehaviour
{
    public float distance;
    public GameObject actionText;
    public GameObject image;

    // Update is called once per frame
    void Update()
    {
        distance = PlayerCasting.distanceFromTarget;

    }

    private void OnMouseOver()
    {
        if (distance <= 2f)
        {
            actionText.GetComponent<Text>().text = "The brain shape out world -->" +
                "\n so we must go above and beyond" ;
                
            actionText.SetActive(true);
            image.SetActive(true);

        }

        if (distance > 2f)
        {
            actionText.SetActive(false);
            image.SetActive(false);
        }

    }

    private void OnMouseExit()
    {
        actionText.SetActive(false);
        image.SetActive(false);
    }
}
