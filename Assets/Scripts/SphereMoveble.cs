using UnityEngine;

public class SphereMoveble : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] float forwardSpeed = 10f;

    [SerializeField] LayerMask ground;

    [SerializeField] ParticleSystem deathPart;
    ParticleSystem partPlaer;

    public MeshRenderer meshRend;

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

#if UNITY_ANDROID
    void Move()
    {
        rb.velocity = new Vector3(0f, 0f, forwardSpeed * Time.deltaTime);

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 posToch = Vector3.zero;

            Vector3 tochPos = Vector3.zero;

            if (touch.phase == TouchPhase.Began)
            {
                tochPos = Vector3.zero;

                posToch = new Vector3(
                    transform.position.x,
                    transform.position.y,
                    transform.position.z);
            }
            else if (touch.phase == TouchPhase.Moved)
            {
                tochPos = new Vector3(touch.deltaPosition.x, 0, touch.deltaPosition.y);
            }
            else if (touch.phase == TouchPhase.Stationary)
            {
                tochPos = Vector3.zero;
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                tochPos = new Vector3(touch.deltaPosition.x, 0, touch.deltaPosition.y);
            }
            rb.AddForce(tochPos, ForceMode.VelocityChange);
        } 
    }
#endif
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "EnemyObject" && isAlive)
            Death(); 
    }

    public void Death()
    {
        isAlive = false;
        Time.timeScale = 0.5f;
        rb.velocity = Vector3.zero;
        meshRend.enabled = false;
        deathPart.Play();
        partPlaer.Stop();
    }
}
