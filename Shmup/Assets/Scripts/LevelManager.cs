using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    [SerializeField] private int numHazards;
    [SerializeField] private float nextLevelTimer = 2f;

    bool restartCurrentLevel = false;
    bool startNextLevel = false;
    float nextLevelTimerCurrent = 0;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        if (startNextLevel)
        {
            nextLevelTimerCurrent += Time.deltaTime;
            if (nextLevelTimerCurrent >= nextLevelTimer && SceneManager.GetActiveScene().buildIndex != SceneManager.sceneCountInBuildSettings - 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
                startNextLevel = false;
                nextLevelTimerCurrent = 0;
            }
        }
        else if (restartCurrentLevel)
        {
            nextLevelTimerCurrent += Time.deltaTime;
            if (nextLevelTimerCurrent >= nextLevelTimer && SceneManager.GetActiveScene().buildIndex != SceneManager.sceneCountInBuildSettings - 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                restartCurrentLevel = false;
                nextLevelTimerCurrent = 0;
            }
        }
        else
        {
            if (numHazards <= 0)
            {
                nextLevelTimerCurrent = 0;
                startNextLevel = true;
            }
        }
    }

    public void AddHazard()
    {
        numHazards++;
    }

    public void RemoveHazard()
    {
        numHazards--;
    }

    public void RestartCurrentLevel()
    {
        restartCurrentLevel = true;
    }
}
