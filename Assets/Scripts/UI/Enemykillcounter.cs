using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Enemykillcounter : MonoBehaviour
{
    [SerializeField] private TMP_Text _scoreIndicator;
    [SerializeField] private RayShooter _shooter;
    
    private void OnEnable()
    {
        _shooter.Enemykilled += OnEnemyKilled;
    }

    private void OnDisable()
    {
        _shooter.Enemykilled -= OnEnemyKilled;
    }

    private void OnEnemyKilled(int deadEnemyCount)
    {   
        _scoreIndicator.text = deadEnemyCount.ToString();
    }
}
