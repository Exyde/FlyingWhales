using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SineIdle : MonoBehaviour
{
    [SerializeField] float _speed;
    [SerializeField] float _amplitude;
    Vector3 _startPos;

    private void Start()
    {
        _startPos = transform.position;
    }

    private void Update()
    {
        transform.position = _startPos + new Vector3 (0f, Mathf.Sin(Time.time * _speed)  * _amplitude, 0f);
    }
}
