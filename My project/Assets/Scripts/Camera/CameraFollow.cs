using UnityEngine;
using UnityEngine.InputSystem;

public class CameraFollow : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private float mouseSensitivity = 2f;
    [SerializeField] private float minAngle = -30f;
    [SerializeField] private float maxAngle = 60f;

    private Vector3 offset;
    private float rotationX;
    private float rotationY;

    void Start()
    {
        offset = transform.position - target.position;

        Vector3 angles = transform.eulerAngles;
        rotationX = angles.x;
        rotationY = angles.y;

        SetCursorState(false);
    }

    // カーソルの表示・非表示を切り替える
    public void SetCursorState(bool showCursor)
    {
        if (showCursor)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            //Cursor.lockState = CursorLockMode.Locked;
            //Cursor.visible = false;
        }
    }

    void Update()
    {
        //マウス入力
        float mouseX = Mouse.current.delta.x.ReadValue();
        float mouseY = Mouse.current.delta.y.ReadValue();

        rotationY += mouseX * mouseSensitivity * Time.deltaTime;
        rotationX -= mouseY * mouseSensitivity * Time.deltaTime;
        rotationX = Mathf.Clamp(rotationX, minAngle, maxAngle);

        //カメラの回転
        transform.rotation = Quaternion.Euler(rotationX, rotationY, 0);

        //カメラの位置
        transform.position = target.position + transform.rotation * offset;
    }
}
