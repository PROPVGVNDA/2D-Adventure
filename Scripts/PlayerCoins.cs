using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoins : MonoBehaviour
{
    [SerializeField] AudioSource coinPickupSound;
    public int playerGold = 0;

    public void OnChestOpen()
    {
        playerGold += 10;
        PlayCoinPickupSound();
    }

    public void OnCoinPickUp()
    {
        playerGold++;
        PlayCoinPickupSound();
    }

    private void PlayCoinPickupSound() => coinPickupSound.PlayOneShot(coinPickupSound.clip, 0.25f);
}
