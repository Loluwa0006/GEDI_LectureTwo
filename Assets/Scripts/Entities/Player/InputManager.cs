using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    [SerializeField] PlayerInput playerInput;

    public float GetHorizontalInput()
    {
        return playerInput.actions["Right"].ReadValue<float>() - playerInput.actions["Left"].ReadValue<float>();
    }

    public bool IsJumpPressed()
    {
        return playerInput.actions["Jump"].triggered;
    }

    public bool IsAttackPressed()
    {
        return playerInput.actions["Attack"].triggered;
    }

    public bool IsInteractivePressed()
    {
        return playerInput.actions["Interact"].triggered;
    }
}
