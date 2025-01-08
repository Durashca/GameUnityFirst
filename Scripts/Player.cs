using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Player : MonoBehaviour
{
    public float speed; // Убедитесь, что это ваша скорость
    public float speedBonus;
    public float jumpforce;

    private float speedStart;

    private bool isGrounded;
    private Rigidbody2D rigidbody2d;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public int score;
    public Text scoreText;

    public float timerSpeed;
    public float timerSpeedMax;

    public float timerScale;
    public float timerScaleMax;



    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        speedStart = speed;
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        // Перемещение игрока
        Vector3 position = transform.position;
        position.x += Input.GetAxis("Horizontal") * speed * Time.fixedDeltaTime; // Умножьте на скорость
        transform.position = position;

       

        if (Input.GetAxis("Horizontal" ) != 0)
        {
            // Поворот спрайта
            if (Input.GetAxis("Horizontal") < 0)
            {
                spriteRenderer.flipX = true; // Поправлено
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                spriteRenderer.flipX = false; // Поправлено
            }
            animator.SetInteger("State", 1);

        }
        else
        {
            animator.SetInteger("State", 0);
        }

       
        BonusCheck();
    }

    private void BonusCheck()
    {
        if (timerSpeed > 0)
        {
            speed = speedBonus;
            timerSpeed--;
        }
        else
        {
            speed = speedStart;
        }


        if (timerScale > 0)
        {
            transform.localScale = new Vector3(1.5f, 1.5f, 1);
            timerScale--;
        }
        else
        {
            transform.localScale = new Vector3(1, 1, 1);
            speed = speedStart;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) 
        {
            SceneManager.LoadScene(0);
            Debug.Log("esc");
        }
    }

    public void BonusScale()
    {
        timerScale = timerScaleMax;
    }

    public void SpeedBonus()
    {
        timerSpeed = timerSpeedMax;
    }

    public void AddCoid(int count)
    {
        score += count;
        scoreText.text = score.ToString();
    }
    private void Jump()
    {
        isGrounded = false;
        rigidbody2d.AddForce(transform.up * jumpforce, ForceMode2D.Impulse);
    }

    private void OnCollisionEnter2D(Collision2D collision) // Исправлено: OnCollisionEnter2D
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
