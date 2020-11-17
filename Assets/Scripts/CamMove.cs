using UnityEngine;

public class CamMove : MonoBehaviour
{
    [SerializeField] float forwardSpeed = 10f;

    private Rigidbody rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void FixedUpdate()
    {
        if(SphereMoveble.isAlive)
            rb.velocity = new Vector3(0, 0, forwardSpeed * Time.deltaTime);
        else
            rb.velocity = Vector3.zero;
    }
}
