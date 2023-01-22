using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SceneController : MonoBehaviour
{
    [SerializeField] private Enemy _enemy;
    [SerializeField] private int _amountEnemies;
    [SerializeField] private EnemySpawnPoint[] _enemySpawnPoints;
    [SerializeField] private GameObject _fire;
    [SerializeField] private GameObject _button;
    [SerializeField] private GameObject _bossMessage;
    [SerializeField] private RayShooter _rayShooter;

    private Enemy _tempEnemy;
    private int _deadEnemyCount;

    private void OnEnable()
    {
        _rayShooter.Enemykilled += OnEnemykilled;
    }

    private void OnDisable()
    {
        _rayShooter.Enemykilled -= OnEnemykilled;
    }

    private void OnEnemykilled(int deadEnemyCount)
    {
        _deadEnemyCount = deadEnemyCount;
    }

    private void Update()
    {                      
        for (int i = 0; i < _enemySpawnPoints.Length; i++)
        {
            if (_tempEnemy == null && _deadEnemyCount < _amountEnemies)
            {
                int randomSpawmPoint = Random.Range(0, _enemySpawnPoints.Length);
                _tempEnemy = Instantiate(_enemy, _enemySpawnPoints[randomSpawmPoint].transform.position, Quaternion.identity);
                _tempEnemy.transform.Rotate(0, Random.Range(0, 360), 0);
            }
            else if (_deadEnemyCount == _amountEnemies)
            {
                _fire.SetActive(true);
                StartCoroutine(BossMessageActive());
            }
        }
    }   

    private IEnumerator BossMessageActive()
    {
        _bossMessage.SetActive(true);
        _button.SetActive(true);
        yield return new WaitForSeconds(3f);

        Destroy(_bossMessage);
    }
}
    
    