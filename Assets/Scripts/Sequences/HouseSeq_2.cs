using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseSeq_2 : MonoBehaviour
{

    public GameObject player;

    public GameObject talkTextBox;

    Text textBox;

    // Start is called before the first frame update
    void Start()
    {
        textBox = talkTextBox.GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
