using UnityEngine;

public class IDComponent : MonoBehaviour
{

    public enum IDType
    {
        Player,
        Enemy,
        Coin,

        Brick
    }
    public static int nextID = 0;

    public int ID { get; private set; }

    [SerializeField] IDType entityType;
    public IDType EntityType { get => entityType; }

    private void Start()
    {
        nextID++;
        ID = nextID;       
    }


}
