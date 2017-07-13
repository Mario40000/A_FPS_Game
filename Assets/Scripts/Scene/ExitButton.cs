using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitButton : MonoBehaviour {

    private GameObject power;

    public Text consoleText;
    public GameObject portal;

    void Start()
    {
        portal.SetActive(false);
        power = GameObject.Find("PortalSound");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("ActionButton") && StaticData.powerConsole == false) ;
        {
            
            StaticData.principalConsole = true;
            StaticData.adventurePath = 5;
            consoleText.text = "Portal Online";
            portal.SetActive(true);
        }
    }
}
