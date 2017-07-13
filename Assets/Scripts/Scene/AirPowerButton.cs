using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AirPowerButton : MonoBehaviour
{

    private GameObject power;

    public Text consoleText;

    void Start ()
    {
        power = GameObject.Find("PowerDown");
    }
	
	// Update is called once per frame
	void Update ()
    {
		if (Input.GetButtonDown("ActionButton") && StaticData.antiAirDefense == true)
        {
            power.GetComponent<AudioSource>().Play();
            StaticData.antiAirDefense = false;
            StaticData.adventurePath = 3;
            consoleText.text = "Anti air defenses offline";
        }
	}
}
