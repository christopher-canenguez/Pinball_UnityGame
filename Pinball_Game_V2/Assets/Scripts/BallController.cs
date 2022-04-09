using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public GameObject ball;

    private void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.CompareTag("Bumper"))
        {
            GameManager.Instance.score += 20;
        }
        if (col.gameObject.CompareTag("Edge"))
        {
            GameManager.Instance.score += 10;
        }
    }
}
