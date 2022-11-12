using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon.Pun;
using TMPro;

public class PlayerMouvement : MonoBehaviour
{
    [Header("UI")]
    public TMP_Text text;

    [Header("Mouvement")]
    public float moveSpeed;
    public float groundDrag;

    public float jumpForce;
    public bool jumpReady = true;

    [Header("Ground Check")]
    public float playerHeight;
    public LayerMask ground;
    public bool grounded;

    [Header("Parent")]
    private GameObject player;
    
    float horizontalInput;
    float verticalInput;

    Vector3 moveDirection;

    Rigidbody rb;
    PhotonView view;

    private void Start()
    {
        player = GetComponentInParent<Transform>().gameObject;
        view = GetComponentInParent<PhotonView>();
        rb = GetComponent<Rigidbody>();
        rb.freezeRotation = true;
        if (!view.IsMine) rb.isKinematic = true;
    }

    private void FixedUpdate()
    {
        if (view.IsMine)
        {
            MovePlayer();
            //ground check
            grounded = Physics.Raycast(transform.position, Vector3.down, playerHeight / 2, ground);
        }
            
    }

    void Update()
    {
        if (view.IsMine)
        {
            MyInput();
            speedController();

            //apply drag
            // apply drag
            if (grounded) rb.drag = groundDrag;
            else rb.drag = 0;
        }
        else this.enabled=false;
    }

    private void MyInput()
    {
        if (Input.GetKey("d")) horizontalInput = 1;
        else if (Input.GetKey("q")) horizontalInput = -1;
        else horizontalInput = 0;

        if (Input.GetKey("space") && grounded && jumpReady)
        {
            jump();
            Invoke(nameof(resetJump), 0.15f);
        }
    }

    private void MovePlayer()
    {
        moveDirection = player.transform.right * horizontalInput;
        // rb.AddForce(moveDirection.normalized * moveSpeed * 10, ForceMode.Force);
        transform.position = transform.position + moveDirection * moveSpeed * .1f;
    }

    private void speedController()
    {
        if (Mathf.Abs(rb.velocity.x) > moveSpeed) rb.velocity = new Vector3(rb.velocity.normalized.x * moveSpeed, rb.velocity.y, 0);
        // text.text = "Speed: " + transform.localScale[0].ToString("0.00");
    }

    private void jump()
    {
        rb.velocity = new Vector3(rb.velocity.x, 0f, 0f);

        rb.AddForce(transform.up * jumpForce, ForceMode.Impulse);
        jumpReady = false;
    }

    private void resetJump()
    {
        jumpReady = true;
    }
}
