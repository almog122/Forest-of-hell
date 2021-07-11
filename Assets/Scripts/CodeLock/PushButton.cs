using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PushButton : MonoBehaviour
{
    public static event Action<string> ButtonPressed = delegate { };

    private string buttonValue;

    
    void Start()
    {
        buttonValue = gameObject.name;

        gameObject.GetComponent<Button>().onClick.AddListener(ButtonClicked);
    }

    private void ButtonClicked()
	{
        ButtonPressed(buttonValue);
	}
}
