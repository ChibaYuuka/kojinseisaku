using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float walkSpeed = 5f;
    [SerializeField] private float turnSpeed = 10f; 
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private Transform cameraTransfrom; 

    private InputAction moveAction;
    private Vector2 inputDirection;
    private Vector3 movement;
    private Quaternion rotation;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
    }

    private void FixedUpdate()
    {
        Vector3 cameraForward = cameraTransfrom.forward;
        Vector3 cameraRight = cameraTransfrom.right;

        cameraForward.y = 0;
        cameraRight.y = 0;
        cameraForward.Normalize();
        cameraRight.Normalize();

        movement = cameraForward * inputDirection.y + cameraRight * inputDirection.x;
        movement.Normalize();
        
        // 入力がない場合は完全に停止
        if (inputDirection == Vector2.zero)
        {
            movement = Vector3.zero;
            return;
        }

        if (movement.sqrMagnitude > 0.001f)
        { 
            //  移動方向に合わせてキャラクターの向きを算出
            var desiredForward = Vector3.RotateTowards(transform.forward, movement, turnSpeed * Time.deltaTime, 0f);
            rotation = Quaternion.LookRotation(desiredForward);
        }
        
        //  キャラクターの回転・移動
        rigidBody.MovePosition (rigidBody.position + movement * walkSpeed * Time.deltaTime);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        inputDirection = context.ReadValue<Vector2>();

        // 微小な入力を無視する
        if (inputDirection.magnitude < 0.15f)
        {
            inputDirection = Vector2.zero;
        }
        ////  入力がなくなったら、移動しない
        //if (context.canceled)
        //{
        //    inputDirection = Vector2.zero;
        //    return;
        //}
        
        //inputDirection = context.ReadValue<Vector2>();
    }
}
