using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerMoving _playerMoving;
    private PlayerJumping _playerJumping;

    private void Start()
    {
        _playerMoving = GetComponent<PlayerMoving>();
        _playerJumping = GetComponent<PlayerJumping>();
    }

    private void FixedUpdate()
    {
        _playerMoving.Move();
    }

    private void Update()
    {
        //_playerJumping.Jump();
    }
}
