using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof(PlayerController))]
public class InputHandler : MonoBehaviour
{
    PlayerController _playerController;

    private void Awake(){
        _playerController = GetComponent<PlayerController>();
    }

    public void Move(InputAction.CallbackContext ctx){
        if (_playerController) _playerController.HandleMoveInputs(ctx.ReadValue<Vector2>());   
    }

    public void Dash(InputAction.CallbackContext ctx){
        // if (_playerController && ctx.started) _playerController.HandleDash();
    }

    public void Interact(InputAction.CallbackContext ctx){
        // if (_playerController && ctx.started) _playerController.HandleInteract();
    }

}
