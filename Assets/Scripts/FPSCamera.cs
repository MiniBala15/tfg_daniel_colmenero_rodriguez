using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{
    Rigidbody rb;
    Vector2 movementInput;
    Vector2 rotationInput;
    public float walkSpeed = 10f;
    public float sprintSpeed = 15f;
    public float jumpForce = 2;

    public float sensibility = 4;
    Transform camera;
    float rotationX;

    Vector3 normalScale;
    Vector3 crouchedScale;
    bool crouched;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        rb = GetComponent<Rigidbody>();
        camera = transform.GetChild(0);
        rotationX = camera.eulerAngles.x;

        normalScale = transform.localScale;
        crouchedScale = normalScale;
        crouchedScale.y = normalScale.y * .75f;
    }

    // Update is called once per frame
    void Update()
    {
        movementInput.x = Input.GetAxis("Horizontal");
        movementInput.y = Input.GetAxis("Vertical");

        rotationInput.x = Input.GetAxis("Mouse X") * sensibility;
        rotationInput.y = Input.GetAxis("Mouse Y") * sensibility;

        crouched = Input.GetKey(KeyCode.C);

        if(Input.GetButtonDown("Jump") && !crouched)  {
            rb.AddForce(0, jumpForce, 0);
        }
    }

    private void FixedUpdate() {
        float speed = (Input.GetKey(KeyCode.LeftShift) || Input.GetButton("Fire2")) ? sprintSpeed : walkSpeed;
        rb.velocity = 
            transform.forward * speed * movementInput.y     //movimiento hacia adelante y atras;
            + transform.right * speed * movementInput.x     //movimiento hacia los lados;
            + new Vector3 (0, rb.velocity.y, 0);

        transform.rotation *= Quaternion.Euler(0, rotationInput.x, 0);  //rotacion horizontal

        //camara vertical
        rotationX -= rotationInput.y;
        rotationX = Mathf.Clamp(rotationX, -60, 60);
        camera.localRotation = Quaternion.Euler(rotationX, 0, 0);

        //agacharse o levantarse
        transform.localScale = Vector3.Lerp(
            transform.localScale,
            crouched ? crouchedScale : normalScale,
            .1f
        );
    }
}
