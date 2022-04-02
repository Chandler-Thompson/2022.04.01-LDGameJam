using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{

    [SerializeField] private string entityName;
    [SerializeField] private int maxHealth = 10;
    [SerializeField] private int currHealth = 10;
    [SerializeField] private int maxResource = 20;
    [SerializeField] private int currResource = 0;
    [SerializeField] private int resourceGrowth = 10;
    [SerializeField] private int DamageAmount = 1;
    [SerializeField] private int DamageMultModifier = 1;

    private ActionsManager actionsManager;

    // Start is called before the first frame update
    void Start()
    {
        actionsManager = GameObject.FindWithTag("ActionsManager").GetComponent<ActionsManager>();

        // Subscribe to all stats modifying events
        actionsManager.ModifyHealthEvent += onModifyHealth;
    }

    public string GetEntityName()
    {
        return entityName;
    }

    public int GetHealth()
    {
        return currHealth;
    }

    public int GetMaxHealth()
    {
        return maxHealth;
    }

    public int GetResource()
    {
        return currResource;
    }

    public int GetMaxResource()
    {
        return maxResource;
    }

    public int GetResourceGrowth()
    {
        return resourceGrowth;
    }

    void onModifyHealth(object sender, InfoEventArgs<string, int> e)
    {
        if(e.info1.Equals(entityName)) // I am the target
        {
            Console.WriteLine(entityName+"\'s health is being modified!");
            modifyHealth(e.info2);
        }
    }

    void onModifyMaxHealth(object sender, InfoEventArgs<string, int> e)
    {
        if(e.info1.Equals(entityName)) // I am the target
        {
            modifyMaxHealth(e.info2);
        }
    }

    void onModifyMaxResource(object sender, InfoEventArgs<string, int> e)
    {
        if(e.info1.Equals(entityName)) // I am the target
        {   
            modifyMaxResource(e.info2);
        }
    }

    void onModifyCurrResource(object sender, InfoEventArgs<string, int> e)
    {
        if(e.info1.Equals(entityName)) // I am the target
        {
            modifyCurrResource(e.info2);
        }
    }

    void onModifyResourceGrowth(object sender, InfoEventArgs<string, int> e)
    {
        if(e.info1.Equals(entityName)) // I am the target
        {
            modifyResourceGrowth(e.info2);
        }
    }

    void onModifyDamageAmount(object sender, InfoEventArgs<string, int> e)
    {
        if(e.info1.Equals(entityName)) // I am the target
        {
            modifyDamageAmount(e.info2);
        }
    }

    void onModifyDamageMultModifier(object sender, InfoEventArgs<string, int> e)
    {
        if(e.info1.Equals(entityName)) // I am the target
        {
            modifyDamageMultModifier(e.info2);
        }
    }

    private void modifyMaxResource(int modifyAmount)
    {
        maxResource += modifyAmount;
    }

    private void modifyCurrResource(int modifyAmount)
    {
        currResource += modifyAmount;
    }

    private void modifyResourceGrowth(int modifyAmount)
    {
        resourceGrowth += modifyAmount;
    }

    private void modifyDamageAmount(int modifyAmount)
    {
        DamageAmount += modifyAmount;
    }

    private void modifyDamageMultModifier(int modifyAmount)
    {
        DamageMultModifier += modifyAmount;
    }

    private void modifyHealth(int modifyAmount)
    {
        currHealth += modifyAmount;
    }

    private void modifyMaxHealth(int modifyAmount)
    {
        maxHealth += modifyAmount;
    }

}
