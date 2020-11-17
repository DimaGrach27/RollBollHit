﻿using UnityEngine;

public class PartTarget : MonoBehaviour
{
    [SerializeField] Transform target;


    void Update()
    {
        transform.position = new Vector3(target.position.x, transform.position.y, target.position.z);
    }
}