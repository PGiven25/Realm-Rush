using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBase : MonoBehaviour {
    [SerializeField] int baseHP = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text healthText;
    [SerializeField] AudioClip baseHit;

    private void Start()
    {
        healthText.text = baseHP.ToString();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        GetComponent<AudioSource>().PlayOneShot(baseHit);
        baseHP = baseHP - healthDecrease;
        healthText.text = baseHP.ToString();
    }

    
}
