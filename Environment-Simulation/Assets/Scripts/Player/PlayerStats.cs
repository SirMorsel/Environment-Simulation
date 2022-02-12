using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    [SerializeField] private float maxHealth = 250.0F;
    [SerializeField] private float walkSpeed = 5.0F;
    [SerializeField] private float runSpeed = 10.0F;
    [SerializeField] private float turnSpeed = 10.0F;

    [SerializeField] private float meleeDamage = 20.0F;
    [SerializeField] private float criticalMultiplier = 5.0F;
    [SerializeField] private float attackInterval = 2.0F;

    private float currentHealth;
    // Start is called before the first frame update

    private void Awake()
    {
        currentHealth = maxHealth;
    }
    void Start()
    {

    }

    public float GetCurrentHealth()
    {
        return currentHealth;
    }

    public float GetWalkSpeed()
    {
        return walkSpeed;
    }

    public float GetRunSpeed()
    {
        return runSpeed;
    }

    public float GetTurnSpeed()
    {
        return turnSpeed;
    }

    public float GetMeleeDamage()
    {
        return meleeDamage;
    }

    public float GetCritMultiplier()
    {
        return criticalMultiplier;
    }

    public float GetAttackInterval()
    {
        return attackInterval;
    }
}
