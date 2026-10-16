using UnityEngine;
using UnityEngine.InputSystem;

public class CameraController : MonoBehaviour
{
    float rotationSpeed;
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
        if (Input.GetMouseButton(0))
        {
            mouseX = Input.GetAxis("Mouse X") * rotationSpeed;
            mouseY = Input.GetAxis("Mouse Y") * rotationSpeed;
            transform.RotateAround(player.transform.position, Vector3.up, mouseX); // Y²‚É‘Î‚µ‚Ä‰ñ“]‚³‚¹‚éˆ—
            transform.RotateAround(player.transform.position, transform.right, mouseY); // X²‚É‘Î‚µ‚Ä‰ñ“]‚³‚¹‚éˆ—
        }
    }
}
