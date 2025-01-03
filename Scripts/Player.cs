using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public float sped; // ���������, ��� ��� ���� ��������
    public float jumpforce;

    private bool isGrounded;
    private Rigidbody2D rigidbody2d;
    private SpriteRenderer spriteRenderer;
    private Animator animator;

    public int score;
    public Text scoreText;


    private void Start()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }

        // ����������� ������
        Vector3 position = transform.position;
        position.x += Input.GetAxis("Horizontal") * sped * Time.fixedDeltaTime; // �������� �� ��������
        transform.position = position;

       

        if (Input.GetAxis("Horizontal" ) != 0)
        {
            // ������� �������
            if (Input.GetAxis("Horizontal") < 0)
            {
                spriteRenderer.flipX = true; // ����������
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                spriteRenderer.flipX = false; // ����������
            }
            animator.SetInteger("State", 1);

        }
        else
        {
            animator.SetInteger("State", 0);
        }
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

    private void OnCollisionEnter2D(Collision2D collision) // ����������: OnCollisionEnter2D
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }
}
