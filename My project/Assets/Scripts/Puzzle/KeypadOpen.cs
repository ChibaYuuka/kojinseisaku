using UnityEngine;
using UnityEngine.InputSystem;

public class KeypadOpen : MonoBehaviour
{
    public PasswordController passwordController;
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main;
    }

    void Update()
    {
        // マウスが存在するか確認
        if (Mouse.current == null) return;

        // 左クリックされた瞬間
        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            Ray ray = mainCamera.ScreenPointToRay(Mouse.current.position.ReadValue());

            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, 100f))
            {
                // クリックしたオブジェクトが自分か確認
                if (hit.collider.gameObject == gameObject)
                {
                    Debug.Log("入力装置をクリックした！");

                    passwordController.OpenPanel();
                }
            }
        }
    }
}
