using UnityEngine;

public class BaseState : MonoBehaviour
{
    public EntityStateMachine StateMachine { set; get; }
    public virtual BaseEntity Entity { set; get; }

    public virtual void InitializeState(EntityStateMachine stateMachine, BaseEntity entity)
    {
        StateMachine = stateMachine;
        Entity = entity;
    } 
    public virtual void EnterState()
    {
        // Code to execute when entering the state
    }

    public virtual void ExitState()
    {
        // Code to execute when exiting the state
    }   

    public virtual void UpdateState()
    {
        // Code to execute during the state update
    }

    public virtual void FixedUpdateState()
    {
        // Code to execute during the state fixed update
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
