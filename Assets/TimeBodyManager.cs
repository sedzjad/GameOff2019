using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;

public class TimeBodyManager : MonoBehaviour {

    private List<TimeBody> timeBodies;
    [SerializeField] private KeyCode timeReverseKey;
    [SerializeField] private float maximumReverseTime;

    private void Start() {
        timeBodies = new List<TimeBody>(FindObjectsOfType<TimeBody>());
    }

    private void Update() {
        foreach (TimeBody timeBody in timeBodies) {
            if (Input.GetKeyDown(timeReverseKey)) {
                timeBody.StartRewind();
            } else if (Input.GetKeyUp(timeReverseKey)) {
                timeBody.StopRewind();
            }
        }
            
    }

    private void FixedUpdate() {
        foreach(TimeBody timeBody in timeBodies) {
            if(timeBody.rewinding) {
                timeBody.Rewind();
            } else {
                timeBody.Record(maximumReverseTime);
            }
        }
    }

}
