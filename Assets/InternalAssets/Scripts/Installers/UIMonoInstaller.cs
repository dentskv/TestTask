using UnityEngine;
using Zenject;

public class UIMonoInstaller : MonoInstaller
{
    [SerializeField] private ButtonLocker buttonLocker;
    [SerializeField] private TweenManager tweenManager;
    [SerializeField] private AudioManager audioManager;
    [SerializeField] private LoadingAssetBundles loadingAssetBundles;
    
    public override void InstallBindings()
    {
        Container.BindInstance(loadingAssetBundles);
        Container.BindInstance(audioManager);
        Container.BindInstance(buttonLocker);
        Container.BindInstance(tweenManager);
    }
}