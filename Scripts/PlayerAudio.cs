using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAudio : MonoBehaviour
{
    [SerializeField] AudioSource playerJumpSource;

    public void PlayJumpSound()
    {
        playerJumpSource.PlayOneShot(playerJumpSource.clip, 1f);
    }
}
