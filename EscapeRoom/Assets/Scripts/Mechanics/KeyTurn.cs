using UnityEngine;
using System.Collections;

public class KeyTurn : MonoBehaviour
{
    Animation anim;
    Dropped dropped;
    Used used;
    WaitForSeconds delay = new WaitForSeconds(0.5f);
    public GameObject door;
    public GameObject exit;
    [ReadOnly] public bool rightTime;

    void Start()
    {
        anim = GetComponent<Animation>();
        dropped = GetComponent<Dropped>();
        used = GetComponent<Used>();
    }

    void OnMouseDown()
    {
        if (dropped.isDropped && !used.isUsed)
        {
            anim.enabled = true;
            TurnKey();
        }
    }

    void TurnKey()
    {
        anim.Play("keyTurn");
        FindObjectOfType<AudioManager>().Play("keyTurn");
        StartCoroutine(OpenDoor());
    }

    IEnumerator OpenDoor()
    {
        yield return delay;
        if (rightTime)
        {
            door.GetComponent<Animation>().Play();
            used.isUsed = true;
            exit.GetComponent<Collider>().enabled = true;
        }
        yield break;
    }
}
