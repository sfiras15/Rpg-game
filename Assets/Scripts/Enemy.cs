using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Script attached to the insects 
public class Enemy : MonoBehaviour
{
    public Health healthPoints;
    public bool takingDamage;
    public bool dead;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        healthPoints = new Health(100);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        takingDamage = false;
        healthBar.UpdateHealth(healthPoints.GetMaxHealth, healthPoints.GetCurrentHealth);
    }
}
