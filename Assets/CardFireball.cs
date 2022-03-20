using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardFireball : BaseCard
{

    public override void Cast(GameObject target)
    {

        StatsManager targetStats = target.transform.Find("StatsManager").gameObject.GetComponent<StatsManager>();

        if (targetStats == null)
        {
            Debug.Log("That target has no StatsManager!");
            return;
        }

        base.Cast(target);

        string targetName = targetStats.getEntityName();

        InfoEventArgs<string, int> fireballData = new InfoEventArgs<string, int>(targetName, -3);
        actionsManager.ModifyHealth(playerManager.gameObject, fireballData);
    }
}
