using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaddleDriverScript : MonoBehaviour {

    public float hitPower = 1000f;
    public float paddleDamper = 10f;
    public float upPosition = 45f;
    public float downPosition = 0f;

    public HingeJoint hinge;
    public string inputName;

	// Use this for initialization
	void Start () {
        hinge = GetComponent<HingeJoint>();
        hinge.useSpring = true;
		
	}
	
	// Update is called once per frame
	void Update () {
        JointSpring spring = new JointSpring
        {
            spring = hitPower,
            damper = paddleDamper
        };
        spring.targetPosition =Input.GetKey(KeyCode.Space) ? upPosition : downPosition;
        hinge.spring = spring;
        hinge.useLimits = true;	
	}
}
