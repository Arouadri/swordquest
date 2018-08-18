using UnityEngine;
using System.Collections;

public class GeneradorV2 : MonoBehaviour
{

    public GameObject[] obj;
    // Use this for initialization
    void Start()
    {
        Instantiate(obj[Random.Range(0, obj.Length)], transform.position, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {

    }

}
