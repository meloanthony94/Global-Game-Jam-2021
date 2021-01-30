using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;
using static UnityEngine.InputSystem.InputAction;

public class PlayerInputHandler : MonoBehaviour
{
    PlayerInput playerInput;
    PlayerMovementHandler movement;

    // Start is called before the first frame update
    void Awake()
    {
        playerInput = GetComponent<PlayerInput>();
        var index = playerInput.playerIndex;

        var movementHandlers = FindObjectsOfType<PlayerMovementHandler>();
        movement = movementHandlers.FirstOrDefault(m => m.GetIndex() == index);

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnMove(CallbackContext context)
    {
        if (movement != null)
            movement.Move(context.ReadValue<Vector2>());
    }
}
