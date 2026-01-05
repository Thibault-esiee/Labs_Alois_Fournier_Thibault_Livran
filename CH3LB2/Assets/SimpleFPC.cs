using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class SimpleFPC : MonoBehaviour
{
    public float movementSpeed = 5.0f;
    public float jumpForce = 8.0f;
    public float gravity = 20.0f;

    public float lookSensitivityX = 2.0f;
    public float lookSensitivityY = 2.0f;
    public float lookVerticalLimit = 85.0f;

    private CharacterController characterController;
    private Vector3 moveDirection = Vector3.zero;
    private float rotationX = 0;

    void Start()
    {
        characterController = GetComponent<CharacterController>();

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        if (Camera.main && Camera.main.transform.parent != transform)
        {
            Transform cameraTransform = transform.Find("Main Camera");
            if (cameraTransform)
            {
                rotationX = cameraTransform.localRotation.eulerAngles.x;
            }
        }
    }

    void Update()
    {
        transform.Rotate(Vector3.up * Input.GetAxis("Mouse X") * lookSensitivityX);

        rotationX += -Input.GetAxis("Mouse Y") * lookSensitivityY;

        rotationX = Mathf.Clamp(rotationX, -lookVerticalLimit, lookVerticalLimit);

        if (Camera.main)
        {
            Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
        }

        if (characterController.isGrounded)
        {
            Vector3 forward = transform.forward;
            Vector3 right = transform.right;

            float curSpeedX = movementSpeed * Input.GetAxis("Vertical");
            float curSpeedY = movementSpeed * Input.GetAxis("Horizontal");

            moveDirection = (forward * curSpeedX) + (right * curSpeedY);

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }

        moveDirection.y -= gravity * Time.deltaTime;

        characterController.Move(moveDirection * Time.deltaTime);
    }
}