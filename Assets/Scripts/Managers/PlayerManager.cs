using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    [HideInInspector] public HandManager handManager;
    [HideInInspector] public StatsManager statsManager;

    private List<GameObject> selectedCards;

    private Plane raycastPlane;

    // Start is called before the first frame update
    void Start()
    {
        handManager = GameObject.FindWithTag("HandManager").GetComponent<HandManager>();
        statsManager = GameObject.FindWithTag("StatsManager").GetComponent<StatsManager>();
        selectedCards = new List<GameObject>();

        // Make sure ray starts back enough behind camera in order to intersect entity's collider
        raycastPlane = new Plane(Vector3.forward, new Vector3(0, 0, -2));
    }

    void FixedUpdate()
    {

        // Needed because camera is in perspective, not orthogonal
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float distance;
        raycastPlane.Raycast(ray, out distance);
        Vector3 worldPosition = ray.GetPoint(distance);

        RaycastHit hit;
        int layerMask = 1 << 3; // layer 3 has targetable entities
        if (Physics.Raycast(worldPosition, transform.TransformDirection(Vector3.forward), out hit, Mathf.Infinity, layerMask))
        {
            Debug.DrawRay(worldPosition, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);

            StatsManager targetStats = hit.transform.Find("StatsManager").gameObject.GetComponent<StatsManager>();

            if (targetStats != null)
            {
                GameObject.FindWithTag("NotificationController").GetComponent<NotificationController>().postNotification("Hit "+targetStats.getEntityName()+"!");
            }

        }
        else
        {
            Debug.DrawRay(worldPosition, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
            // Debug.Log("Did not Hit");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Select(GameObject card)
    {
        selectedCards.Add(card);
    }

    public void Deselect(GameObject card)
    {
        selectedCards.Remove(card);
    }

    public bool getIsSelected(GameObject card)
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

}
