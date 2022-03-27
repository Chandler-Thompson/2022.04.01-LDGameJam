using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyAttacks : MonoBehaviour
{
    public float stamina;
    public float staminaGrowth = 10;
    public float maxStamina;

    public Slider staminaBar;
    public Image attackImage;
    public Sprite attack1;
    public Sprite attack2;

    private int attack = 0;

    // Start is called before the first frame update
    void Start()
    {
        rollAttack();
    }

    // Update is called once per frame
    void Update()
    {
        stamina += staminaGrowth * Time.deltaTime;
   
        if (stamina > maxStamina)
        {
            performAttack();
            stamina = 0;
            rollAttack();
        }
        staminaBar.value = calculateStamina();
    }

    void rollAttack()
    { 
        attack = Random.Range(0, 2);
        if (attack == 0)
        {
            attackImage.sprite = attack1;
        }
        else if (attack == 1)
        {
            attackImage.sprite = attack2;
        }

    }

    void performAttack()
    {
        if (attack == 0)
        {
            GameObject Player = GameObject.FindWithTag("Player");
            Player.GetComponent<EnemyUI>().takeDamage(5);
        }
        else if (attack == 1)
        { 
            this.GetComponent<EnemyUI>().takeDamage(-5);
        }
    }

    float calculateStamina()
    {
        return stamina / maxStamina;
    }
}
