using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Saw : DeadTrigger
{
    private float _speed;
    [SerializeField]
    private float _minY;
    [SerializeField]
    private float _maxY;

    private float t = 0.0f;

    private void Update()
    {
        MoveSaw();
    }

    private void MoveSaw()
    {
        transform.localPosition = new Vector3(0, Mathf.Lerp(_minY, _maxY, t), 0);

        //   speed
        t += 0.5f * Time.deltaTime;

        if (t > 1.0f)
        {
            float temp = _maxY;
            _maxY = _minY;
            _minY = temp;
            t = 0.0f;
        }
    }
}
