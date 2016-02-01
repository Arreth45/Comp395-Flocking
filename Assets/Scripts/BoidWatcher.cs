using UnityEngine;
using System.Collections;

public class BoidWatcher : MonoBehaviour {

    public Transform boidContoller;

    void LateUpdate()
    {
        if (boidContoller)
        {
            Vector3 watchpoint = boidContoller.GetComponent<BoidController>().flockCentre;
            transform.LookAt(watchpoint + boidContoller.transform.position);
        }
    }
}
