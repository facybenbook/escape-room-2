using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Exit : MonoBehaviour {

    public Animation exit;
    public Animation fadeToBlack;
    public Used keyUsed;
    Collider col;

    void Start()
    {
        col = GetComponent<Collider>();
        col.enabled = false;
    }

    void OnMouseDown()
    {
        if (keyUsed.isUsed)
        {
            Destroy(col);
            exit.Play();
            fadeToBlack.gameObject.SetActive(true);
            fadeToBlack.Play();
            Debug.Log("Thank you for playing!");
        }
        else return;
    }
}
