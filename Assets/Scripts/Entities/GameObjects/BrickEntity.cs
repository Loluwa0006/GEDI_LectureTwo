using UnityEngine;

public class BrickEntity : BaseEntity 
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.contacts[0].normal == Vector2.up)
        {
            Destroy(gameObject);
        }
    }
}
