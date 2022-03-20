using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    [HideInInspector] public DeckManager deckManager;
    [HideInInspector] public CardCatalog cardCatalog;
    [HideInInspector] public PlayerManager playerManager;
    [HideInInspector] public SceneController sceneController;

    // Start is called before the first frame update
    void Start()
    {
        cardCatalog = GameObject.FindWithTag("CardCatalog").GetComponent<CardCatalog>();
        deckManager = GameObject.FindWithTag("DeckManager").GetComponent<DeckManager>();
        playerManager = GameObject.FindWithTag("PlayerManager").GetComponent<PlayerManager>();

        playerManager.handManager.StartingHand();
        sceneController = new SceneController();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
