using UnityEngine;
using DG.Tweening;

public class Gate : MonoBehaviour
{
    [SerializeField] private float _openingSpeed;
    [SerializeField] private Button _button;
    private void OnEnable()
    {
        _button.ButtonActivated += OnButtonActive;
    }

    private void OnDisable()
    {
        _button.ButtonActivated -= OnButtonActive;
    }

    private void OnButtonActive()
    {       
        GateOpening();
    }

    private void GateOpening()
    {
        transform.DORotate(new Vector3(0, 0, -90), _openingSpeed);
    }
}
