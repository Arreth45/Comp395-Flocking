using UnityEngine;
using System.Collections;

public class BoidController : MonoBehaviour {
    public float minSpeed = 5;
    public float maxSpeed = 20;
    public int flockSize = 10;
    public GameObject boidPrefab;
    public GameObject boid;

    public Vector3 flockCentre;
    public Vector3 flockSpeed;

    private GameObject[] boids;

	// Use this for initialization
	void Start () {
        boids = new GameObject[flockSize];
        for (int i = 0; i < flockSize; i++)
        {
            Vector3 position = new Vector3(
                Random.value,
                Random.value,
                Random.value
                );

        GameObject boid = Instantiate(boidPrefab, transform.position, transform.rotation) as GameObject;
            boid.transform.parent = transform;
            boid.transform.localPosition = position;
            //boid.GetComponent<BoidFlocking>().SetController(gameObject);
            boids[i] = boid;
        }

    }
	
	// Update is called once per frame
	void Update () {

        Vector3 theCentre = Vector3.zero;
        Vector3 theVelocity = Vector3.zero;

        foreach (GameObject boid in boids) {
            theCentre = theCentre + boid.transform.localPosition;
            //theVelocity = theVelocity + boid.GetComponent<Rigidbody2D>().velocity;
        }

        flockCentre = theCentre / flockSize;
        //flockSpeed = theVelocity / flockSpeed;

	
	}
}
