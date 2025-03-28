using UnityEngine;

public class Sensor : MonoBehaviour
{
    void OnCollisionEnter(Collision other)
    {
        SpawnController spawnController = FindObjectOfType<SpawnController>();
        if (other.gameObject.CompareTag("Player"))
        {
            spawnController.GameOver();
        }
        else Destroy(other.gameObject);
    }
}
