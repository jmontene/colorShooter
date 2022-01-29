using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed;
    public Rigidbody2D rb;

    Vector2 movement;
    private ColorChangeController colorChangeController;
    private Animator animator;

    private void Awake() {
        colorChangeController = GetComponent<ColorChangeController>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Z)) {
            colorChangeController.Change();
        }
        Movement();
    }

    private void FixedUpdate() {
        rb.velocity = movement*movementSpeed;
    }

    void Movement() {
        float movementX = Input.GetAxisRaw("Horizontal");
        float movementY = Input.GetAxisRaw("Vertical");

        if (movementX != 0 || movementY != 0) {
            animator.SetFloat("xDir", movementX);
            animator.SetFloat("yDir", movementY);
        }

        movement = new Vector2(movementX, movementY).normalized;
        animator.SetFloat("Speed", movement.magnitude);
    }
}
