using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireGun : MonoBehaviour
{

    public GameObject gun;
    public GameObject muzzleFlash;
    public AudioSource FireSound;

    bool isFiring = false;
    public float targetDistance;
    public int damageAmount = 5;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            StartCoroutine(FiringGun());


        }

    }

    IEnumerator FiringGun()
	{
        RaycastHit shot;

        isFiring = true;
        if(Physics.Raycast(transform.position, transform.TransformDirection (Vector3.forward), out shot))
		{
            targetDistance = shot.distance;
            shot.transform.SendMessage("Damage Enemy", damageAmount, SendMessageOptions.DontRequireReceiver);
        }
        muzzleFlash.SetActive(true);
        FireSound.Play();

        yield return new WaitForSeconds(0.5f);

        muzzleFlash.SetActive(false);
        isFiring = false;

    }



}
