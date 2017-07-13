using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitConsoleController : MonoBehaviour
{
    public Text consoleText;
    public GameObject PowerButton;
    
    // Use this for initialization
    void Start()
    {
        consoleText.text = "";
    }


    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (StaticData.principalConsole == false && StaticData.powerConsole == true)
            {
                consoleText.text = "Press H to connect the portal";
                PowerButton.SetActive(true);
            }
            else
            {
                if(StaticData.powerConsole == false)
                {
                    consoleText.text = "Power OffLine";
                }
                else
                {
                    consoleText.text = "Portal Online";
                }
            }
                

        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            consoleText.text = "";
            PowerButton.SetActive(false);
        }
    }

}
