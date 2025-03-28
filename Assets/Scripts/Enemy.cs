using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float speed = 1.5f;
    private Rigidbody rb;
    private GameObject player;
    
    
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
            Destroy(gameObject);
        }
    }
}
