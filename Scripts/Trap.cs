using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] AudioSource hitSound;
    public event Action OnPlayerEnter;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("LLOLLL");
        if (!other.gameObject.CompareTag("Player")) return;
        if (OnPlayerEnter != null) OnPlayerEnter.Invoke();
        hitSound.PlayOneShot(hitSound.clip, 1);
    }
}
