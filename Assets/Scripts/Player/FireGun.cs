using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FireGun : MonoBehaviour
{

    public GameObject gun;
    public Camera cam;
    public GameObject muzzleFlash;
    public AudioSource FireSound;

    Player_Stats playerStats;
    public GameObject talkTextBox;
    Text textBox;

    bool isFiring = false;
    public float targetDistance;
    public int damageAmount = 25;


	private void Start()
	{
        playerStats = Player_manager.instance.Player.GetComponent<Player_Stats>();

        textBox = talkTextBox.GetComponent<Text>();

    }
	// Update is called once per frame
	void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {

            if (playerStats.currentAmmo > 1)
            {
                StartCoroutine(FiringGun());
            }
			else
			{
                StartCoroutine(EmptyGun());
            }


        }

    }

    IEnumerator FiringGun()
	{
        RaycastHit shot;

        isFiring = true;
        if (Physics.Raycast(cam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0.0f)), cam.transform.forward, out shot))
        {
            targetDistance = shot.distance;
            if (shot.collider.GetComponentInParent<Enemy_stats>() != null) { 
                shot.collider.GetComponentInParent<Enemy_stats>().takeDamage(damageAmount);
            }


            playerStats.currentAmmo--;
        }
        muzzleFlash.SetActive(true);
        FireSound.Play();

        yield return new WaitForSeconds(0.5f);

        muzzleFlash.SetActive(false);
        isFiring = false;

    }

    IEnumerator EmptyGun()
    {
        textBox.text = "I will keep the last bullet .. just in case";
        //FireSound.Play(); // need to add empty magzine sound

        yield return new WaitForSeconds(1f);

        textBox.text = "";
    }



}
