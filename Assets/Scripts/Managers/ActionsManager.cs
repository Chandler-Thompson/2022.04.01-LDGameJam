using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionsManager : MonoBehaviour
{

    public event EventHandler<InfoEventArgs<string, int>> ModifyHealthEvent;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ModifyHealth(GameObject sender, InfoEventArgs<string, int> e)
    {
        ModifyHealthEvent?.Invoke(sender, e);
    }

}
