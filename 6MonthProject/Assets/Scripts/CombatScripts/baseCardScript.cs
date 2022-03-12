using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class baseCardScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public int handPosition = 0;
    public int cost = 0;

    public GameObject gameManager;
    public GameObject handManager;


    private Vector3 prevRotation; //used for setting the rotation back to original rotation
    private int prevHeirarchy;
    private bool selected = false;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.FindWithTag("GameManager");
        handManager = GameObject.FindWithTag("HandManager");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        this.transform.localScale = this.transform.localScale + new Vector3(1, 1, 0);

        prevHeirarchy = this.transform.GetSiblingIndex();
        this.transform.SetSiblingIndex(handManager.GetComponent<HandManager>().getHandSize() + 1);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (gameManager.GetComponent<GameManager>().cardSelected == false && selected == false)
        { 
            
        }

            
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        this.transform.localScale = this.transform.localScale - new Vector3(1, 1, 0);

        transform.SetSiblingIndex(prevHeirarchy);
    }
}
