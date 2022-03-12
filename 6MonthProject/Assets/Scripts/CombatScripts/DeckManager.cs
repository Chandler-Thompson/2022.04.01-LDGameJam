using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    private string deckCode = "A1_A1_A1_A1_A1_A1_A1_A1_A1_A1_A1_A1_A1_A1_A1_A1_A1_A1_A1_A1"; //default deck code

    //created in Start
    private List<GameObject> deck;
    private GameObject cardCatalog;

    private GameObject holdCard;

    //this card is when the cardCode can't be found.
    public GameObject nullCard;

    // Start is called before the first frame update
    void Start()
    {
        deck = new List<GameObject>();
        cardCatalog = GameObject.FindWithTag("CardCatalog");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void createDeck(string newCode)
    {
        deck = new List<GameObject>(); //sets it back to empty deck

        deckCode = newCode;
        string[] cardCodes = deckCode.Split('_');
        foreach (string code in cardCodes)
        {
            //holdCard = (GameObject)Instantiate(cardCatalog.GetComponent<CardCatalog>().GetCard(code));
            holdCard = cardCatalog.GetComponent<CardCatalog>().GetCard(code);
            if (holdCard == null)
            {
                holdCard = (GameObject)Instantiate(nullCard);
                deck.Add(holdCard);
            }
            else
            {
                holdCard = (GameObject)Instantiate(cardCatalog.GetComponent<CardCatalog>().GetCard(code));
                deck.Add(holdCard);
            }
        }
    }

    public GameObject DrawCard()
    {
        //Return card eventually
        GameObject tempCard = deck[deck.Count-1];
        deck.RemoveAt(deck.Count - 1);
        return tempCard;
    }
}
