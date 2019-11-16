using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class TimeBody : MonoBehaviour {


    List<PointInTime> pointsInTime;
    public bool rewinding { get; private set; } = false;
    private Rigidbody rb;

    private void Start() {
        rb = GetComponent<Rigidbody>();
        pointsInTime = new List<PointInTime>();
    }

    public void Rewind() {
        if (pointsInTime.Count > 0) {
            PointInTime pointInTime = pointsInTime[0];
            transform.position = pointInTime.pos;
            transform.rotation = pointInTime.rot;
            pointsInTime.RemoveAt(0);
        } else {
            StopRewind();
        }

    }

    public void Record(float maximumReverseTime) {
        if (pointsInTime.Count > Mathf.Round(maximumReverseTime / Time.fixedDeltaTime)) {
            pointsInTime.RemoveAt(pointsInTime.Count - 1);
        }

        pointsInTime.Insert(0, new PointInTime(transform.position, transform.rotation));
    }

    public void StartRewind() {
        rewinding = true;
        rb.isKinematic = true;
    }

    public void StopRewind() {
        rewinding = false;
        rb.isKinematic = false;
    }

}

public struct PointInTime {

    public Vector3 pos;
    public Quaternion rot;

    public PointInTime(Vector3 pos, Quaternion rot) {
        this.pos = pos;
        this.rot = rot;
    }

}