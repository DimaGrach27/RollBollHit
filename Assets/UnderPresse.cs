using UnityEngine;

public class UnderPresse : MonoBehaviour
{
    [SerializeField] bool isPresed;

    Vector3 currentPos;
    Vector3 pressPos;

    private void Start()
    {
        currentPos = transform.position;
        pressPos = new Vector3(currentPos.x, -1.4f, currentPos.z);

        InvokeRepeating("Change", 1f, 2f);
        
    }
    private void Update()
    {
        Pressed();
    }

    void Pressed()
    {
        if (isPresed)
            transform.position = Vector3.Lerp(transform.position, currentPos, 0.5f * Time.deltaTime);
        else
            transform.position = Vector3.Lerp(transform.position, pressPos, 0.5f * Time.deltaTime);
    }

    void Change()
    {
        if (isPresed)
            isPresed = false;
        else
            isPresed = true;
    }
}
