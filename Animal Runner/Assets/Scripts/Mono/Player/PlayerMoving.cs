using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoving : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField] 
    private float _speed;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Move()
    {
        _rb.velocity = new Vector2(1 * _speed, _rb.velocity.y);
    }
}
