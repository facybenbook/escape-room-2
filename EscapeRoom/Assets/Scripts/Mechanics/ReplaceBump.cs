using UnityEngine;

public class ReplaceBump : MonoBehaviour
{
    public int condition;
    Rigidbody rb;
    public int force;
    [Tooltip("Back 0, 0, -1 \n Down 0, -1, 0 \n Forward 0, 0, 1 \n Left -1, 0, 0 \n Right 1, 0, 0 \n Up 0, 1, 0 \n One 1, 1, 1 \n Zero 0, 0, 0")]
    public Vector3 direction;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void LateUpdate()
    {
        if (Player.condition == condition)
        {
            rb.isKinematic = false;
            rb.AddForce(direction * force);
            Destroy(this);
        }
    }
}