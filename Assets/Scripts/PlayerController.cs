using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 5.0f;
    private float horizontalInput;
    private float forwardInput;
    public float hp = 5f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        InputAction move = InputSystem.actions.FindAction("Move");
        horizontalInput = move.ReadValue<Vector2>().x;
        forwardInput = move.ReadValue<Vector2>().y;

        transform.Translate(forwardInput * speed * Time.deltaTime * Vector3.forward);
        transform.Translate(horizontalInput* speed * Time.deltaTime * Vector3.right);
    }
   
    void OnCollisionEnter(Collision EnemyCollision)
    {
        if (EnemyCollision.gameObject.CompareTag("Enemy"))
        {
            hp -= 1;
            if (hp <= 0)
            {
                OnGameOver();
            }
        }
    }
    void OnGameOver()
    {
        SpawnController spawnController = FindObjectOfType<SpawnController>();
        if (spawnController != null)
        {
            spawnController.GameOver();
        }
    }

    
}
