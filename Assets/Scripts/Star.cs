using UnityEngine;
using TMPro;
public class Star : MonoBehaviour
{
    void OnCollisionEnter(Collision PlayerCollision)
    {
        Debug.Log("get star");
        if (PlayerCollision.gameObject.CompareTag("Player"))
        {
            PlayerController playerController = PlayerCollision.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.GetStars(1);
            }
            Destroy(gameObject);
        }
    }
}
