using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class FallingWall : MonoBehaviour
{
    [SerializeField] private FallingWall _fallingWall;
    [SerializeField] private float _fallingSpeed;
    [SerializeField] private Boom _boom;
    [SerializeField] private Transform[] _bigBossBoomSpawnPoint;

    public void Fall()
    {
        _fallingWall.transform.DORotate(new Vector3(0, 0, -90), _fallingSpeed);
    }

    public void BigBossBoom()
    {
        for (int i = 0; i < _bigBossBoomSpawnPoint.Length; i++)
        {
            Instantiate(_boom, _bigBossBoomSpawnPoint[i]);
        }        
    }
}
