using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 90f;
    [SerializeField] private float animTurnThreshold = 0.35f;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform bulletSpawnPointTransform;
    [SerializeField] private AudioSource shootSound;
    [SerializeField] private GameObject explosionPrefab;

    private Vector2 move;
    private Rigidbody2D rb;
    private Animator animator;

    private bool lastFire = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    private void Start()
    {
        animator.SetFloat("MoveY", 0);
    }

    private void Update()
    {
        move = GameInput.Instance.GetMoveActionValue();

        if (move.y == 0)
        {
            animator.SetFloat("MoveY", 0);
        }
        else
        {
            if (move.y > animTurnThreshold)
            {
                animator.SetFloat("MoveY", 1);
            }
            else if (move.y < -animTurnThreshold)
            {
                animator.SetFloat("MoveY", -1);
            }
        }

        rb.linearVelocity = move.normalized * moveSpeed;

        if (GameInput.Instance.IsFireActionPressed() && !lastFire)
        {
            shootSound.Play();

            Instantiate(bulletPrefab, bulletSpawnPointTransform.position, Quaternion.identity);
        }

        lastFire = GameInput.Instance.IsFireActionPressed();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Hazard"))
        { 
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
