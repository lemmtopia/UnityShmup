using System;
using UnityEngine;

public class HazardController : MonoBehaviour
{
    public event EventHandler OnDeath;

    [SerializeField] private float moveSpeed = 4f;
    [SerializeField] private Vector2 moveDirection = Vector2.left;
    [SerializeField] private GameObject explosionPrefab;
    [SerializeField] private float destroyBorder = 15f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        rb.linearVelocity = moveDirection * moveSpeed;

        if (transform.position.x < -destroyBorder || transform.position.y > destroyBorder || transform.position.y < -destroyBorder)
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
