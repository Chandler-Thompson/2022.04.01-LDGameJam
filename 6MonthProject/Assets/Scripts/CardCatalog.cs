using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;

public class CardCatalog : MonoBehaviour
{
    [Serializable]
    public class KeyValuePair
    {
        public string key;
        public GameObject val;
    }

    public List<KeyValuePair> MyList = new List<KeyValuePair>();
    public Dictionary<string, GameObject> cardCatalog = new Dictionary<string, GameObject>();


    // Start is called before the first frame update
    void Awake()
    {
        foreach (var kvp in MyList)
        {
            cardCatalog[kvp.key] = kvp.val;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetCard(string keyVal)
    {
        try
        {
            GameObject tempCard = cardCatalog[keyVal];
            return tempCard;
        }
        catch (KeyNotFoundException)
        {
            Console.WriteLine("Key is not found.");
            return null;
        }

    }
}
