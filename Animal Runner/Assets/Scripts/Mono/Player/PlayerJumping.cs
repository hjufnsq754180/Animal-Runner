using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumping : MonoBehaviour
{
    private Rigidbody2D _rb;
    [SerializeField]
    private float _jumpForce;

    private bool _isGrounded;
    private Transform _feetPos;
    public float checkRadius;
    private LayerMask _whatIsGround;

    private float _jumpTimeCounter;
    public float jumpTime;
    private bool _isJumping;

    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _feetPos = FindObjectOfType<FeetPosition>().transform;
    }

    public void Jump()
    {
        int layerMaskInt = 1 << LayerMask.NameToLayer("Ground");
        _whatIsGround = layerMaskInt;
        _isGrounded = Physics2D.OverlapCircle(_feetPos.position, checkRadius, _whatIsGround);

        if (_isGrounded == true && Input.GetMouseButtonDown(0))
        {
            _isJumping = true;
            _jumpTimeCounter = jumpTime;
            _rb.velocity = Vector2.up * _jumpForce;
        }

        if (Input.GetMouseButton(0) && _isJumping == true)
        {
            if (_jumpTimeCounter > 0)
            {
                _rb.velocity = Vector2.up * _jumpForce;
                _jumpTimeCounter -= Time.deltaTime;
            }
            else
            {
                _isJumping = false;
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            _isJumping = false;
        }
    }
}
