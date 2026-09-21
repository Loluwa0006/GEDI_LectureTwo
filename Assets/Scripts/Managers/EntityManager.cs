using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class EntityManager : MonoBehaviour
{
    public static EntityManager Instance { get; private set; }
    Dictionary<IDComponent, BaseEntity> entityLookup = new Dictionary<IDComponent, BaseEntity>();
    Dictionary<IDComponent.IDType, List<BaseEntity>> entityTypeLookup = new Dictionary<IDComponent.IDType, List<BaseEntity>>();
    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Debug.LogError("Multiple instances of EntityManager detected. There should only be one EntityManager in the scene.");
            Destroy(this);
            return;
        }
        var entities = FindObjectsByType<BaseEntity>(FindObjectsSortMode.None);
        entities = entities.OrderBy(e => e.InitializationPriority).ToArray();

        foreach (var entity in entities)
        {
            Debug.Log($"Initializing entity: {entity.name} with priority {entity.InitializationPriority}");
            entity.InitializeEntity();
            entity.EntityDestroyed += () => OnEntityDestroyed(entity);
            entityLookup.Add(entity.ID, entity);
            if (!entityTypeLookup.ContainsKey(entity.ID.EntityType))
            {
                entityTypeLookup[entity.ID.EntityType] = new List<BaseEntity>();
            }
            entityTypeLookup[entity.ID.EntityType].Add(entity);
        }
    }

    void OnEntityDestroyed(BaseEntity entity)
    {
        if (entity.TryGetComponent<IDComponent>(out var idComponent))
        {
            entityLookup.Remove(idComponent);
        }
    }

    void Update()
    {
        foreach (var entity in entityLookup.Values)
        {
            entity.UpdateEntity();
        }
    }

    private void FixedUpdate()
    {
        foreach (var entity in entityLookup.Values)
        {
            entity.FixedUpdateEntity();
        }

    }

    public void RegisterEntity(BaseEntity entity)
    {
        if (entity.TryGetComponent<IDComponent>(out var idComponent))
        {
            if (!entityLookup.ContainsKey(idComponent))
            {
                entityLookup.Add(idComponent, entity);
            }
            else
            {
                Debug.LogWarning($"Entity with ID {idComponent.ID} is already registered.");
            }
        }
        else
        {
            Debug.LogError("Attempted to register an entity without an IDComponent.");
        }
    }

    public BaseEntity GetEntityByID(int id)
    {
        foreach (var kvp in entityLookup)
        {
            if (kvp.Key.ID == id)
            {
                return kvp.Value;
            }
        }
        Debug.LogWarning($"Entity with ID {id} not found.");
        return null;
    }
    
    public List<BaseEntity> GetEntitiesByType(IDComponent.IDType entityType)
    {
        if (entityTypeLookup.TryGetValue(entityType, out var entities))
        {
            return entities;
        }
        else
        {
            Debug.LogWarning($"No entities of type {entityType} found.");
            return new List<BaseEntity>();
        }
    }


}
