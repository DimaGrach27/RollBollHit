using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCyl : MonoBehaviour
{
    [SerializeField] bool isPresed;

    Vector3 currentPos;
    Vector3 movePos;

    private void Start()
    {
        currentPos = new Vector3(4.1f, transform.position.y, transform.position.z); ;
        movePos = new Vector3(-4.1f, transform.position.y, transform.position.z);

    }
    private void Update()
    {
        Pressed();
        Change();
    }

    void Pressed()
    {
        if (!isPresed)
            transform.position = Vector3.MoveTowards(transform.position, currentPos, 3.3f * Time.deltaTime);
        else
            transform.position = Vector3.MoveTowards(transform.position, movePos, 3.3f * Time.deltaTime);
    }

    void Change()
    {
        if (transform.position.x <= -4f)
            isPresed = false;
        else if( transform.position.x >= 4f)
            isPresed = true;
    }
}
