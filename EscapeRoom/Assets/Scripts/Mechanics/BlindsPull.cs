using UnityEngine;
using System.Collections;

public class BlindsPull : MonoBehaviour
{
    LightManager LM;
    Vector3 startWorld;
    Vector3 startScreen;
    Vector3 newPos;
    Vector3 oldPos;
    Animation anim;
    public Transform blinds;
    public Transform stringParent;
    public Transform blindsPullParent;
    Vector3 stringParentStart;
    Vector3 stringParentEnd;
    Rigidbody[] stringRBs;
    float t;
    float ct;
    public Transform cube;
    Animation bottomBlind;
    Vector3 cubeStart;
    public Transform brokenCog;
    public Transform finalCog;
    Rigidbody cogRB;
    float deltaY;
    float cubeDist;
    float pullDist;
    Quaternion cogRot;
    public int condition;
    Rigidbody rb;
    bool dragging;
    Transform toDrag;
    Vector3 v3;
    public float limit;
    bool stringStart;
    bool hitTransform;
    public float animDiv;
    float lmx;

    void Start()
    {
        LM = GameObject.Find("LightManager").GetComponent<LightManager>();
        lmx = LM.x;
        dragging = false;
        t = 0;
        ct = 0;
        stringStart = false;
        hitTransform = false;
        startWorld = transform.position;
        startScreen = Camera.main.WorldToScreenPoint(startWorld);
        rb = GetComponent<Rigidbody>();
        stringParentStart = stringParent.transform.position;
        anim = blinds.GetComponent<Animation>();
        anim.Play();
        anim["blinds"].speed = 0;
        stringRBs = stringParent.GetComponentsInChildren<Rigidbody>();
        bottomBlind = cube.GetComponent<Animation>();
        cubeStart = cube.position;
        cogRB = brokenCog.GetComponent<Rigidbody>();
        cogRB.isKinematic = true;
        oldPos = transform.position;
        cogRot = brokenCog.rotation;
        foreach (Rigidbody stringRB in stringRBs)
        {
            if (stringRB.gameObject.GetInstanceID() != stringParent.gameObject.GetInstanceID())
            {
                stringRB.isKinematic = false;
            }
        }
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == transform)
                {
                    hitTransform = true;
                    transform.SetParent(null);
                    startScreen = Camera.main.WorldToScreenPoint(startWorld);
                    toDrag = transform;
                    dragging = true;
                    anim["blinds"].normalizedTime = (startWorld.y - transform.position.y) / animDiv;
                }
            }
        }
        if (Input.GetMouseButton(0))
        {
            if (dragging)
            {
                oldPos = transform.position;
                v3 = new Vector3(startScreen.x, Mathf.Clamp(Input.mousePosition.y, startScreen.y - limit, startScreen.y), startScreen.z);
                v3 = Camera.main.ScreenToWorldPoint(v3);
                toDrag.position = v3;
                newPos = transform.position;
                deltaY = newPos.y - oldPos.y;
                pullDist = startWorld.y - transform.position.y;
                LM.x = pullDist;
                anim.enabled = true;
                foreach (Rigidbody stringRB in stringRBs)
                {
                    if (stringRB.gameObject.GetInstanceID() != stringParent.GetInstanceID())
                    {
                        stringRB.isKinematic = true;
                    }
                }
                stringParent.transform.position = new Vector3(stringParentStart.x, stringParentStart.y - pullDist, stringParentStart.z);
                anim["blinds"].normalizedTime = (startWorld.y - transform.position.y) / animDiv;
                StartCoroutine(CogTurn());
            }
        }
        if (Input.GetMouseButtonUp(0))
        {
            dragging = false;
            foreach (Rigidbody stringRB in stringRBs)
            {
                if (stringRB.gameObject.GetInstanceID() != stringParent.gameObject.GetInstanceID())
                {
                    stringRB.isKinematic = false;
                }
            }
            stringParentEnd = stringParent.position;
            if (hitTransform)
            {
                transform.SetParent(blindsPullParent);
                hitTransform = false;
                StartCoroutine(BlindsUp());
            }
        }
        if (stringParent.transform.position.y >= stringParentStart.y)
        {
            stringStart = true;
        }
        else
        {
            stringStart = false;
        }
    }

    IEnumerator BlindsUp()
    {
        if (Player.condition != condition)
        {
            while (stringParent.transform.position.y < stringParentStart.y)
            {
                stringParent.transform.position = Vector3.Lerp(stringParentEnd, stringParentStart, t);
                t += 10 * Time.deltaTime;
                anim["blinds"].normalizedTime = (startWorld.y - transform.position.y) / animDiv;
                LM.x = Mathf.Lerp(LM.x, lmx, t);
                yield return null;
            }
            StartCoroutine(BottomBlind());
        }
        else if (Player.condition == condition)
        {
            while (!stringStart && (stringParent.transform.position.y < stringParentEnd.y + 1))
            {
                stringParent.transform.position = Vector3.Lerp(stringParentEnd, new Vector3(stringParentEnd.x, stringParentEnd.y + 1, stringParentEnd.z), t);
                t += 10 * Time.deltaTime;
                anim["blinds"].normalizedTime = (startWorld.y - transform.position.y) / animDiv;
                yield return null;
            }
        }
        if (t > 1)
        {
            t = 0;
        }
        rb.isKinematic = false;
        rb.AddForce(Vector3.back * 100);
        StartCoroutine(CogStick());
    }

    IEnumerator BottomBlind() //hop at end
    {
        bottomBlind.Play();
        while (bottomBlind.isPlaying)
        {
            anim["blinds"].normalizedTime = (cube.position.y - cubeStart.y) * (pullDist / 60);
            yield return null;
        }
    }

    IEnumerator CogStick()
    {
        while (ct <= 1)
        {
            if (Player.condition != condition)
            {
                brokenCog.rotation = Quaternion.Lerp(brokenCog.rotation, cogRot, ct);
                ct += 10 * Time.deltaTime;
                yield return null;
            }
            else if (Player.condition == condition)
            {
                finalCog.rotation = Quaternion.Lerp(finalCog.rotation, cogRot, ct);
                ct += 10 * Time.deltaTime;
                yield return null;
            }
        }
        if (ct > 1)
        {
            ct = 0;
        }
    }

    IEnumerator CogTurn()
    {
        if (Player.condition != condition)
        {
            yield return null;
            brokenCog.Rotate(Vector3.forward * deltaY * 30, Space.World);
        }
        else if (Player.condition == condition)
        {
            yield return null;
            finalCog.Rotate(Vector3.forward * deltaY * 30, Space.World);
        }
    }
}

