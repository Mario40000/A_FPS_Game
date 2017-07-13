using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public Text currentAmmo;
    public Text helpText;
    public Text consoleText;

    public GameObject player;
    private GameObject currentPlayer;
    public GameObject camera1;
    public Transform[] instanciers;
    

    // Use this for initialization
    void Start ()
    {
        StaticDataRefresh();
        consoleText.text = "";
        camera1.SetActive(false);
        StartCoroutine(ShieldsController());
        Instantiate(player, instanciers[StaticData.respawn].position, Quaternion.identity);
        currentPlayer = GameObject.FindGameObjectWithTag("Player");
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        ammoText();
        currentHelpText();

        if(StaticData.life <= 0)
        {
            StaticData.alive = false;
            killPlayer();
        }
    }

    //Metodo para actualizar el texto de la municion
    void ammoText()
    {
        if (StaticData.weaponSelected == 1)
        {
            currentAmmo.text = "Remain: " + StaticData.gunBullets + " / " + StaticData.gunClips;
        }

        if (StaticData.weaponSelected == 2)
        {
            currentAmmo.text = "Remain: " + StaticData.rifleBullets + " / " + StaticData.rifleClips;
        }

        if (StaticData.weaponSelected == 3)
        {
            currentAmmo.text = "Detecting...";
        }
    }

    //Metodo para actualizar el mensaje de ayuda
    void currentHelpText ()
    {
        if (StaticData.adventurePath == 0)
        {
            helpText.text = "Looking for a mine detector";
        }

        if (StaticData.adventurePath == 1)
        {
            helpText.text = "Cross the minefield";
        }

        if (StaticData.adventurePath == 2)
        {
            helpText.text = "Disable the anti air defenses";
        }

        if (StaticData.adventurePath == 3)
        {
            helpText.text = "Turns main console power on";
        }

        if (StaticData.adventurePath == 4)
        {
            helpText.text = "Connect the portal";
        }

        if (StaticData.adventurePath == 5)
        {
            helpText.text = "Cross the portal";
        }
    }

    //Metodo para actualizar los escudos

    IEnumerator ShieldsController()
    {
        while (StaticData.alive)
        {
            if(StaticData.armor >= 0 && StaticData.armor < 100)
            {
                StaticData.armor += 2;
            }

            if(StaticData.armor > 100)
            {
                StaticData.armor = 100;
            }

            if(StaticData.armor < 0)
            {
                StaticData.armor = 0;
            }

            if(StaticData.life > 100)
            {
                StaticData.life = 100;
            }

            yield return new WaitForSeconds(1);
        }

        
    }

    //Metodo para la muerte del player
    void killPlayer()
    {
        camera1.SetActive(true);
        consoleText.text = "Press Space to continue or ESC to Exit";
        Destroy(currentPlayer.gameObject);
    }


    //Metodo para reiniciar los datos estaticos
    void StaticDataRefresh()
    {
        StaticData.weaponSelected = 1;
        StaticData.armor = 100;
        StaticData.life = 100;
        StaticData.gunClips = 5;
        StaticData.rifleClips = 5;
        StaticData.rifleBullets = 30;
        StaticData.gunBullets = 6;
        StaticData.alive = true;
    
    }
}
