using System;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(IDComponent))]
public class BaseEntity : MonoBehaviour
{

    [SerializeField] EntityStateMachine stateMachine;
    [SerializeField] int initializationPriority;

    [SerializeField] IDComponent IDComponent;

    public event Action EntityDestroyed;

    public int InitializationPriority
    {
        get { return initializationPriority; }
    }
    public EntityStateMachine StateMachine
    {
        get { return stateMachine; }
    }

    public IDComponent ID
    {
        get { return IDComponent; }
    }
    public virtual void InitializeEntity()
    {
        if (stateMachine != null)
        {
            stateMachine.InitializeStateMachine();
        }
        if (IDComponent == null)
        {
            IDComponent = GetComponent<IDComponent>();
        }
    }

    public virtual void UpdateEntity()
    {
        if (stateMachine != null)
        {
            stateMachine.UpdateStateMachine();
        }
    }

    public virtual void FixedUpdateEntity()
    {
        if (stateMachine != null)
        {
            stateMachine.FixedUpdateStateMachine();
        }
    }

    public virtual void DestroyEntity()
    {
        EntityDestroyed?.Invoke();
        Destroy(gameObject);
    }
}
