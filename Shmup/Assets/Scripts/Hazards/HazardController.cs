using System;
using UnityEngine;

public class HazardController : MonoBehaviour
{
    public event EventHandler OnDeath;

    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private Vector2 moveDirection = Vector2.left;
    [SerializeField] private GameObject explosionPrefab;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.linearVelocity = moveDirection * moveSpeed;

        if (transform.position.x < -20 || transform.position.y > 20 || transform.position.y < -20)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            OnDeath?.Invoke(this, EventArgs.Empty);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }

    public void SetMoveDirection(Vector3 value)
    {
        moveDirection = value;
    }
}
