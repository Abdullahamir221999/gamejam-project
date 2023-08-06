using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public GameManager gameManager;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedEnemy") || other.CompareTag("BlueEnemy") || other.CompareTag("GreenEnemy"))
        {
            gameManager.EndGame();
        }
    }
}
