using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnController : MonoBehaviour
{
    public PlayerController playerMovement;
    public Transform[] StarSpawnPoint;
    public GameObject StarPrefab;
    public int StarCounter;
    private int maxStars = 3;
    public Transform[] SpawnPoints;
    public GameObject EnemyPrefab;  
    private Coroutine spawnCoroutine;
    public GameObject GameOverPanel;
    public GameObject GameWinPanel;
    public Button RestartButton;
    public Button QuitButton;
    void Start()
    {
        playerMovement.enabled = true;
        GameOverPanel.SetActive(false);
        GameWinPanel.SetActive(false);
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
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        playerMovement.enabled = false;
        GameOverPanel.SetActive(true);
    }
    
    public void GameWin()
    {
        CancelInvoke(nameof(Spawn));
        CancelInvoke(nameof(SpawnStar));
        
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies) 
        {
            Destroy(enemy);
        }
        playerMovement.enabled = false;
        
            GameWinPanel.SetActive(true);
    }

    public void RestartGame()
    {
        var s = SceneManager.GetActiveScene();
        SceneManager.LoadScene(s.name);
    }
   
    public void QuitGame()
    {
        Application.Quit();
    }
}
