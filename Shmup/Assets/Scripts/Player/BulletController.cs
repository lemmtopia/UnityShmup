using UnityEngine;

public class BulletController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 200f;
    [SerializeField] private Vector2 move;
    [SerializeField] private float destroyBorder = 15f;

    private Rigidbody2D rb;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        rb.linearVelocity = move * moveSpeed;

        if (transform.position.x > destroyBorder || transform.position.x < -destroyBorder || transform.position.y > destroyBorder || transform.position.y < -destroyBorder)
        {
            Destroy(gameObject);
        }
    }
}
