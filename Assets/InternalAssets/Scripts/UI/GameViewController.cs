using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameViewController : MonoBehaviour
{
    [Inject] private TweenManager tweenManager;
    [Inject] private AudioManager audioManager;
    
    [SerializeField] private TMP_Text coinText;
    [SerializeField] private Button menuButton;
    [SerializeField] private Image fadingPanel;

    private void Awake()
    {
        fadingPanel.material.color = Color.black;
    }

    private void Start()
    {
        menuButton.onClick.AddListener(OnMenuButtonClick);
        tweenManager.FadeOut(fadingPanel);
    }

    private void OnMenuButtonClick()
    {
        audioManager.PlayClickSound();
        tweenManager.FadeInToLoadScene(fadingPanel, 0);
    }

    public void UpdateCoins(int count)
    {
        coinText.text = "Coins: " + count;
    }
}
