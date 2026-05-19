using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 90f;

    private Vector2 move;
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
        Vector2 newPos = transform.position;

        newPos.y += Input.GetAxisRaw("Vertical") * moveSpeed;

        rb.MovePosition(newPos);
    }
}
