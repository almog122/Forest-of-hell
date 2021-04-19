using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{

    bool isOn = true;
    public GameObject lightSource;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		if (Input.GetButtonDown("Flashlight"))
		{
            isOn = !isOn;
            lightSource.SetActive(isOn);
        }
    }
}
