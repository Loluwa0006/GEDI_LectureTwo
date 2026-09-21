using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }
    [SerializeField] CoinManager coinManager;

    [SerializeField] int coinsToWin = 3;
    [SerializeField] float timeToWin = 15.0f;

    [SerializeField] TMP_Text timerDisplay;
    float timer = 0f;
    bool gameOver = false;

    private void Awake()
    {
        timer = timeToWin;
    }

    private void Start()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void OnCoinCollected()
    {
        if (gameOver) return;
        if (coinManager.CoinsCollected >= coinsToWin)
        {
           timerDisplay.text = "WIN!";
           gameOver = true;
        }
    }

    private void Update()
    {
        if (gameOver) return;
        timer -= Time.deltaTime;
        timerDisplay.text = "Time: " + timer.ToString("F2");
        if (timer <= 0)
        {
            timerDisplay.text = "LOSE...";
            gameOver = true;
        }
    }
}
