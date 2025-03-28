using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnController : MonoBehaviour
{
    public Transform[] StarSpawnPoint;
    public GameObject StarPrefab;
    public int StarCounter;
    private int maxStars = 3;
    public Transform[] SpawnPoints;
    public GameObject EnemyPrefab;  
    private Coroutine spawnCoroutine;
    public GameObject GameOverScreen;
    public GameObject WinScreen;
    public Button RestartButton;
    void Start()
    {
        GameOverScreen.SetActive(false);
        WinScreen.SetActive(false);
        InvokeRepeating("Spawn", 2, 2);
        InvokeRepeating("SpawnStar", 7, 7);
    }
    
    void Spawn()
    {
        int spawnIdx = Random.Range(0, SpawnPoints.Length);
        Instantiate(EnemyPrefab, SpawnPoints[spawnIdx].position, Quaternion.identity);
    }

    void SpawnStar()
    {
        if (StarCounter >= maxStars)
        {
            CancelInvoke("SpawnStar");
            return;
        }
        int StarSpawnIdx = Random.Range(0, StarSpawnPoint.Length);
        Instantiate(StarPrefab, StarSpawnPoint[StarSpawnIdx].position, Quaternion.identity);
    }
    
    public void GameOver()
    {
        CancelInvoke(nameof(Spawn));
        CancelInvoke(nameof(SpawnStar));
        GameOverScreen.SetActive(true);
    }
    
    public void GameWin()
    {
        CancelInvoke(nameof(Spawn));
        CancelInvoke(nameof(SpawnStar));
        WinScreen.SetActive(true);
    }

    public void RestartGame()
    {
        var s = SceneManager.GetActiveScene();
        SceneManager.LoadScene(s.name);
    }
   
}
