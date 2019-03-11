using UnityEngine;
using System.Collections;

public class BreakClock : MonoBehaviour {

    Renderer minuteRend;
    Renderer hourRend;
    Collider col;
    public static bool clockBroken;
    public GameObject shardPrefab;
    public GameObject minuteHand;
    public GameObject hourHand;
    AudioManager audioManager;

    void Start()
    {
        minuteRend = minuteHand.GetComponent<Renderer>();
        hourRend = hourHand.GetComponent<Renderer>();
        col = GetComponent<Collider>();
        col.enabled = true;
        clockBroken = false;
        audioManager = FindObjectOfType<AudioManager>();
    }

    void OnMouseDown ()
    {
        audioManager.Play("glass");
        minuteRend.material.color = Color.black;
        hourRend.material.color = Color.black;
        col.enabled = false;
        clockBroken = true;
        Destroy(gameObject);
        Instantiate(shardPrefab);
	}
}
