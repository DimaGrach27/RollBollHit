using UnityEngine;
using UnityEngine.EventSystems;

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

    [Range(0, 5f)]
    public float range;

    [Range(0, 3)]
    public float drawRange;

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
        rb.velocity = new Vector3(0f, 0f, forwardSpeed * Time.deltaTime);

        if(Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 posToch;

            if (touch.phase == TouchPhase.Moved)
            {
                 posToch = new Vector3(
                    transform.position.x + touch.deltaPosition.x * range,
                    transform.position.y,
                    transform.position.z + touch.deltaPosition.y * range);

                transform.position = Vector3.Lerp(transform.position, posToch, 0.25f * Time.fixedDeltaTime);
                Debug.Log($"posToch = {posToch}");
            }
        }      
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
