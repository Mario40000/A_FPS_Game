using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PowerConsoleController : MonoBehaviour {

    public Text consoleText;
    public GameObject PowerButon;
    // Use this for initialization
    void Start()
    {
        consoleText.text = "";
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (StaticData.powerConsole == false && StaticData.antiAirDefense == false)
            {
                consoleText.text = "Press H to power online";
                PowerButon.SetActive(true);
            }
            else
            {
                if(StaticData.antiAirDefense  == true)
                {
                    consoleText.text = "Shut down aerial defenses first";
                }
                else
                {
                    consoleText.text = "Power online";
                }
            }
                

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            consoleText.text = "";
            PowerButon.SetActive(false);
        }
    }
}
