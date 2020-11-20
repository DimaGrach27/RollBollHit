using UnityEngine;

public class TrapMove : MonoBehaviour
{
    bool move;

    private void Start()
    {
        move = false;
    }
    private void Update()
    {
        if(move)
            transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, transform.position.y, transform.position.z - 15f), 1.5f * Time.deltaTime);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
            move = true;
    }
}
