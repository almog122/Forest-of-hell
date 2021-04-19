using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowFIrstNote : MonoBehaviour
{
    public float distance;
    public GameObject actionText;

    // Update is called once per frame
    void Update()
    {
        distance = PlayerCasting.distanceFromTarget;

    }

    private void OnMouseOver()
    {
        if (distance <= 2f)
        {
            actionText.GetComponent<Text>().text ="Use head to locate key -->" +
                "\nfrom the head down but in reverse";
            actionText.SetActive(true);

        }

        if (distance > 2f)
        {
            actionText.SetActive(false);

        }

    }

    private void OnMouseExit()
    {
        actionText.SetActive(false);
    }
}
