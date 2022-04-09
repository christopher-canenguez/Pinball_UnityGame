using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DZscript : MonoBehaviour
{

    public GameObject newBall;
 
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.GetComponent<Rigidbody>().CompareTag("Ball"))
        {
            Destroy(collision.gameObject);
            
            Instantiate(newBall);

            GameManager.Instance.ballCount -= 1;

        }
    }
}
