
using UnityEngine;

public class PlayerGroundedMovementState : PlayerBaseState
{
    [SerializeField] float maxSpeed = 20.0f;
    [SerializeField] float acceleration = 20.0f / 7.0f;

    [SerializeField] float jumpPower = 20.0f;

    public override void FixedUpdateState()
    {
        base.FixedUpdateState();
        float movementInput = Player.InputManager.GetHorizontalInput();
        var currentVelocity = Player.RigidBody.linearVelocityX;
        currentVelocity = Mathf.MoveTowards(currentVelocity, movementInput * maxSpeed, acceleration);
        currentVelocity = Mathf.Clamp(currentVelocity, -maxSpeed, maxSpeed);
        Player.RigidBody.linearVelocityX = currentVelocity;

        if (movementInput != 0)
        {
            Player.transform.localScale = new Vector3(Mathf.Sign(movementInput), 1, 1);
        }
        else
        {
            StateMachine.TransitionTo<PlayerIdleState>();
        }

    }

    public override void UpdateState()
    {
        base.UpdateState();
        if (Player.InputManager.IsJumpPressed() && IsGrounded())
        {
            Player.RigidBody.linearVelocityY = jumpPower;
        }
    }

   
}
