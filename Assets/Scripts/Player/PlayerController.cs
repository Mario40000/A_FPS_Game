using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {

    public GameObject gun;
    public GameObject rifle;
    public GameObject detector;
    public GameObject bulletDecal;
    public GameObject flash;
    public Transform revolverInstancier;
    public Transform rifleInstancier;
    

    public float revolverDamage;
    public float rifleDamage;
    public float revolverShootDelay;
    public float rifleShootDelay;
    public float revolverReloadDelay;
    public float rifleReloadDelay;

    private GameObject cockRifle;
    private GameObject gunShoot;
    private GameObject rifleShoot;
    private GameObject reload;
    private GameObject outOfAmmo;
    private float actualTimeBetweenShoots = 0;
    private bool reloading = false;


    // Use this for initialization
    void Start ()
    {

        gun.SetActive(true);
        rifle.SetActive(false);
        detector.SetActive(false);

        cockRifle = GameObject.Find("CockRifle");
        gunShoot = GameObject.Find("RevolverShoot");
        rifleShoot = GameObject.Find("RifleShoot");
        reload = GameObject.Find("ReloadWeapon");
        outOfAmmo = GameObject.Find("OutOfAmmo");
    }
	
	// Update is called once per frame
	void Update ()
    {
        
        actualTimeBetweenShoots += Time.deltaTime;
        //Cambiamos de armas si las tenemos
        if (Input.GetButtonDown("Rifle") && StaticData.rifle == 1)
        {
            
            gun.SetActive(false);
            rifle.SetActive(true);
            detector.SetActive(false);
            StaticData.weaponSelected = 2;
            cockRifle.GetComponent<AudioSource>().Play();
        }

        if (Input.GetButtonDown("Detector") && StaticData.mineDetector == 1)
        {
            gun.SetActive(false);
            rifle.SetActive(false);
            detector.SetActive(true);
            StaticData.weaponSelected = 3;
            cockRifle.GetComponent<AudioSource>().Play();
        }

        if (Input.GetButtonDown("Gun") && StaticData.gun == 1)
        {
            gun.SetActive(true);
            rifle.SetActive(false);
            detector.SetActive(false);
            StaticData.weaponSelected = 1;
            cockRifle.GetComponent<AudioSource>().Play();
        }

        if (Input.GetMouseButtonDown(0) && StaticData.weaponSelected == 1)
        {
            if (actualTimeBetweenShoots > revolverShootDelay && reloading == false)
            {
                actualTimeBetweenShoots = 0;
                revolverFire();
            }
            
        }

        if (Input.GetMouseButton(0) && StaticData.weaponSelected == 2 && reloading == false)
        {
            if (actualTimeBetweenShoots > rifleShootDelay)
            {
                actualTimeBetweenShoots = 0;
                rifleFire();
            }
            
        }
    }

    //Metodo para el revolver
    void revolverFire ()
    {
        if (StaticData.gunBullets > 0)
        {
            StaticData.gunBullets--;
            Instantiate(flash, revolverInstancier.position, Quaternion.identity);
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)),
                out hit))
            {
                Instantiate(bulletDecal,
                    hit.point + hit.normal * 0.01f,
                    Quaternion.FromToRotation(Vector3.forward, -hit.normal));

                gunShoot.GetComponent<AudioSource>().Play();
                //Si le damos al enemigo aplicamos daño
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    hit.collider.gameObject.GetComponentInParent<PatrolDroneAI>().Hit(revolverDamage);
                }
                else if (hit.collider.gameObject.tag == "Turret")
                {
                    hit.collider.gameObject.GetComponentInParent<TurretAI>().Hit(revolverDamage);
                }
            }
        }
        else
        {
            StartCoroutine(RevolverReload());
        }
        
    }

    //Metodo para el rifle
    void rifleFire()
    {
        if (StaticData.rifleBullets > 0)
        {
            StaticData.rifleBullets--;
            Instantiate(flash, rifleInstancier.position, Quaternion.identity);
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0)),
                out hit))
            {
                Instantiate(bulletDecal,
                    hit.point + hit.normal * 0.01f,
                    Quaternion.FromToRotation(Vector3.forward, -hit.normal));

                rifleShoot.GetComponent<AudioSource>().Play();
                //Si le damos al enemigo aplicamos daño
                if (hit.collider.gameObject.tag == "Enemy")
                {
                    hit.collider.GetComponentInParent<PatrolDroneAI>().Hit(rifleDamage);
                }
                else if (hit.collider.gameObject.tag == "Turret")
                {
                    hit.collider.gameObject.GetComponentInParent<TurretAI>().Hit(rifleDamage);
                }
            }
            
        }
        else
        {
            StartCoroutine(RifleReload());
        }

    }

    //Metodo para recargar el revolver
    IEnumerator RevolverReload()
    {
        if (StaticData.gunClips > 0)
        {
            reloading = true;
            reload.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(revolverReloadDelay);
            StaticData.gunBullets = 6;
            StaticData.gunClips--;
            reloading = false;
        }
        else
        {
            outOfAmmo.GetComponent<AudioSource>().Play();
        }
        
    }
    //Metodo para recargar el rifle
    IEnumerator RifleReload()
    {
        if (StaticData.rifleClips > 0)
        {
            reloading = true;
            reload.GetComponent<AudioSource>().Play();
            yield return new WaitForSeconds(rifleReloadDelay);
            StaticData.rifleBullets = 30;
            StaticData.rifleClips--;
            reloading = false;
        }
        else
        {
            outOfAmmo.GetComponent<AudioSource>().Play();
        }

    }
}
