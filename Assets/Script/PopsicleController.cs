using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class PopsicleController : MonoBehaviour
{
    private Vector2 _input;
    private Rigidbody2D _rb;
    private Vector2 _velocity;
    public bool isJumping;

    public int iceCount;

    [FormerlySerializedAs("_speed")] [SerializeField]
    private float speed;
    [FormerlySerializedAs("_jumpForce")] [SerializeField]
    private float jumpForce;

    [SerializeField] private float smoothTime;

    [SerializeField]
    private BoxCollider2D bottomCollider;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _velocity = Vector2.zero;
        isJumping = false;
        iceCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        _input.x = Input.GetAxisRaw("Horizontal");
        _input.y = Input.GetAxisRaw("Vertical");

        Vector2 targetVelocity = new Vector2(_input.x * speed, _rb.velocity.y);
        _rb.velocity = Vector2.SmoothDamp(_rb.velocity, targetVelocity, ref _velocity, smoothTime);

        Vector2 jumpVector = new Vector2(_input.x, _input.y * jumpForce);

        if (_input.x != 0)
        {
            GameObject.FindGameObjectWithTag("SFXAudioSource").GetComponent<SFXController>().Walk();
        }
        if (isJumping)
        {
            jumpVector.y = 0;
        }
        else if(_input.y > 0f)
        {
            jumpVector.y = _input.y * jumpForce;
            isJumping = true;
            Debug.Log("false");
            PlayJumpSFX();
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ice"))
        {
            Destroy(other.gameObject);
            iceCount++;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("VCamConfiner"))
        {
            Debug.Log("u lost");
            Invoke("GameOver", 0.5f);
            GameObject.FindGameObjectWithTag("SFXAudioSource").GetComponent<SFXController>().Lose();
            GameObject.FindGameObjectWithTag("AudioStateManager").GetComponent<GameAudioStateManagerController>()
                .audioState = GameAudioStateManagerController.AudioState.Lose;
        }

        if (other.gameObject.CompareTag("Finish"))
        {
            Invoke("GameOver", 0.5f);
            GameObject.FindGameObjectWithTag("SFXAudioSource").GetComponent<SFXController>().Win();
            GameObject.FindGameObjectWithTag("AudioStateManager").GetComponent<GameAudioStateManagerController>()
                .audioState = GameAudioStateManagerController.AudioState.Win;
        }
    }

    public void GameOver()
    {
        IceCream.instance.anaSahne.SetActive(false);
        IceCream.instance.gameOver.SetActive(true);
        // insert win
    }

    private void PlayJumpSFX()
    {
        GameObject.FindGameObjectWithTag("SFXAudioSource").GetComponent<SFXController>().Jump();
    }

}
