using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections.Generic;
using System.Collections;
using TMPro;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public static PlayerController Singleton { get; private set; }

    public BlockBuilder blockBuilder;
    private CharacterController characterController;
    private Vector2 direction;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    public Timer timer;
    public Effects ps;
    
    [SerializeField] private float speed;
    [SerializeField] private float jumpSpeed;
    [SerializeField] private float gravity;

    private float moveX;
    private float moveY;
    private float horizontalMove;
    private float verticalMove;

    private bool isSFXJumpPlay = false;

    private void Awake()
    {
        Singleton = this;
    }

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        AudioManager.instance.PlayMusic("level_1Music");
    }

    void Update()
    {
        direction = Vector3.zero;

        moveX = Input.GetAxisRaw("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");

        Move();

        animator.SetFloat("moveX", Mathf.Abs(moveX));
    }

    private void FixedUpdate()
    {
        characterController.Move(direction);
    }

    /// <summary>
    /// Передвижение персонажа
    /// </summary>
    private void Move()
    {
        horizontalMove = moveX * speed * Time.deltaTime;
        verticalMove = Gravity(verticalMove);
        direction = new Vector2(horizontalMove, verticalMove);
        if (moveX < 0)
        {
            spriteRenderer.flipX = true;
            ps.effects[0].transform.localPosition = new Vector2(0.25f, -1.18f);
        }
        if (moveX > 0)
        {
            spriteRenderer.flipX = false;
            ps.effects[0].transform.localPosition = new Vector2(-0.25f, -1.18f);
        }
        if (moveX != 0 && characterController.isGrounded)
        {
            ps.MoveDust();
        }
    }

    /// <summary>
    /// Гравитация и прыжок
    /// </summary>
    /// <param name="yDirection"> движение по оси Y </param>
    /// <returns> движение по оси Y </returns>
    private float Gravity(float yDirection)
    {
        yDirection -= (gravity * 0.1f) * Time.deltaTime;
        if (characterController.isGrounded)
        {
            yDirection = -0.01f;
            if (moveY > 0)
            {
                isSFXJumpPlay = true;
                yDirection = jumpSpeed * 0.01f;
                animator.SetTrigger("Jump");
                if(isSFXJumpPlay)
                {
                    AudioManager.instance.PlaySFX("jump");
                    isSFXJumpPlay = false;
                }
            }
        }
        animator.SetBool("isGrounded", characterController.isGrounded);

        return yDirection;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Platform"))
            gravity = 50;// изменяем значение, чтобы игрок не зависал, если при прыжкке 
                         // он упрется головой о низ платформы

        if (other.CompareTag("Enemy"))
        {
            StartCoroutine(DeathCorutine());
        }

        if (other.CompareTag("Star"))
        {
            blockBuilder.isGetStar = true;
            AudioManager.instance.PlaySFX("getStar");
            ps.GetStar();
            Destroy(other.gameObject);
        }

        if(other.CompareTag("Win"))
        {
            StartCoroutine(WinCorutine());
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Platform"))
            gravity = 8;// возвращаем изначальное значение гравитации
    }

    private IEnumerator WinCorutine()
    {
        animator.SetTrigger("Win");
        yield return new WaitForSeconds(5f);
        SceneManager.LoadScene(0);
    }

    private IEnumerator DeathCorutine()
    {
        animator.SetTrigger("Death");
        moveX = 0;
        moveY = 0;
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }
}
