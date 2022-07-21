using UnityEngine;
using Random = UnityEngine.Random;
using Zenject;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField] private GameObject coin;

    [Inject]
    private DiContainer _container;

    private Vector3 _randomPosition;
    private float _timeToWait = 1f;
    private bool _shouldSpawn = true;
    
    private void GenerateCoin()
    {
        _randomPosition = new Vector3(Random.Range(-6f, 6f), 6, Random.Range(-7f, 7f));
        GameObject newCoin = _container.InstantiatePrefab(coin);
        newCoin.transform.position = _randomPosition;
    }
    
    private void FixedUpdate()
    {
        if (_shouldSpawn)
        {
            GenerateCoin();
            _shouldSpawn = false;
            _timeToWait = 1f;
        }
    }

    private void Update()
    {
        if (_timeToWait > 0)
        {
            _timeToWait -= Time.deltaTime;
        }
        if (_timeToWait <= 0) _shouldSpawn = true;
    }
    
}
