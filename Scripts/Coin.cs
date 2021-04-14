using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] PlayerCoins playerCoinsController;
    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        playerCoinsController.OnCoinPickUp();
        Destroy(gameObject);
    }
}
