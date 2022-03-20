using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class BaseCard : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [HideInInspector] public int handPosition = 0;

    public int cost = 0;

    protected PlayerManager playerManager;
    protected ActionsManager actionsManager;
    protected TextMeshProUGUI costDisplay;

    private Vector3 prevRotation; //used for setting the rotation back to original rotation
    private int prevHeirarchy;
    private bool isSelected = false;

    // Start is called before the first frame update
    void Start()
    {
        playerManager = GameObject.FindWithTag("PlayerManager").GetComponent<PlayerManager>();
        actionsManager = GameObject.FindWithTag("ActionsManager").GetComponent<ActionsManager>();

        costDisplay = transform.Find("Cost").gameObject.GetComponent<TextMeshProUGUI>();
        costDisplay.text = cost.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        if(isSelected)
        {
            // TODO: Card selected animation/visual goes here
        }
    }

    public void Deselect()
    {
        isSelected = false;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.transform.localScale = this.transform.localScale + new Vector3(1, 1, 0);

        prevHeirarchy = this.transform.GetSiblingIndex();
        this.transform.SetSiblingIndex(playerManager.handManager.getHandSize() + 1);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if(!isSelected)
        { 
            playerManager.Select(gameObject);
            isSelected = true;
        }
        else
        {
            playerManager.Deselect(gameObject);
            isSelected = false;
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.transform.localScale = this.transform.localScale - new Vector3(1, 1, 0);

        transform.SetSiblingIndex(prevHeirarchy);
    }

    public virtual void Cast(GameObject target)
    {
        Deselect();
    }

}
