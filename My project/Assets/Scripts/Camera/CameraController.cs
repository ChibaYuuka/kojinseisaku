using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    float rotationSpeed = 0.18f;
    float mouseX;
    float mouseY;

    public GameObject player;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Mouse.current.leftButton.isPressed)
        {
            mouseX = Mouse.current.delta.ReadValue().x * rotationSpeed;
            mouseY = Mouse.current.delta.ReadValue().y * rotationSpeed;
            //transform.Rotate(mouseY, mouseX, 0);  // ƒJƒƒ‰‚ğ‰ñ“]‚³‚¹‚éˆ—
            transform.RotateAround(player.transform.position, Vector3.up, mouseX); // Y²‚É‘Î‚µ‚Ä‰ñ“]‚³‚¹‚éˆ—
            transform.RotateAround(player.transform.position, transform.right, -mouseY); // X²‚É‘Î‚µ‚Ä‰ñ“]‚³‚¹‚éˆ—
        }
        return;
    }
}
