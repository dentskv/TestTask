using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private GameViewController gameViewController;

    private int _coinCount = 0;
    
    private void Start()
    {
        if (!PlayerPrefs.HasKey("Coins"))
        {
            PlayerPrefs.SetInt("Coins", 0);
        }
        else
        {
            _coinCount = PlayerPrefs.GetInt("Coins");
        }
        
        gameViewController.UpdateCoins(_coinCount);
    }

    public void AddCoin()
    {
        _coinCount++;
        gameViewController.UpdateCoins(_coinCount);
    }

    private void OnDisable()
    {
        PlayerPrefs.SetInt("Coins", _coinCount);
    }
}
