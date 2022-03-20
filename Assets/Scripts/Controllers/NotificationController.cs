using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NotificationController : MonoBehaviour
{

    public GameObject notifBar;
    public float notifDuration;

    private float notifStartTime = -1.0f;

    // Start is called before the first frame update
    void Start()
    {
        postNotification("Ready? Begin!");
    }

    // Update is called once per frame
    void Update()
    {
        if (notifStartTime != -1.0f && Time.time - notifStartTime > notifDuration)
        {
            notifStartTime = -1.0f;
            notifBar.GetComponent<Text>().text = "";
        }
    }

    public void postNotification(string notification)
    {
        notifBar.GetComponent<Text>().text = notification;
        notifStartTime = Time.time;
    }

}
