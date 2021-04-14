using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    [SerializeField] GameObject openedChestPrefab;
    [SerializeField] PlayerCoins playerCoinsController;
    private void OnTriggerStay2D(Collider2D other)
    {
        if (!other.gameObject.CompareTag("Player")) return;
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerCoinsController.OnChestOpen();
            Instantiate(openedChestPrefab, gameObject.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }    
    }
}
