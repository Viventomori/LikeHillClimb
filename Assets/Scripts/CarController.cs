using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    [SerializeField] private Rigidbody2D leftTireRB;
    [SerializeField] private Rigidbody2D rightTireRB;
    [SerializeField] private Rigidbody2D carRB;
    [SerializeField] private float speed;
    [SerializeField] private float rotationSpeed;

    private float moveInput;

    void Update()
    {
        moveInput = Input.GetAxisRaw("Horizontal");
        
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            float touchXPosition = touch.position.x;
            float screenWidth = Screen.width;

            // Перетворюємо позицію дотику на вхід для керування
            if (touchXPosition < screenWidth / 2)
            {
                moveInput = -1f;
            }
            else if (touchXPosition > screenWidth / 2)
            {
                moveInput = 1f;
            }
        }
    }

    private void FixedUpdate()
    {
        leftTireRB.AddTorque(-moveInput * speed * Time.fixedDeltaTime);
        rightTireRB.AddTorque(-moveInput * speed * Time.fixedDeltaTime);
        carRB.AddTorque(moveInput * rotationSpeed * Time.fixedDeltaTime);
    }
}





