using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerButton : MonoBehaviour {

    private GameObject power;

    public Text consoleText;

    void Start()
    {
        power = GameObject.Find("PowerOn");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ActionButton") && StaticData.powerConsole == false);
        {
            power.GetComponent<AudioSource>().Play();
            StaticData.powerConsole = true;
            StaticData.adventurePath = 4;
            consoleText.text = "Power online";
        }
    }
}
