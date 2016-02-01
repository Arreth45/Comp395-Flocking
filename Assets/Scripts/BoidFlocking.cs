using UnityEngine;
using System.Collections;

public class BoidFlocking : MonoBehaviour {

    private GameObject Controller;
    private bool inited = false;
    private float minVelocity;
    private float maxVelocity;
    private float randomness;
    private GameObject chasee;

	// Use this for initialization
	void Start () {

        StartCoroutine("BoidSteering");
	
	}

    IEnumerator BoidSteering()
    {
        while (true)
        {
            if (inited)
            {
                GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity + Calc() * Time.deltaTime;

                // enforce minimum and maximum speeds for the boids
                float speed = GetComponent<Rigidbody>().velocity.magnitude;
                if (speed > maxVelocity)
                {
                    GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * maxVelocity;
                }
                else if (speed < minVelocity)
                {
                    GetComponent<Rigidbody>().velocity = GetComponent<Rigidbody>().velocity.normalized * minVelocity;
                }
            }
        }
    }
    private Vector3 Calc()
    {
        Vector3 randomize = new Vector3((Random.value * 2) - 1, (Random.value * 2) - 1, (Random.value * 2) - 1);

        randomize.Normalize();
        BoidController boidController = Controller.GetComponent<BoidController>();
        Vector3 flockCenter = boidController.flockCentre;
        Vector3 flockVelocity = boidController.flockSpeed;
        Vector3 follow = chasee.transform.localPosition;

        flockCenter = flockCenter - transform.localPosition;
        flockVelocity = flockVelocity - GetComponent<Rigidbody>().velocity;
        follow = follow - transform.localPosition;

        return (flockCenter + flockVelocity + follow * 2 + randomize * randomness);
    }

    public void SetController(GameObject theController)
    {
        Controller = theController;
        BoidController boidController = Controller.GetComponent<BoidController>();
        minVelocity = boidController.minSpeed;
        maxVelocity = boidController.maxSpeed;
        randomness = boidController.randomness;
        chasee = boidController.chasee;
        inited = true;
    }
}
