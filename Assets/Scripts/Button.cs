using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Events;

public class Button : MonoBehaviour
{
    [SerializeField] private Material _onButtonMaterial;
    [SerializeField] private Material _offButtonMaterial;

    public event UnityAction ButtonActivated;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out PlayerCharacter player))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - transform.localScale.y / 2, transform.position.z);
            ButtonActivated?.Invoke();
            GetComponent<Renderer>().material = _onButtonMaterial;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out PlayerCharacter player))
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + transform.localScale.y / 2, transform.position.z);
            GetComponent<Renderer>().material = _offButtonMaterial;
        }
    }    
}
    