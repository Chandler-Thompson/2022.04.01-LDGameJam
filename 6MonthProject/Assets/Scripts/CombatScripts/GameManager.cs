using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool cardSelected = false;
    public string deckCode = "A1_A1_A1_A1_A1_A1_A1_A1_A1_A1_A1_A1_A1_A1_A1_A1_A1_A1_A1_T1";

    public GameObject deckManager;
    public GameObject cardCatalog;
    public GameObject handManager;

    // Start is called before the first frame update
    void Start()
    {
        cardCatalog = GameObject.FindWithTag("CardCatalog");
        deckManager = GameObject.FindWithTag("DeckManager");
        handManager = GameObject.FindWithTag("HandManager");

        deckManager.GetComponent<DeckManager>().createDeck(deckCode);
        handManager.GetComponent<HandManager>().StartingHand();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
