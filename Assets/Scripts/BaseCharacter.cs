using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BaseCharacter : MonoBehaviour
{
    [SerializeField] private Slider hpBar;
    [SerializeField] private Slider staminaBar;

    [SerializeField] private Image attackImage;
    [SerializeField] private Sprite attack1;
    [SerializeField] private Sprite attack2;

    private PlayerManager playerManager;
    private StatsManager statsManager;

    private bool isSelected = false;

    private int health;
    private int maxHealth;

    private int stamina;
    private int staminaGrowth;
    private int maxStamina;

    private int attackType = 0;

    // Start is called before the first frame update
    void Start()
    {

        playerManager = GameObject.FindWithTag("PlayerManager").GetComponent<PlayerManager>();
        statsManager = transform.Find("StatsManager").gameObject.GetComponent<StatsManager>();

        health = statsManager.GetHealth();
        maxHealth = statsManager.GetMaxHealth();
        hpBar.value = CalculateHealth();

        stamina = statsManager.GetResource();
        maxStamina = statsManager.GetMaxResource();
        staminaGrowth = statsManager.GetResourceGrowth();
        staminaBar.value = CalculateStamina();

        rollAttack();

    }

    // Update is called once per frame
    void Update()
    {

        health = statsManager.GetHealth();
        maxHealth = statsManager.GetMaxHealth();
        
        stamina = statsManager.GetResource();
        maxStamina = statsManager.GetMaxResource();
        staminaGrowth = statsManager.GetResourceGrowth();

        if (health <= 0)
        {
            Destroy(gameObject);
        }
        if (health > maxHealth)
        {
            health = maxHealth;
        }

        hpBar.value = CalculateHealth();

        stamina += (int) (staminaGrowth * Time.deltaTime); // TODO: have this throw event instead

        if (stamina > maxStamina)
        {
            performAttack();
            stamina = 0;
            rollAttack();
        }

        staminaBar.value = CalculateStamina();
    }

    public void OnMouseDown()
    {

        // leave target selection and card casting to PlayerManager
        if (!isSelected)
        { 
            playerManager.SelectEntity(gameObject);
            isSelected = true;
            Debug.Log("[BaseCharacter] (OnPointerClick) Selected!");
        }
        else
        {
            playerManager.DeselectEntity(gameObject);
            isSelected = false;
            Debug.Log("[BaseCharacter] (OnPointerClick) Deselected!");
        }

    }

    protected virtual void rollAttack()
    { 
        attackType = Random.Range(0, 2);
        if (attackType== 0)
        {
            //attackImage.sprite = attack1;
        }
        else if (attackType== 1)
        {
            //attackImage.sprite = attack2;
        }

    }

    protected virtual void performAttack()
    {
        // TODO: Update with latest architecture
        if (attackType== 0)
        {
            GameObject Player = GameObject.FindWithTag("Player");
            //Player.GetComponent<EnemyUI>().TakeDamage(5);
        }
        else if (attackType== 1)
        { 
            //this.GetComponent<EnemyUI>().TakeDamage(-5);
        }
    }

    private int CalculateHealth()
    {
        return health / maxHealth;
    }

    private int CalculateStamina()
    {
        return stamina / maxStamina;
    }

}
