using DG.Tweening;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

public class TweenManager : MonoBehaviour
{
    [Inject] private ButtonLocker buttonLocker;

    private void Start()
    {
        DOTween.Init();
    }

    async public void ScrollMenuLeft(RectTransform menu, RectTransform settings)
    {
        buttonLocker.LockButtons();
        menu.DOMove(new Vector3(menu.position.x - menu.rect.width, menu.position.y, default), 0.7f);
        Tween tween = settings.DOMove(new Vector3(settings.position.x - settings.rect.width, settings.position.y, default), 0.7f);
        await tween.AsyncWaitForCompletion();
        buttonLocker.UnlockButtons();
    }
    
    async public void ScrollMenuRight(RectTransform menu, RectTransform settings)
    {
        buttonLocker.LockButtons();
        menu.DOMove(new Vector3(menu.position.x + menu.rect.width, menu.position.y, default), 0.7f);
        Tween tween = settings.DOMove(new Vector3(settings.position.x + settings.rect.width, settings.position.y, default), 0.7f);
        await tween.AsyncWaitForCompletion();
        buttonLocker.UnlockButtons();
    }
    
    async public void FadeOut(Image image)
    {
        buttonLocker.LockButtons();
        Tween tween = image.material.DOFade(0, 1.5f);
        await tween.AsyncWaitForCompletion();
        buttonLocker.UnlockButtons();
    }

    async public void FadeInToLoadScene(Image image, int numberOfScene)
    {
        buttonLocker.LockButtons();
        Tween tween = image.material.DOFade(1, 1.5f);
        await tween.AsyncWaitForCompletion();
        buttonLocker.UnlockButtons();
        SceneManager.LoadScene(numberOfScene);
    }
}
