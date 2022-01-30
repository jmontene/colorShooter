using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float movementSpeed;
    public float bulletSpeed = 1f;
    public float bulletWaitTime = 0.5f;
    public Rigidbody2D rb;
    public Bullet bulletPrefab;

    Vector2 movement;
    private ColorChangeController colorChangeController;
    private Animator animator;
    private bool isBulletOnCooldown = false;

    private void Awake() {
        colorChangeController = GetComponent<ColorChangeController>();
        animator = GetComponent<Animator>();
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Q)) {
            colorChangeController.Change();
        }
        if (!colorChangeController.IsChanging()) {
            CheckBulletInput();
        }
        Movement();
    }

    private void FixedUpdate() {
        rb.velocity = movement*movementSpeed;
    }

    private void CheckBulletInput() {
        if (Input.GetKey(KeyCode.D)) {
            InstantiateBullet(Vector2.right, bulletSpeed);
        } else if (Input.GetKey(KeyCode.A)) {
            InstantiateBullet(Vector2.left, bulletSpeed);
        } else if (Input.GetKey(KeyCode.W)) {
            InstantiateBullet(Vector2.up, bulletSpeed);
        } else if (Input.GetKey(KeyCode.S)) {
            InstantiateBullet(Vector2.down, bulletSpeed);
        }
    }

    private void InstantiateBullet(Vector2 dir, float speed) {
        if (isBulletOnCooldown) return;
        Bullet bullet = Instantiate<Bullet>(bulletPrefab, transform.position, Quaternion.identity);
        bullet.moveDirection = dir;
        bullet.speed = speed;
        StartCoroutine(bulletCooldown());
    }

    private IEnumerator bulletCooldown() {
        isBulletOnCooldown = true;
        yield return new WaitForSeconds(bulletWaitTime);
        isBulletOnCooldown = false;
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
