using UnityEngine;

public class Star : MonoBehaviour
{
    void OnCollisionEnter(Collision PlayerCollision)
    {
        if (PlayerCollision.gameObject.CompareTag("Player"))
        {
            PlayerController playerController = PlayerCollision.gameObject.GetComponent<PlayerController>();
            if (playerController != null)
            {
                playerController.starCounter += 1;
                if (playerController.starCounter >= 5)
                {
                    playerController.OnGameWin();
                }
            }
            Destroy(gameObject);
        }
    }
}
