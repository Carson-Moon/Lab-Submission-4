using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    // Runtime
    AudioSource pSource;

    public GameObject laserPrefab;
    private bool canShoot = true;
    public AudioClip shootSFX;


    private void Awake()
    {
        pSource = GetComponent<AudioSource>();
    }

    public void Shooting()
    {
        if(canShoot)
        {
            Instantiate(laserPrefab, transform.position + new Vector3(0, 1, 0), Quaternion.identity);
            canShoot = false;
            pSource.PlayOneShot(shootSFX);
            StartCoroutine("Cooldown");
        }
    }

    private IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(1f);
        canShoot = true;
    }
}
