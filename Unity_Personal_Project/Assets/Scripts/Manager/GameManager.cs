using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public PlayerController player { get; private set; }
    private ResourceController _playerResourceController;

    [SerializeField] private int currentWaveIndex = 0;

    [SerializeField] private GameUI gameUI;

    private EnemyManager enemyManager;
    private EnemyController enemyController;
    private UIManager uiManager;

    public static bool isFirstLoading = true;
    public int score = 0;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject); 
            return;
        }

        instance = this;
        DontDestroyOnLoad(this.gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;

        InitializeSceneReferences();
    }

    private void Start()
    {
        if (!isFirstLoading)
        {
            StartGame();
        }
        else
        {
            isFirstLoading = false;
        }
    }

    public void StartGame()
    {
        uiManager.SetPlayGame();
        StartNextWave();
    }

    void StartNextWave()
    {
        currentWaveIndex += 1;
        enemyManager.StartWave(1 + currentWaveIndex / 5);
        uiManager.ChangeWave(currentWaveIndex);
    }

    public void EndOfWave()
    {
        StartNextWave();
    }

    public void AddScore(int point)
    {
        score += point;
        gameUI.UpdateScore(score);
    }

    public void GameOver()
    {
        enemyManager.StopWave();
        uiManager.SetGameOver();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        InitializeSceneReferences();
    }

    private void InitializeSceneReferences()
    {
        player = FindObjectOfType<PlayerController>();
        player.Init(this);

        uiManager = FindObjectOfType<UIManager>();

        _playerResourceController = player.GetComponent<ResourceController>();
        _playerResourceController.RemoveHealthChangeEvent(uiManager.ChangePlayerHP);
        _playerResourceController.AddHealthChangeEvent(uiManager.ChangePlayerHP);

        enemyManager = GetComponentInChildren<EnemyManager>();
        enemyManager.Init(this);
    }
}
