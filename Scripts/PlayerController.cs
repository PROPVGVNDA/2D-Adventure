using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] HUD gameHud;
    [SerializeField] PlayerAudio playerAudio;
    [SerializeField] Trap trapController;
    [SerializeField] LayerMask foregroundLayer;
    private bool isGrounded = true;
    private float horizontalInput;
    private Animator playerAnimator;
    private Rigidbody2D playerRb;
    private Collider2D playerCollider;
    private float playerSpeed = 5;
    private float jumpPower = 10;
    public event Action gameLost;
    public int hitPoints = 3;


    private void Awake()
    {
        playerRb = GetComponent<Rigidbody2D>();
        playerCollider = GetComponent<Collider2D>();
        playerAnimator = GetComponent<Animator>();
        trapController.OnPlayerEnter += PlayerHit;
    }

    private void FixedUpdate()
    {
        Movement();
    }

    private void Update()
    {
        horizontalInput = Input.GetAxisRaw("Horizontal");
        PlayerMove(horizontalInput);
        IsGrounded();
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded) Jump();
    }

    private void Movement()
    {
        transform.Translate(Vector3.right * Time.deltaTime * horizontalInput * playerSpeed, Space.World);
        ChangeDirection(horizontalInput);
    }

    private void Jump()
    {
        playerRb.velocity = Vector2.up * jumpPower;
        playerAudio.PlayJumpSound();
    }

    private void IsGrounded()
    {
        RaycastHit2D raycastHit = Physics2D.BoxCast(playerCollider.bounds.center, playerCollider.bounds.size, 0f, Vector2.down, 0.1f, foregroundLayer);
        if (raycastHit.collider != null)
        {
            isGrounded = true;
            playerAnimator.SetBool("IsGrounded", isGrounded);
        } 
        else
        {
            isGrounded = false;
            playerAnimator.SetBool("IsGrounded", isGrounded);
        }
    }

    private void ChangeDirection(float horizontalInput)
    {
        if (horizontalInput < 0 && transform.localScale.x != -1.8) transform.localScale = new Vector3(-1.8f, 2, 2);
        else if (horizontalInput > 0 && transform.localScale.x != 1.8) transform.localScale = new Vector3(1.8f, 2, 2);
    }

    private void PlayerMove(float horizontalInput)
    {
        if (horizontalInput != 0) playerAnimator.SetBool("IsMoving", true);
        else playerAnimator.SetBool("IsMoving", false);
    }

    private void PlayerHit()
    {
        playerAnimator.SetTrigger("PlayerHit");
        hitPoints--;
        gameHud.UpdateOnPlayerHit();
        if (hitPoints == 0) Invoke(nameof(GameLost), 0.25f);
    }

    private void GameLost()
    {
        gameLost.Invoke();
        gameObject.SetActive(false);
    }
}
