using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
public class NhanVat : MonoBehaviour
{
    private Animator _animator;
    private Rigidbody2D rb;

    public float speed = 3f;
    public float jumpForce = 10f;
    public float maxHeight = 2.0f;
    private bool isJumping = false;
    public Text diemText;
    private int tongDiem = 0;
    public GameObject Over;
    public GameObject textDiem;
    public GameObject duong;
    public GameObject Win;
    public Text diemText_Panle;
    
    void Start()
    {
        _animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        diemText.text = "  " + tongDiem;
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");

        // Chạy sang trái hoặc sang phải
        rb.velocity = new Vector2(horizontalInput * speed, rb.velocity.y);

        // Cập nhật trạng thái Animator dựa trên tốc độ di chuyển
        _animator.SetFloat("chay", Mathf.Abs(rb.velocity.x));

        // Kiểm tra nếu nhân vật ở trạng thái nhảy
        if (isJumping)
        {
            // Kiểm tra khi người dùng thả nút Space hoặc đạt độ cao nhất
            if (Input.GetKeyUp(KeyCode.Space) || transform.position.y >= maxHeight)
            {
                isJumping = false;
                _animator.SetFloat("xoay", 0); // Chuyển trở lại trạng thái bình thường
            }
        }
        // Nếu nhân vật không trong trạng thái nhảy và người chơi nhấn Space
        else if (Input.GetKeyDown(KeyCode.Space) && Mathf.Abs(rb.velocity.y) < 0.01)
        {
            // Khi nhấn Space và nhân vật không trong trạng thái nhảy, thì cho nhân vật nhảy
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);

            // Bắt đầu coroutine để chuyển trạng thái Animation "xoay" sau một khoảng thời gian
            StartCoroutine(SwitchToXoayState());
        }
    }

    // Coroutine để chuyển về trạng thái bình thường sau một khoảng thời gian
    private IEnumerator SwitchToXoayState()
    {
        isJumping = true;
        _animator.SetFloat("xoay", 1); // Chuyển đến trạng thái "xoay"
        yield return new WaitForSeconds(0.3f); // Đợi 0.3 giây (hoặc thời gian bạn muốn)
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag=="tien")
        {
            tongDiem += 1;
            diemText.text = "  " + tongDiem;
            diemText_Panle.text = "" + tongDiem;
            Destroy(other.gameObject, 0.5f);
        }

        if (other.gameObject.tag=="Vuc")
        {
            Over.SetActive(true);
            textDiem.SetActive(false);
            duong.SetActive(false);
            Time.timeScale = 0;
        }

        if (other.gameObject.tag=="win_io")
        {
            Win.SetActive(true);
        }
    }
}