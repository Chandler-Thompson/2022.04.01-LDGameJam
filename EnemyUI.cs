using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyUI : MonoBehaviour
{
    public float health;
    public float maxHealth;

    public Slider hpBar;

    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
        hpBar.value = CalculateHealth();
    }

    // Update is called once per frame
    void Update()
    {

        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        hpBar.value = CalculateHealth();
    }

    float CalculateHealth()
    {
        return health / maxHealth;
    }

    public void takeDamage(int damage)
    {
        health = health - damage;
    }
}
