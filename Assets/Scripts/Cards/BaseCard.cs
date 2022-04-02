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
    protected bool requiresTarget = false;

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

    public bool isCardSelected()
    {
        return isSelected;
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

    public virtual void OnPointerClick(PointerEventData eventData)
    {

        if (requiresTarget)
        {
            // leave target selection and card casting to PlayerManager
            if (!isSelected)
            { 
                playerManager.SelectCard(gameObject);
                isSelected = true;
                Debug.Log("[BaseCard] (OnPointerClick) Selected!");
            }
            else
            {
                playerManager.DeselectCard(gameObject);
                isSelected = false;
                Debug.Log("[BaseCard] (OnPointerClick) Deselected!");
            }
        }
        else
        {
            // Cast right away, no target needed
            Cast(null);
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.transform.localScale = this.transform.localScale - new Vector3(1, 1, 0);

        transform.SetSiblingIndex(prevHeirarchy);
    }

    public virtual void Cast(GameObject target)
    {
        // TODO: Add mana cost mechanic
        Debug.Log("Casting...");
        Deselect();
    }

}
