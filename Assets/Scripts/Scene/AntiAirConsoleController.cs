using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AntiAirConsoleController : MonoBehaviour
{

    public Text consoleText;
    public GameObject PowerButon;
	// Use this for initialization
	void Start ()
    {
        consoleText.text = "";
	}


    void OnTriggerEnter (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (StaticData.antiAirDefense == true)
            {
                consoleText.text = "Press H to power off anti air defenses";
                PowerButon.SetActive(true);
            }
            else
            {
                consoleText.text = "Anti air defenses offline";
            }
                

            }
        }

    void OnTriggerExit (Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            consoleText.text = "";
            PowerButon.SetActive(false);
        }
    }

}
	
	

