using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject explosionPrefab;
    
    private void Start()
    {
        
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("PlayerBullet"))
        {
            Instantiate(explosionPrefab, transform.position, Quaternion.identity);

            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
