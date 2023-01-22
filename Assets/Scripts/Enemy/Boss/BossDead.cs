using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDead : MonoBehaviour
{
    [SerializeField] private Boss _boss;
    [SerializeField] private FirstBossButton _firstBossButton;
    [SerializeField] private SecondBossButton _secondBossButton;
    [SerializeField] private FallingWall _fallingWall;
    [SerializeField] private AudioSource _bossDeadSound;

    private void Update()
    {
        if (_firstBossButton.On == true && _secondBossButton.On == true)
        {
            StartCoroutine(BossDeading());
        }
    }

    private IEnumerator BossDeading()       
    {
        _fallingWall.Fall();
        _fallingWall.BigBossBoom();
        _firstBossButton.On = false;
        _secondBossButton.On = false;

        yield return new WaitForSeconds(2);       

        Destroy(_boss.gameObject);
        _bossDeadSound.Play();
    }
}
