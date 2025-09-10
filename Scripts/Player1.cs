using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Player1 : MonoBehaviour
{
    public float speed = 5;
    private Rigidbody2D rb2D;

    private float move;
    public float jumpForce = 4;
    private bool isGrounded;
    public Transform groundCheck;
    public float groundRadious = 0.1f;
    public LayerMask groundLayer;

    private int coins;
    public TMP_Text textCoins;

    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();

    }
    void Update()
    {
        move = Input.GetAxisRaw("Horizontal");
        rb2D.linearVelocity = new Vector2(move * speed, rb2D.linearVelocity.y);

        if (move != 0)
            transform.localScale = new Vector3(Mathf.Sign(move), 1, 1);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb2D.linearVelocity = new Vector2(rb2D.linearVelocity.x, jumpForce);
        }
    }
    private void FixedUpdate()
    {
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, groundRadious, groundLayer);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.CompareTag("Coin"))
        {
            Destroy(collision.gameObject);
            coins++;
            textCoins.text = coins.ToString();
        }



        if (collision.transform.CompareTag("water"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

    }
}

