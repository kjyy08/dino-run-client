using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    [SerializeField] private float jumpForce;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private float groundCheckDistance = 0.1f; // 바닥 체크 거리

    private Rigidbody2D body;
    private Animator anim;
    private bool isJump = false;
    private bool isGrounded = false;

    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update()
    {
        switch (GameManager.Instance.State)
        {
            case GameManager.GAME_STATE.PLAYING:
                isGrounded = Physics2D.Raycast(transform.position, Vector2.down, groundCheckDistance, groundLayer);

                if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
                {
                    AudioManager.Instance.PlayOneShotAudioClip("jump");
                    isJump = true;
                }
                //else if (Input.GetKeyDown(KeyCode.Escape))
                //{
                //    GameManager.Instance.PauseGame();
                //}

                anim.SetBool("isJump", !isGrounded);
                break;

            case GameManager.GAME_STATE.GAMEOVER:
                anim.SetTrigger("doDie");
                this.enabled = false;
                break;
        }
    }

    private void FixedUpdate()
    {
        if (isJump)
        {
            Jump();
        }
    }

    void Jump()
    {
        body.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        isJump = false;
    }
}
