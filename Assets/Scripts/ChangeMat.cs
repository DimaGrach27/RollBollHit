using UnityEngine;

public class ChangeMat : MonoBehaviour
{
    [SerializeField] Material red;
    [SerializeField] Material blue;

    GameObject[] obj;
    GameObject[] enemy;

    private void Start()
    {
        obj = GameObject.FindGameObjectsWithTag("Object");
        enemy = GameObject.FindGameObjectsWithTag("EnemyObject");
    }

    private void Update()
    {
        for (int i = 0; i < obj.Length; i++)
        {
            if(obj[i].transform.position.z < Camera.main.transform.position.z)
                obj[i].SetActive(false);
            else
                obj[i].SetActive(true);
        }
        for (int i = 0; i < enemy.Length; i++)
        {
            if (enemy[i].transform.position.z < Camera.main.transform.position.z)
                enemy[i].SetActive(false);
            else
                enemy[i].SetActive(true);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.gameObject.GetComponent<SphereMoveble>();

        if (player)
        {
            player.meshRend.material = red;
            player.GetComponent<TrailRenderer>().material = red;

            for (int i = 0; i < obj.Length; i++)
            {
                obj[i].tag = "EnemyObject";
            }
            for (int i = 0; i < enemy.Length; i++)
            {
                enemy[i].tag = "Object";
            }
        }
        if(other.gameObject.tag == "Object" || other.gameObject.tag == "EnemyObject")
        {
            other.gameObject.GetComponent<MeshRenderer>().material = red;
            other.gameObject.tag = "Object";
        }
    }
}
