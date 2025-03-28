using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    private Rigidbody rb;
    private GameObject player;
    private GameObject playerHp;


    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        Vector3 d = player.transform.position - transform.position;
        Vector3 dir = d.normalized;
        rb.AddForce(dir * speed);
    }

    void OnCollisionEnter(Collision PlayerCollision)
    {
        if (PlayerCollision.gameObject.CompareTag("Player"))
        {
            PlayerController playerController = PlayerCollision.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.Hp -= 1;
                if (playerController.Hp <= 0)
                {
                    playerController.OnGameOver();
                }
            }
            Destroy(gameObject);
        }
    }
}
