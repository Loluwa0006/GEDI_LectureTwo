using System;
using UnityEngine;

public class CoinEntity : BaseEntity
{

    public event Action CoinCollected;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        CoinCollected?.Invoke();
        gameObject.SetActive(false);
    }
}
