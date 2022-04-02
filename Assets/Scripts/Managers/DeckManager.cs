using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckManager : MonoBehaviour
{
    private string deckCode;
    public string DEFAULT_DECK_CODE = "A1_A1_A1_A1_A1_A1_A1_A1_A1_A1_A1_A1_A1_A1_A1_A1_A1_A1_F1_T1";

    //created in Start
    private List<GameObject> deck;
    private CardCatalog cardCatalog;

    private GameObject holdCard;

    //this card is when the cardCode can't be found.
    public GameObject nullCard;

    // Start is called before the first frame update
    void Start()
    {
        cardCatalog = GameObject.FindWithTag("CardCatalog").GetComponent<CardCatalog>();

        string storedDeck = DataManager.Instance.deckCode;

        if (storedDeck.Equals(""))
        {
            CreateDeck(DEFAULT_DECK_CODE);
        }
        else
        {
            CreateDeck(storedDeck);
        }
    }

    public void CreateDeck(string newCode)
    {
        deck = new List<GameObject>(); //sets it back to empty deck

        deckCode = newCode;
        string[] cardCodes = deckCode.Split('_');
        foreach (string code in cardCodes)
        {
            //holdCard = (GameObject)Instantiate(cardCatalog.GetComponent<CardCatalog>().GetCard(code));
            holdCard = cardCatalog.GetCard(code);
            
            if (holdCard == null)
            {
                holdCard = (GameObject)Instantiate(nullCard);
            }
            else
            {
                holdCard = (GameObject)Instantiate(cardCatalog.GetComponent<CardCatalog>().GetCard(code));
            }

            holdCard.transform.parent = gameObject.transform;
            deck.Add(holdCard);

        }
    }

    public void SaveDeck()
    {
        DataManager.Instance.deckCode = this.deckCode;
    }

    public GameObject DrawCard()
    {
        //Return card eventually
        GameObject tempCard = deck[deck.Count-1];
        deck.RemoveAt(deck.Count - 1);
        return tempCard;
    }
}
