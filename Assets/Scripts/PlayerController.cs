using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public Animator Anim;
    Rigidbody rb;
    public float speed = 5.0f;
    private float horizontalInput;
    private float forwardInput;
    public float Hp = 5f;
    public int starCounter;
    
    public TextMeshProUGUI heartText;
    public TextMeshProUGUI starText;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        
        if (heartText != null)
        { 
            heartText.text = Hp.ToString();
        }
    }

    //player movement
    void Update()
    {
        InputAction move = InputSystem.actions.FindAction("Move");
        horizontalInput = move.ReadValue<Vector2>().x;
        forwardInput = move.ReadValue<Vector2>().y;

        transform.Translate(forwardInput * speed * Time.deltaTime * Vector3.forward);
        transform.Translate(horizontalInput* speed * Time.deltaTime * Vector3.right);

        if (horizontalInput > 0 || forwardInput > 0)
        {
            Anim.SetBool("IsMoving", true);
        }
        else  Anim.SetBool("IsMoving", false);
        
    }

    public void TakeDamage(int damage)
    {
        Hp -= damage;
        if (heartText != null)
        {
            heartText.text = Hp.ToString();
        }
        
        if (Hp <= 0)
        {
            OnGameOver();
            Hp = 0;
        }
    }

    public void GetStars(int star)
    {
        starCounter++;
        if (starText != null)
        {
            starText.text = starCounter.ToString();
        }

        if (starCounter >= 5)
        {
            OnGameWin();
            Hp = 0;
        }
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
