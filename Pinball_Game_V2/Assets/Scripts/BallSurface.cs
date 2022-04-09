using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSurface : MonoBehaviour
{
    public GameObject floor;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = new Vector3(0.1f, 0, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position.Set(0,
            floor.transform.position.y - 0.15f
            , 0);

    }
}
