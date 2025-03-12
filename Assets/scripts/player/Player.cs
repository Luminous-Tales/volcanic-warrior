using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int jumpForce = 750;
    public int attack = 1;
    public int health = 7;
    private Animator anim;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private bool isGrounded;
    private bool isActing;

    public GameOverManager gameOverManager;
    public Slider lifeBar;
    public int point;
    void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        lifeBar.value = health;
    }

    public void OnJump(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded && !isActing)
        {
            Jump();
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded && !isActing)
        {
            StartCoroutine(Attack());
        }
    }

    public void OnDodge(InputAction.CallbackContext context)
    {
        if (context.performed && isGrounded && !isActing)
        {
            StartCoroutine(Dodge());
        }
    }

    public void Jump()
    {
        isGrounded = false;
        anim.SetBool("jumping", true);
        rb.AddForce(Vector2.up * jumpForce);
    }

    public IEnumerator Attack()
    {
        isActing = true;
        anim.SetTrigger("attack");
        yield return new WaitForSeconds(0.5f);
        isActing = false;
    }

    public IEnumerator Dodge()
    {
        isActing = true;
        anim.SetTrigger("dodge");
        yield return new WaitForSeconds(0.5f);
        isActing = false;
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("ground"))
        {
            isGrounded = true;
            anim.SetBool("jumping", false);
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("enemy"))
        {
            StartCoroutine(TakeDamage());
        }
    }

    IEnumerator TakeDamage()
    {
        if (gameObject.tag == "Player")
        {
            gameObject.tag = "playerDamaged";
            anim.SetBool("hurt", true);
            health -= 1;
            lifeBar.value = health;
            rb.gravityScale = 5;
            yield return SwitchColor();
            rb.gravityScale = 3;

            if (health <= 0)
            {
                gameOverManager.ShowGameOver();
            }

            gameObject.tag = "Player";
        }
    }

    IEnumerator SwitchColor()
    {
        for (int i = 0; i < 4; i++)
        {
            sr.color = Color.red;
            yield return new WaitForSeconds(0.2f);
            sr.color = Color.white;
            yield return new WaitForSeconds(0.2f);
        }
    }
}
