using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{

    [SerializeField] private Button _button;
    [SerializeField] private Transform _target;
    [SerializeField] private Fireballl _bossFireBall;
    [SerializeField] private GameObject _BigFireballSpawnPoint;
    [SerializeField] private GameObject _laugh;

    private bool _BossOn = false;
    private Fireballl _tempBossFireBall;


    private void OnEnable()
    {
        _button.ButtonActivated += OnButtonActivated;
    }

    private void OnDisable()
    {
        _button.ButtonActivated -= OnButtonActivated;
    }

    private void OnButtonActivated()
    {
        _BossOn = true;
    }
    private void Update()
    {
        if (_BossOn)
        {
            transform.LookAt(_target);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;
            if (Physics.SphereCast(ray, 0.1f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.TryGetComponent(out PlayerCharacter playerCharacter))
                {
                    if (_tempBossFireBall == null)
                    {
                        _tempBossFireBall = Instantiate(_bossFireBall, _BigFireballSpawnPoint.transform.position, Quaternion.identity);
                        _tempBossFireBall.transform.rotation = transform.rotation;
                    }
                }
            }
        }
    }

    public void Laugh()
    {
        StartCoroutine(LaughCoroutine());
    }

    private IEnumerator LaughCoroutine()
    {
        _laugh.SetActive(true);

        yield return new WaitForSeconds(2f);

        _laugh.SetActive(false);
    }
}
