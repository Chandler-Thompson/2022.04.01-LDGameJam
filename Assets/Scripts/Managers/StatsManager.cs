using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsManager : MonoBehaviour
{

    [SerializeField] private string entityName;
    [SerializeField] private int entityMaxHealth = 10;
    [SerializeField] private int entityCurrHealth = 10;
    [SerializeField] private int entityMaxResource = 10;
    [SerializeField] private int entityCurrResource = 10;
    [SerializeField] private int entityDamageAmount = 1;
    [SerializeField] private int entityDamageMultModifier = 1;

    private ActionsManager actionsManager;

    public string getEntityName()
    {
        return entityName;
    }

    // Start is called before the first frame update
    void Start()
    {
        actionsManager = GameObject.FindWithTag("ActionsManager").GetComponent<ActionsManager>();

        // Subscribe to all stats modifying events
        actionsManager.ModifyHealthEvent += onModifyHealth;
    }

    void onModifyHealth(object sender, InfoEventArgs<string, int> e)
    {
        if(e.info1.Equals(entityName)) // I am the target
        {
            Console.WriteLine(entityName+"\'s health is being modified!");
            modifyEntityHealth(e.info2);
        }
    }

    void onModifyMaxHealth(object sender, InfoEventArgs<string, int> e)
    {
        if(e.info1.Equals(entityName)) // I am the target
        {
            modifyEntityMaxHealth(e.info2);
        }
    }

    void onModifyMaxResource(object sender, InfoEventArgs<string, int> e)
    {
        if(e.info1.Equals(entityName)) // I am the target
        {
            modifyEntityMaxResource(e.info2);
        }
    }

    void onModifyCurrResource(object sender, InfoEventArgs<string, int> e)
    {
        if(e.info1.Equals(entityName)) // I am the target
        {
            modifyEntityCurrResource(e.info2);
        }
    }

    void onModifyDamageAmount(object sender, InfoEventArgs<string, int> e)
    {
        if(e.info1.Equals(entityName)) // I am the target
        {
            modifyEntityDamageAmount(e.info2);
        }
    }

    void onModifyDamageMultModifier(object sender, InfoEventArgs<string, int> e)
    {
        if(e.info1.Equals(entityName)) // I am the target
        {
            modifyEntityDamageMultModifier(e.info2);
        }
    }

    private void modifyEntityMaxResource(int modifyAmount)
    {
        entityMaxResource += modifyAmount;
    }

    private void modifyEntityCurrResource(int modifyAmount)
    {
        entityCurrResource += modifyAmount;
    }

    private void modifyEntityDamageAmount(int modifyAmount)
    {
        entityDamageAmount += modifyAmount;
    }

    private void modifyEntityDamageMultModifier(int modifyAmount)
    {
        entityDamageMultModifier += modifyAmount;
    }

    private void modifyEntityHealth(int modifyAmount)
    {
        entityCurrHealth += modifyAmount;
    }

    private void modifyEntityMaxHealth(int modifyAmount)
    {
        entityMaxHealth += modifyAmount;
    }

}
