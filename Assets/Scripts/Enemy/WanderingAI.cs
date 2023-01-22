using UnityEngine;

public class WanderingAI : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private float _obstacleRange;
    [SerializeField] private Fireballl _fireballl;
    [SerializeField] private GameObject _fireballSpawnPoint;

    private Fireballl _tempFireball;
    private bool _alive;

    private void Start()
    {
        _alive = true;     
    }

    private void Update()
    {
        if (_alive)
        {
            transform.Translate(0, 0, _speed * Time.deltaTime);
            Ray ray = new Ray(transform.position, transform.forward);
            RaycastHit hit;

            if (Physics.SphereCast(ray, 0.75f, out hit))
            {
                GameObject hitObject = hit.transform.gameObject;
                if (hitObject.TryGetComponent(out PlayerCharacter playerCharacter))
                {
                    if (_tempFireball == null)
                    {
                        _tempFireball = Instantiate(_fireballl, _fireballSpawnPoint.transform.position, Quaternion.identity);
                        _tempFireball.transform.rotation = transform.rotation;
                    }
                }
                else if (hit.distance < _obstacleRange)
                {
                    transform.Rotate(0, Random.Range(-110, 110), 0);
                }
            }
        }          
    }

    public void SetAlive(bool alive)       
    {
        _alive = alive;
    }
}
