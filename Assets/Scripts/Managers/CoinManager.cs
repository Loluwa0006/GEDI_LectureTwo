using UnityEngine;

public class CoinManager : BaseEntity
{
    public int CoinsCollected { get; private set; } = 0;

    public override void InitializeEntity()
    {
        base.InitializeEntity();
        var coins = EntityManager.Instance.GetEntitiesByType(IDComponent.IDType.Coin);

        foreach (var coin in coins)
        {
            if (coin.TryGetComponent<CoinEntity>(out var coinEntity))
            {
                coinEntity.CoinCollected += OnCoinCollected;
            }
        }
    }

    void OnCoinCollected()
    {
        CoinsCollected++;
        GameManager.Instance.OnCoinCollected();
    }
}
