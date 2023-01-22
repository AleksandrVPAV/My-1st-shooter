using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;  

public class PlayerCharacter : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private Slider _slider;
    [SerializeField] private float _filledDuration;
   
    private void Update()
    {
        _slider.DOValue(_health, _filledDuration);
    }
        
    public void Hurt(int damage)
    {
        _health -= damage;
    }
}
