using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class BookWatch : MonoBehaviour {

    public static int booksSleeping;
    ZoneCheck[] zoneCheckList;
    static public Dictionary<int, int> zonesFull;
    public static int howManyZonesFull;
    public static bool safeUnlocked;
    public static bool force;
    //public bool debug;
    public GameObject zoneParent;
    public Transform safeDoor;
    Animation anim;
    public LensFlare laser;
    WaitForSeconds delay = new WaitForSeconds(0.5f);
    AudioManager audioManager;

    void Awake ()
    {
        audioManager = FindObjectOfType<AudioManager>();
        //booksSleeping = 20;
        safeUnlocked = false;
        force = false;
        zonesFull = new Dictionary<int, int>();
        zoneCheckList = GameObject.Find("Bookshelf").transform.GetChild(2).GetComponentsInChildren<ZoneCheck>();
    }

    //void Update()
    //{
    //    Debug.Log("Zones Full " + howManyZonesFull);
    //    Debug.Log("Book Counter " + booksSleeping);
    //}

    public void ZeroCheck()
    {
        foreach (ZoneCheck zone in zoneCheckList)
        {
            if (zone.counter == 0 && zone.zoneValue == 0)
            {
                zonesFull[zone.zoneNumber] = 1;
            }
            else if (zone.counter == zone.zoneValue)
            {
                zonesFull[zone.zoneNumber] = 1;
            }
            else
            {
                zonesFull[zone.zoneNumber] = 0;
            }
        }
        howManyZonesFull = zonesFull.Sum(v => v.Value);
        if /*((booksSleeping == 20) && */(howManyZonesFull == 12)//)
        {
            //Debug.Log("Unlocked!");
            audioManager.Play("success");
            audioManager.sounds[6].volume = 0;
            SafeUnlock();
        }
        else return;

    }

    public void SafeUnlock()
    {
        anim = safeDoor.GetComponent<Animation>();
        laser.color = Color.red;
        StartCoroutine(Unlock());
    }

    IEnumerator Unlock()
    {
        while (Player.i != 5)// || howManyZonesFull != 12)
        {
            yield return null;
        }
        yield return delay;
        safeUnlocked = true;
        audioManager.Play("safeDoor");
        anim.Play();
        Destroy(zoneParent);
        laser.color = Color.green;
        Destroy(gameObject);
    }

    //public void DebugFunc()
    //{
    //    Debug.Log("Zones Full " + howManyZonesFull);
    //    Debug.Log("Book Counter " + booksSleeping);
    //}
}
