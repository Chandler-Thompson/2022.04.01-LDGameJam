using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class HandManager : MonoBehaviour
{
    public GameObject canvas;

    public int startHandSize = 5;
    public int handLimit = 10;
    public GameObject deck;

    private List<GameObject> hand;

    private NotificationController notifController;

    // Start is called before the first frame update
    void Start()
    {
        hand = new List<GameObject>();
        deck = GameObject.FindWithTag("DeckManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //Draw Card from Deck
    public void DrawCard()
    {
        if (hand.Count > 0 && hand.Count < 10)
        {
            GameObject tempCard = hand[hand.Count - 1];
            hand.Add(deck.GetComponent<DeckManager>().DrawCard());
            hand[hand.Count - 1].transform.parent = canvas.transform;
            hand[hand.Count - 1].transform.position = this.transform.position;
            hand[hand.Count - 1].GetComponent<BaseCard>().handPosition = tempCard.GetComponent<BaseCard>().handPosition + 1;
        }
        else if (hand.Count < 10)
        {
            hand.Add(deck.GetComponent<DeckManager>().DrawCard());
            hand[hand.Count - 1].transform.parent = canvas.transform;
            hand[hand.Count - 1].transform.position = this.transform.position;
            hand[hand.Count - 1].GetComponent<BaseCard>().handPosition = 0;
        }
        else
        {
            if (notifController == null)
            {
                notifController = GameObject.FindWithTag("NotificationController").GetComponent<NotificationController>();
            }

            notifController.postNotification("Can not draw more cards!");
        }
        reorderHand();
    }

    public void StartingHand()
    {
        for (int i = 0; i < startHandSize; i++)
        {
            DrawCard();
        }
    }

    void reorderHand()
    {
        for (int i = 0; i < hand.Count; i++)
        {
            hand[i].transform.position = this.transform.position;
            hand[i].transform.eulerAngles = this.transform.eulerAngles;
            setCardPosition(hand[i], i, hand.Count);
        }
    }

    //Rotates the card to fit the arc
    void setCardPosition(GameObject card, int cardP, int handSize)
    {
        handSize--;
        float half = (float)handSize / 2;
        float diff = half - cardP;

        card.transform.position = card.transform.position + new Vector3(diff * 100, Math.Abs(diff * diff * 4) * -1, 0); //I don't know why this looks the best, it just does
        card.transform.eulerAngles = card.transform.eulerAngles + new Vector3(0, 0, -diff * 5);
    }

    public int getHandSize()
    {
        return hand.Count;
    }
}
