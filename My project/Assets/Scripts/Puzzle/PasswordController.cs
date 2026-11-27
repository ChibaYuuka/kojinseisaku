using UnityEngine;
using TMPro;

public class PasswordController : MonoBehaviour
{
    public GameObject passwordPanel;
    public TMP_Text passwordText;
    public TMP_Text messageText;

    public string correctPassword = "253264";
    public CameraFollow cameraFollow;
    private string inputPassword = "";

    void Start()
    {
        passwordPanel.SetActive(false);
    }

    public void OpenPanel()
    {
        passwordPanel.SetActive(true);

        inputPassword = "";
        passwordText.text = "______";
        messageText.text = "";

        // カーソル表示
        cameraFollow.SetCursorState(true);
    }

    public void AddNumber(string number)
    {
        if (inputPassword.Length >= 6) return;

        inputPassword += number;
        passwordText.text = inputPassword;
    }

    public void ClearPassword()
    {
        inputPassword = "";
        passwordText.text = "______";
        messageText.text = "";
    }

    public void CheckPassword()
    {
        if (inputPassword == correctPassword)
        {
            messageText.text = "解除成功！";
            Debug.Log("扉が開いた！");
            ClosePanel();
        }
        else
        {
            messageText.text = "番号が違います";
            ClearPassword();
        }
    }

    public void ClosePanel()
    {
        passwordPanel.SetActive(false);
        // カーソルを隠して視点操作に戻る
        cameraFollow.SetCursorState(false);
    }
}