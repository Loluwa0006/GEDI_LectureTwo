using System.Collections.Generic;
using UnityEngine;

public class EntityStateMachine : MonoBehaviour
{
    Dictionary<System.Type, BaseState> states = new();
    [SerializeField] BaseState initialState;
    [SerializeField] BaseEntity machineOwner;
    public void InitializeStateMachine()
    {
        var stateComponents = GetComponentsInChildren<BaseState>();
        foreach (var state in stateComponents)
        {
            states.Add(state.GetType(), state);
            state.StateMachine = this;
            if (initialState == null)
            {
                initialState = state;
            }
            state.InitializeState(this, machineOwner);
        }
        if (initialState != null)
        {
            initialState.EnterState();
        }
    }
    public void TransitionTo<T>() where T : BaseState
    {
        if (states.TryGetValue(typeof(T), out BaseState newState))
        {
            if (initialState != null)
            {
                initialState.ExitState();
            }
            initialState = newState;
            initialState.EnterState();
        }
        else
        {
            Debug.LogError($"State of type {typeof(T)} not found in the state machine.");
        }
    }
    public void UpdateStateMachine()
    {
        if (initialState != null)
        {
            initialState.UpdateState();
        }
    }

    public void FixedUpdateStateMachine()
    {
        if (initialState != null)
        {
            initialState.FixedUpdateState();
        }
    }
}
