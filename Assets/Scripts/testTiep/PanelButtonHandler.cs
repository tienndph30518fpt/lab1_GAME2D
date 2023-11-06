// PanelButtonHandler.cs
using UnityEngine;
using UnityEngine.UI;

public class PanelButtonHandler : MonoBehaviour
{
    private Text panelText;
    private Button restartButton;
    private GameObject panel;

    // Thêm constructor để nhận các tham chiếu từ bên ngoài
    public PanelButtonHandler(Text panelText, Button restartButton, GameObject panel)
    {
        this.panelText = panelText;
        this.restartButton = restartButton;
        this.panel = panel;

        // Gắn sự kiện click cho nút restartButton
        restartButton.onClick.AddListener(OnPanelButtonClick);
    }

    public void OnPanelButtonClick()
    {
        Debug.Log("Nút trên Panel được nhấn!");
        // Thêm xử lý cho nút trên Panel ở đây (nếu cần)
        // Ví dụ: Đặt lại trò chơi khi nút được nhấn
        // GameManager.Instance.RestartGame();
    }

    public void ShowPanel(string message)
    {
        panelText.text = message;
        panel.SetActive(true);
        restartButton.gameObject.SetActive(true);
        Time.timeScale = 0f;
    }

    public void HidePanel()
    {
        panel.SetActive(false);
        restartButton.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
