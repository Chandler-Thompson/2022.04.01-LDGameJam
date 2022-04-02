using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    [HideInInspector] public HandManager handManager;
    [HideInInspector] public StatsManager statsManager;

    private List<GameObject> selectedCards;
    private List<GameObject> selectedEntities;

    // Start is called before the first frame update
    void Start()
    {
        handManager = GameObject.FindWithTag("HandManager").GetComponent<HandManager>();
        statsManager = GameObject.FindWithTag("StatsManager").GetComponent<StatsManager>();

        selectedCards = new List<GameObject>();
        selectedEntities = new List<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (selectedCards.Count > 0)
        {
            if (selectedEntities.Count > 0)
            {
                foreach (GameObject card in selectedCards)
                {
                    BaseCard castingCard = card.GetComponent<BaseCard>();
                    castingCard.Cast(selectedEntities[0]);
                }
            }
        }

    }

    public void SelectCard(GameObject card)
    {
        selectedCards.Add(card);
    }

    public void SelectEntity(GameObject entity)
    {
        selectedEntities.Add(entity);
    }

    public void DeselectCard(GameObject card)
    {
        selectedCards.Remove(card);
    }

    public void DeselectEntity(GameObject entity)
    {
        selectedEntities.Remove(entity);
    }

    public bool getIsCardSelected(GameObject card)
    {
        foreach (GameObject selectedCard in selectedCards)
        {
            if(GameObject.ReferenceEquals(card, selectedCard))
            {
                return true;
            }
        }
        return false;
    }

    public bool getIsEntitySelected(GameObject entity)
        {
        foreach (GameObject selectedEntity in selectedEntities)
        {
            if(GameObject.ReferenceEquals(entity, selectedEntity))
            {
                return true;
            }
        }
        return false;
    }

}
