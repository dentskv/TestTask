using DG.Tweening;
using UnityEngine;
using Zenject;

public class CoinController : MonoBehaviour
{
    [Inject] private GameManager gameManager;
    
    private Transform _transform;
    private Collider _collider;
    private Tween _tweenRotate;
    private Tween _tweenScale;
    private float _timeToDestroy = 5f;
    private bool _onGround;
    
    private void Start()
    {
        _transform = GetComponent<Transform>();
        _collider = GetComponent<Collider>();
        _tweenRotate = _transform.DORotate(new Vector3(-90, 180, 0), 1f).SetLoops(-1).SetEase(Ease.Linear);
    }

    private void Update()
    {
        if (_onGround)
        {
            _timeToDestroy -= Time.deltaTime;
        }
        if(_timeToDestroy <= 0)
        {
            DestroyCoin();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            gameManager.AddCoin();
            Destroy(gameObject);
        }

        if (collision.collider.CompareTag("Ground"))
        {
            _onGround = true;
        }
    }

    private void DestroyCoin()
    {
        Destroy(gameObject);
    }

    private void OnDestroy()
    {
        _tweenRotate.Kill();
    }
}
