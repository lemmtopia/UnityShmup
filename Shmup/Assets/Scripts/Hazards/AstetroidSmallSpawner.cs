using System;
using Unity.Mathematics;
using UnityEngine;

public class AstetroidSmallSpawner : MonoBehaviour
{
    [SerializeField] private int amountToSpawn;
    [SerializeField] private GameObject asterionSmallPrefab;

    private HazardController hazardController;

    private void Awake()
    {
        hazardController = GetComponent<HazardController>();
        hazardController.OnDeath += HazardController_OnDeath;
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void HazardController_OnDeath(object sender, EventArgs e)
    {
        for (int i = 0; i < amountToSpawn; i++)
        {
            float angle = UnityEngine.Random.Range(Mathf.PI / 2, 3 * Mathf.PI / 2);
            Vector3 direction = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);

            GameObject asteriodSmall = Instantiate(asterionSmallPrefab, transform.position, Quaternion.identity);
            asteriodSmall.GetComponent<HazardController>().SetMoveDirection(direction);
        }
    }
}
