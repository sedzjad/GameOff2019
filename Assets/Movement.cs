using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Movement : MonoBehaviour {

    public float torque = 20f;

    private Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        rb.maxAngularVelocity = 5;
    }

    private void Update() {
        if(Input.GetKey(KeyCode.W)) {
            rb.AddTorque(transform.TransformDirection(Vector3.right) * torque);
        }

        var horizontal = Input.GetAxis("Horizontal");

        if (horizontal != 0) {
            rb.MoveRotation(Quaternion.Euler(Vector3.up * horizontal * 3 + rb.rotation.eulerAngles));
        }
    }

}
