using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossButton : MonoBehaviour
{
    [SerializeField] private Material _buttonOn;
    [SerializeField] private Material _buttonOff;
    
    public bool On = false;
    private void Update()
    {
        if (On == false)
        {
            GetComponent<Renderer>().material = _buttonOff;
        }

        if (On == true)
        {
            GetComponent<Renderer>().material = _buttonOn;
        }
    }
}

