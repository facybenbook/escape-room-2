using UnityEngine;
using System.Collections;

public class ChairArm : MonoBehaviour
{
    Animation anim;
    Collider col;
    public GameObject stillChair;
    public GameObject movingChair;
    public float rotateSpeed;
    Rigidbody rb;
    AudioManager audioManager;

    void Start()
    {
        anim = GetComponent<Animation>();
        col = GetComponent<Collider>();
        rb = GetComponent<Rigidbody>();
        audioManager = FindObjectOfType<AudioManager>();
    }

    void OnMouseDown()
    {
        Destroy(col);
        anim.Play();
        StartCoroutine(SwitchChair());
    }

    IEnumerator SwitchChair()
    {
        while (anim.isPlaying)
        {
            yield return null;
        }
        audioManager.Play("chairArm");
        rb.isKinematic = false;
        rb.angularVelocity = (Vector3.right * rotateSpeed);
        transform.parent = null;
        Destroy(stillChair);
        movingChair.SetActive(true);
    }
}
