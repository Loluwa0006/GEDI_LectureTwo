using UnityEngine;

public class PlayerIdleState : PlayerGroundedMovementState
{
    [SerializeField] float decelerationRate = 20.0f / 4;

    public override void FixedUpdateState()
    {
        var currentVelocity = Player.RigidBody.linearVelocityX;
        currentVelocity = Mathf.MoveTowards(currentVelocity, 0, decelerationRate);
        Player.RigidBody.linearVelocityX = currentVelocity;
        if (Player.InputManager.GetHorizontalInput() != 0)
        {
            StateMachine.TransitionTo<PlayerRunState>();
        }
    }


}
