using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteor : MonoBehaviour
{
    public float speed;

    protected virtual void Update()
    {
        transform.Translate(Vector3.down * Time.deltaTime * speed);

        if (transform.position.y < -11f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D whatIHit)
    {
        if (whatIHit.tag == "Player")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().OnGameOver();
            Destroy(whatIHit.gameObject);
            Destroy(this.gameObject);
        } else if (whatIHit.tag == "Laser")
        {
            GameObject.Find("GameManager").GetComponent<GameManager>().MeteorCounter();
            Destroy(whatIHit.gameObject);
            Destroy(this.gameObject);
        }
    }
}
