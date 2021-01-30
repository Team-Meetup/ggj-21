﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PopsicleController : MonoBehaviour
{
    private Vector2 _input;
    private Rigidbody2D _rb;
    private Vector2 _velocity;
    public bool isJumping;

    public int iceCount;

    [FormerlySerializedAs("_speed")] [SerializeField]
    private float speed = 5;
    [FormerlySerializedAs("_jumpForce")] [SerializeField]
    private float jumpForce = 400;

    [SerializeField]
    private BoxCollider2D bottomCollider;
    private Vector3 _bottomColliderMax, _bottomColliderMin;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _velocity = Vector2.zero;
        isJumping = false;
        iceCount = 0;

        var bottomColliderBounds = bottomCollider.bounds;
        _bottomColliderMax = bottomColliderBounds.max;
        _bottomColliderMin = bottomColliderBounds.min;
    }

    // Update is called once per frame
    void Update()
    {
        _input.x = Input.GetAxisRaw("Horizontal");
        _input.y = Input.GetAxisRaw("Vertical");

        Vector2 targetVelocity = new Vector2(_input.x * speed, _rb.velocity.y);
        _rb.velocity = Vector2.SmoothDamp(_rb.velocity, targetVelocity, ref _velocity, .3f);

        Vector2 jumpVector = new Vector2(_input.x, _input.y * jumpForce);

        if (isJumping)
        {
            jumpVector.y = 0;
        }
        else if(_input.y > 0f)
        {
            jumpVector.y = _input.y * jumpForce;
            isJumping = true;
            Debug.Log("false");
        }
        else
        {
            jumpVector.y = 0;
            Debug.Log("else");
        }

        _rb.AddForce(jumpVector);
    }

    public void OnTriggerEnter2DChild(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("im grounded");
            isJumping = false;
        }
    }
    
    public void OnTriggerExit2DChild(Collider2D other)
    {
    }
    
    public void OnTriggerStay2DChild(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ground")){
            Debug.Log("stay");
            //isJumping = false;
        }
        
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("VCamConfiner"))
        {
            Debug.Log("u lost");
        }
    }
}