using UnityEngine;

public class SphereMoveble : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] float forwardSpeed = 10f;
    [SerializeField] float horizSpeed = 2f;
    [SerializeField] float verticalSpeed = 2f;

    [SerializeField] ParticleSystem deathPart;
    ParticleSystem partPlaer;

    MeshRenderer meshRend;

    public static bool isAlive;

    private void Awake()
    {
        meshRend = GetComponent<MeshRenderer>();
        partPlaer = GetComponent<ParticleSystem>();
        rb = GetComponent<Rigidbody>();
    }

    void Start()
    {
        meshRend.enabled = true;
        isAlive = true;
    }

    
    void FixedUpdate()
    {
        if (isAlive)
            Move();
    }

    void Move()
    {
        float horizonPos = Input.GetAxis("Horizontal");
        float verticalPos = Input.GetAxis("Vertical");

        if(horizonPos != 0)
            rb.velocity = new Vector3(horizonPos * Time.deltaTime * horizSpeed, rb.velocity.y, rb.velocity.z);
        //transform.position += new Vector3(horizonPos * Time.deltaTime * horizSpeed, rb.velocity.y, rb.velocity.z); 

        if (verticalPos != 0)
            transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + (verticalPos * Time.deltaTime * verticalSpeed));
        
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, forwardSpeed * Time.deltaTime);
        //rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y,verticalPos * Time.deltaTime * verticalSpeed);

        //rb.AddForce(Vector3.forward * forwardSpeed *Time.deltaTime, ForceMode.Acceleration);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "EnemyObject" && isAlive)
        {
            Death();
        }
    }

    void Death()
    {
        Time.timeScale = 0.5f;
        rb.velocity = Vector3.zero;
        isAlive = false;
        meshRend.enabled = false;
        deathPart.Play();
        partPlaer.Stop();
        
    }
}
