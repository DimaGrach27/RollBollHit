using UnityEngine;

public class SphereMoveble : MonoBehaviour
{
    private Rigidbody rb;

    [SerializeField] float forwardSpeed = 10f;
    [SerializeField] float horizSpeed = 2f;
    [SerializeField] float verticalSpeed = 2f;

    [SerializeField] LayerMask ground;

    [SerializeField] ParticleSystem deathPart;
    ParticleSystem partPlaer;

    public MeshRenderer meshRend;

    public static bool isAlive;

    [Range (0,200)]
    public float dragSpeed;

    [Range(0, 10)]
    public float range;

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
        //Debug.Log($"Vector drag = { new Vector2(SwipeHeandler.xSpeed, SwipeHeandler.ySpeed)}");
        Debug.Log($"TransformLOcalPos = {transform.localPosition}");
    }


    /* void Move()
     {
        //rb.velocity = Vector3.MoveTowards(rb.velocity, new Vector3(, rb.velocity.y, rb.velocity.z), dragSpeed * Time.deltaTime);

        //if (SwipeHeandler.ySpeed != 0)

        Vector3 Pose = new Vector3(SwipeHeandler.xSpeed, 0, SwipeHeandler.ySpeed);

        if(SwipeHeandler.xSpeed != 0 || SwipeHeandler.ySpeed != 0)
        {
            rb.AddForce(Pose * Time.fixedDeltaTime * 30, ForceMode.VelocityChange);
        }
        else

         //transform.position = Vector3.MoveTowards(transform.position, new Vector3(
         //    transform.position.x + SwipeHeandler.xSpeed, 
         //    transform.position.y, 
         //    transform.position.z + SwipeHeandler.ySpeed), dragSpeed * Time.deltaTime);

         rb.velocity = new Vector3(0, 0, forwardSpeed * Time.deltaTime);

     }*/

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

                //posToch = new Vector3(
                //   transform.position.x + touch.deltaPosition.x,
                //   transform.position.y,
                //   transform.position.z + touch.deltaPosition.y);
            }
            else if (touch.phase == TouchPhase.Stationary)
            {
                tochPos = Vector3.zero;

                //posToch = new Vector3(
                //    transform.position.x,
                //    transform.position.y,
                //    transform.position.z);
            }
            else if (touch.phase == TouchPhase.Ended)
            {
                tochPos = new Vector3(touch.deltaPosition.x, 0, touch.deltaPosition.y);

                //posToch = new Vector3(
                //    transform.position.x + touch.deltaPosition.x,
                //    transform.position.y,
                //    transform.position.z + touch.deltaPosition.y);
            }
            rb.AddForce(tochPos, ForceMode.VelocityChange);
           // rb.MovePosition(transform.position + tochPos * Time.fixedDeltaTime);
            //transform.position = Vector3.Lerp(transform.position, posToch, dragSpeed * Time.fixedDeltaTime); // dragSpeed = 0.91
        } 
        //else
        //{
        //    rb.velocity = Vector3.Lerp(rb.velocity, new Vector3(0f, 0f, forwardSpeed * Time.deltaTime), 1f);
        //}
    }

    /*void Move()
    {
        Vector3 startPos = Vector3.zero, currentPos = Vector3.zero;

        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            //if(touch.phase == TouchPhase.Began)
            //{
            //    touchStartPos = touch.position;
            //}
            //else if (touch.phase == TouchPhase.Moved || touch.phase == TouchPhase.Ended)
            //{
            //    touchEndPos = touch.position;
            //}

            //float x = touchEndPos.x - touchStartPos.x;
            //float y = touchEndPos.y - touchStartPos.y;

            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(x, transform.position.y, y), dragSpeed * Time.deltaTime);

            Ray ray = Camera.main.ScreenPointToRay(touch.position);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(hit.point.x, transform.position.y, hit.point.z), dragSpeed * Time.deltaTime);
            }
        }
        else if (Input.GetButton("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100, ground))
            {
                startPos = hit.point;
                transform.position = Vector3.MoveTowards(transform.position, new Vector3(hit.point.x, transform.position.y, hit.point.z), dragSpeed * Time.deltaTime);
            }
            //currentPos = Input.mousePosition - startPos;
            //transform.position = Vector3.MoveTowards(transform.position, new Vector3(currentPos.x, transform.position.y, currentPos.z), dragSpeed * Time.deltaTime);
        }
        

        rb.velocity = new Vector3(0, rb.velocity.y, forwardSpeed * Time.deltaTime);
    }*/

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "EnemyObject" && isAlive)
            Death(); 
    }

    public void Death()
    {
        Time.timeScale = 0.5f;
        rb.velocity = Vector3.zero;
        isAlive = false;
        meshRend.enabled = false;
        deathPart.Play();
        partPlaer.Stop();
        
    }
}
