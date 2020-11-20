using UnityEngine;

public class RotatorCyl : MonoBehaviour
{
    [SerializeField] float speed;

    void Update()
    {
        transform.localRotation *= Quaternion.Euler(0, speed * Time.deltaTime, 0);
    }
}
