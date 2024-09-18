using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerInput : MonoBehaviour
{
    // Runtime
    PlayerControls pControls;

    public Vector2 pMovement;
    public UnityEvent onShoot;


    private void Awake()
    {
        pControls = new PlayerControls();

        // Assign input listeners.
        pControls.Player.Movement.performed += ctx => pMovement = ctx.ReadValue<Vector2>();
        pControls.Player.Shoot.started += ctx => onShoot.Invoke();
    }

    public Vector2 GetPlayerMovement()
    {
        return pMovement;
    }

    private void OnEnable()
    {
        pControls.Enable();
    }

    private void OnDisable()
    {
        pControls.Disable();
    }
}
