using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 1f;
    public Vector2 moveDirection = Vector2.zero;
    public float timeToLive = 5f;
    public GameObject owner;
    
    private Rigidbody2D rb;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start() {
        StartCoroutine(StartDeathTimer());
    }

    private IEnumerator StartDeathTimer() {
        yield return new WaitForSeconds(timeToLive);
        Destroy(gameObject);
    }

    private void FixedUpdate() {
        rb.velocity = moveDirection * speed;
    }
}
