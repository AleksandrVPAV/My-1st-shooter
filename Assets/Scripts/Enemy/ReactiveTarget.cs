using System.Collections;
using UnityEngine;

public class ReactiveTarget : MonoBehaviour
{
    [SerializeField] private Boom _boom;
    [SerializeField] private Transform _boomSpawnPoint;
    public void ReactToHit()
    {
        if (this.gameObject.TryGetComponent(out WanderingAI behavior));
        {
            behavior.SetAlive(false);   
        }       
        Die();        
    }

    private void Die()
    {
        Destroy(gameObject);
        Instantiate(_boom, _boomSpawnPoint.transform.position, Quaternion.identity);        
    }
}
