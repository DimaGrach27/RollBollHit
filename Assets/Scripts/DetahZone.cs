using UnityEngine;

public class DetahZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<SphereMoveble>();

        if (player)
            player.Death();

    }
}
