using UnityEngine;

public class Fireballl : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    private void FixedUpdate()
    {
        transform.Translate(0,0,  _speed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerCharacter player))
        {
            player.Hurt(_damage);      
        }
        Destroy(gameObject);
    }
}
