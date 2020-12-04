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


    #region TestRay
    public float MovingForce;
    Vector2 StartPoint;
    Vector2 Origin;
    public int NoOfRays = 10;
    int i;
    RaycastHit2D HitInfo;
    float LengthOfRay, DistanceBetweenRays;
    float margin = 0.035f;
    Ray ray;
    BoxCollider2D coll;
    #endregion


    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _feetPos = FindObjectOfType<FeetPosition>().transform;

        coll = GetComponent<BoxCollider2D>();
        LengthOfRay = .65f;
    }

    private void Update()
    {
        StartPoint = new Vector2(coll.bounds.min.x + margin, transform.position.y);
        Jump();
    }

    bool IsCollidingVertically()
    {
        int layerMaskInt = 1 << LayerMask.NameToLayer("Ground");
        _whatIsGround = layerMaskInt;
        Origin = StartPoint;
        DistanceBetweenRays = (coll.bounds.size.x - 2 * margin) / (NoOfRays - 1);
        for (i = 0; i < NoOfRays; i++)
        {
            //Draw ray on screen to see visually. Remember visual length is not actual length.
            Debug.DrawRay(Origin, new Vector2(0, -LengthOfRay), Color.yellow);
            HitInfo = Physics2D.Raycast(Origin, Vector2.down, LengthOfRay, _whatIsGround);
            if (HitInfo.collider != null)
            {
                //print("Collided With " + HitInfo.collider.gameObject.name);
                print("Grounded!");
                return true;
            }
            Origin += new Vector2(DistanceBetweenRays, 0);
        }
        print("Note grounded!");
        return false;
    }

    public void Jump()
    {
        //int layerMaskInt = 1 << LayerMask.NameToLayer("Ground");
        //_whatIsGround = layerMaskInt;
        //_isGrounded = Physics2D.OverlapCircle(_feetPos.position, checkRadius, _whatIsGround);
        _isGrounded = IsCollidingVertically();

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
