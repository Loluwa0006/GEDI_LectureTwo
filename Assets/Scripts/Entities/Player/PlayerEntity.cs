using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(PlayerInput))]
public class PlayerEntity : BaseEntity
{
    [SerializeField] Rigidbody2D rigidBody;

    public Rigidbody2D RigidBody
    {
        get { return rigidBody; }
    }

    [SerializeField] InputManager inputManager;

    public InputManager InputManager
    {
        get { return inputManager; }
    }

    [SerializeField] BoxCollider2D playerCollider;

    public BoxCollider2D PlayerCollider
    {
        get { return playerCollider; }
    }

}
