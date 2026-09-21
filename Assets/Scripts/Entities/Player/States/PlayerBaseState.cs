using UnityEngine;

public class PlayerBaseState : BaseState
{
    public PlayerEntity Player { set; get; }

    public static LayerMask groundMask;
    public override void InitializeState(EntityStateMachine stateMachine, BaseEntity entity)
    {
        base.InitializeState(stateMachine, entity);
        Player = Entity.GetComponent<PlayerEntity>();
        groundMask = LayerMask.GetMask("Ground", "Brick");
    }

    public bool IsGrounded()
    {
        var raycast = Physics2D.Raycast(Player.RigidBody.position, Vector2.down, 1.1f, groundMask);
        return raycast.collider != null;
    }
}
