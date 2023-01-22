using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;


public class Gun : MonoBehaviour
{
    [SerializeField] private Material _shootOff;
    [SerializeField] private Material _shootOn;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Renderer>().material = _shootOn;
        }

        if (Input.GetMouseButtonUp(0))
        {
            GetComponent<Renderer>().material = _shootOff;
        }
    }
}
