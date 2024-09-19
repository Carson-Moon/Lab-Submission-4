using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigMeteor : Meteor
{
    private int hitCount = 0;

    protected override void Update()
    {
        base.Update();

        if (hitCount >= 5)
        {
            CameraController.instance.ZoomIn();
            Instantiate(deathEffect);
            Destroy(this.gameObject);
            CameraController.instance.BigMeteorExplosion(20f,5f);
        }
    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.tag == "Player")
        {
            Instantiate(playerDeathEffect);
            GameObject.Find("GameManager").GetComponent<GameManager>().gameOver = true;
            Destroy(whatIHit.gameObject);
        }
        else if (whatIHit.tag == "Laser")
        {
            hitCount++;
            Destroy(whatIHit.gameObject);
        }
    }
}
