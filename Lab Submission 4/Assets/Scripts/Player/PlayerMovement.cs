using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // Runtime
    PlayerInput pInput;

    private float speed = 6f;
    private float horizontalScreenLimit = 10f;
    private float verticalScreenLimit = 6f;


    private void Awake()
    {
        pInput = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        Movement();
    }

    void Movement()
    {
        Vector2 pMovement = pInput.GetPlayerMovement();

        transform.Translate(new Vector3(pMovement.x, pMovement.y, 0) * Time.deltaTime * speed);
        if (transform.position.x > horizontalScreenLimit || transform.position.x <= -horizontalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x * -1f, transform.position.y, 0);
        }
        if (transform.position.y > verticalScreenLimit || transform.position.y <= -verticalScreenLimit)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y * -1, 0);
        }
    }
}
