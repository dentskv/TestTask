using UnityEngine;
using Zenject;

public class GameMonoInstaller : MonoInstaller
{
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private TweenManager tweenManager;
    [SerializeField] private ButtonLocker buttonLocker;
    [SerializeField] private GameManager gameManager;
    
    public override void InstallBindings()
    {
        Container.BindInstance(audioManager);
        Container.BindInstance(buttonLocker);
        Container.BindInstance(tweenManager);
        Container.BindInstance(gameManager);
    }
}