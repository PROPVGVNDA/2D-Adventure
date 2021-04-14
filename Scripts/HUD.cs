using TMPro;
using UnityEngine;

public class HUD : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI numberOfCoins;
    [SerializeField] PlayerCoins playerCoinsController;
    [SerializeField] Sprite lostHeartImage;
    [SerializeField] GameObject[] playerHearts;
    private int livesLost = -1;

    private void Update()
    {
        numberOfCoins.text = playerCoinsController.playerGold.ToString();
    }

    public void UpdateOnPlayerHit()
    {
        livesLost++;
        playerHearts[livesLost].SetActive(true);
    }
}
