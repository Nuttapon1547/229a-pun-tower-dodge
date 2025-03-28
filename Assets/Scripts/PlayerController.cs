using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5.0f;
    private float horizontalInput;
    private float forwardInput;
    public float Hp = 5f;
    public int starCounter;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    //player movement
    void Update()
    {
        InputAction move = InputSystem.actions.FindAction("Move");
        horizontalInput = move.ReadValue<Vector2>().x;
        forwardInput = move.ReadValue<Vector2>().y;

        transform.Translate(forwardInput * speed * Time.deltaTime * Vector3.forward);
        transform.Translate(horizontalInput* speed * Time.deltaTime * Vector3.right);
    }
    
    public void OnGameOver()
    {
        SpawnController spawnController = FindObjectOfType<SpawnController>();
        if (spawnController != null)
        {
            spawnController.GameOver();
        }
    }
    
    public void OnGameWin()
    {
        SpawnController spawnController = FindObjectOfType<SpawnController>();
        if (spawnController != null)
        {
            spawnController.GameWin();
        }
    }
    
}
