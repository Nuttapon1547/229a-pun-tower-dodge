using UnityEngine;
using UnityEngine.InputSystem.HID;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SpawnController : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject[] enemyPrefabs;  
    private Coroutine spawnCoroutine;
    public GameObject GameOverScreen;
    public Button restartButton;
    void Start()
    {
        GameOverScreen.SetActive(false);
        InvokeRepeating("Spawn", 2, 2);
    }
    
    void Spawn()
    {
        int spawnIdx = Random.Range(0, spawnPoints.Length);
        int enemyIdx = Random.Range(0, enemyPrefabs.Length);
        Instantiate(enemyPrefabs[enemyIdx], spawnPoints[spawnIdx].position, Quaternion.identity);
    }
    
    public void GameOver()
    {
        CancelInvoke(nameof(Spawn));
        GameOverScreen.SetActive(true);
    }

    public void RestartGame()
    {
        var s = SceneManager.GetActiveScene();
        SceneManager.LoadScene(s.name);
    }
   
}
