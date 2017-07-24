using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvasiveManeuver : MonoBehaviour {

    
    public float dodge;
    public float smoothing;
    public float tilt;
    public Vector2 startWait;
    public Vector2 maneuverTime;
    public Vector2 maneuverWait;
    public Boundry boundry;
    [HideInInspector]
    public float currentSpeed;

    private Rigidbody rigidBody;
    private float targetManeuver;
    
	void Start () {
        rigidBody = GetComponent<Rigidbody>();
        currentSpeed = rigidBody.velocity.z;
        StartCoroutine(Evade());
	}
	
	void FixedUpdate () {
        float newManeuver = Mathf.MoveTowards(rigidBody.velocity.x, targetManeuver, Time.deltaTime * smoothing);
        rigidBody.velocity = new Vector3(newManeuver, 0.0f, currentSpeed);
        rigidBody.position = new Vector3(Mathf.Clamp(rigidBody.position.x, boundry.xMin, boundry.xMax), 0.0f, Mathf.Clamp(rigidBody.position.z, boundry.zMin, boundry.zMax));
        rigidBody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidBody.velocity.x * -tilt);
    }

    IEnumerator Evade ()
    {
        yield return new WaitForSeconds(Random.Range(startWait.x, startWait.y));

        while (true)
        {
            if (transform.position.x == 0)
                targetManeuver = Random.Range(1, dodge) * (Random.value > 0.5 ? 1 : -1);
            else
                targetManeuver = Random.Range(1, dodge) * -Mathf.Sign(transform.position.x);
            yield return new WaitForSeconds(Random.Range(maneuverTime.x, maneuverTime.y));
            targetManeuver = 0.0f;
            yield return new WaitForSeconds(Random.Range(maneuverWait.x, maneuverWait.y));
        }
    }
}
