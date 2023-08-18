using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    public GameManager gameManager;
    UIManager uiManager;
    private void Start()
    {
        uiManager = FindObjectOfType<UIManager>();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedEnemy") || other.CompareTag("BlueEnemy") || other.CompareTag("GreenEnemy") || other.CompareTag("BigRedEnemy") || other.CompareTag("BigGreenEnemy") || other.CompareTag("BigBlueEnemy"))
        {
            //AdsManager._INSTANCE.SHOW_INTERSTITIAL_AD();
            uiManager.ShowLevelFailed();
        }
    }
}
