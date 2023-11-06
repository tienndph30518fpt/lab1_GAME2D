// tuontac.cs
using UnityEngine;
using UnityEngine.UI;

public class tuontac : MonoBehaviour
{
    public float speed = 3f;
    public float jumpForce = 10f;
    public Text scoreText;
    public GameObject panel;
    public Text panelText;
    public Button restartButton;
    public float cameraFollowSpeed = 5f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private Animator animator;
    private int score = 0;
    private PanelButtonHandler panelButtonHandler;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        UpdateScoreText();
        panel.SetActive(false);

        panelButtonHandler = new PanelButtonHandler(panelText, restartButton, panel);
        restartButton.onClick.AddListener(OnRestartButtonClick);
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        isGrounded = Physics2D.Raycast(transform.position, Vector2.down, 0.1f);

        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            animator.SetBool("IsJumping", true);
        }
        else
        {
            animator.SetBool("IsJumping", false);
        }

        Camera.main.transform.Translate(Vector3.right * horizontalInput * speed * Time.deltaTime);
        animator.SetFloat("Speed", Mathf.Abs(horizontalInput));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("tien"))
        {
            Destroy(other.gameObject);
            score++;
            UpdateScoreText();
        }
        else if (other.CompareTag("Vuc"))
        {
            panelButtonHandler.ShowPanel("Bạn đã rơi xuống hố!");
        }
    }

    void UpdateScoreText()
    {
        scoreText.text = score.ToString();
    }

    void OnRestartButtonClick()
    {
        Debug.Log("Nút Restart được nhấn!");
        HidePanel();
        RestartGame();
    }

    void HidePanel()
    {
        panelButtonHandler.HidePanel();
    }

    void RestartGame()
    {
        score = 0;
        UpdateScoreText();
        transform.position = Vector3.zero;
    }
}
