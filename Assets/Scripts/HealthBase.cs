using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBase : MonoBehaviour {
    [SerializeField] int baseHP = 10;
    [SerializeField] int healthDecrease = 1;
    [SerializeField] Text healthText;

    private void Start()
    {
        healthText.text = baseHP.ToString();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        baseHP = baseHP - healthDecrease;
        healthText.text = baseHP.ToString();
    }

    
}
