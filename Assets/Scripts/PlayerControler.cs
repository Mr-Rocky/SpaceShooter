using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Boundry
{
    public float xMin, xMax, zMin, zMax;
}

public class PlayerControler : MonoBehaviour {

    public Rigidbody rigidBody;
    public float speed;
    public float tilt;
    public Boundry boundry;
    public GameObject shot;
    public Transform shotSpawn;
    public float fireRate;
    public AudioSource fireSound;
    public SimpleTouchPad touchPad;
    public SimpleTouchAreaButton areaButton;

    private float nextFire;
    private Quaternion calibrationQuaternion;

    void Start ()
    {
        nextFire = 0.0f;
        CalibrateAccellerometer();
    }

    void Update ()
    {
        if (areaButton.CanFire() && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;
            Instantiate(shot, shotSpawn.position, shotSpawn.rotation);
            fireSound.Play();
        }
    }

	void FixedUpdate ()
    {
        //float moveHorizontal = Input.GetAxis("Horizontal");
        //float moveVertical = Input.GetAxis("Vertical");

        //Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        //Vector3 accelerationRaw = Input.acceleration;
        //Vector3 acceleration = FixAccelleration(accelerationRaw);
        //Vector3 movement = new Vector3(acceleration.x, 0.0f, acceleration.y);

        Vector2 direction = touchPad.GetDirection();
        Vector3 movement = new Vector3(direction.x, 0.0f, direction.y);
        rigidBody.velocity = movement * speed;

        rigidBody.position = new Vector3(Mathf.Clamp(rigidBody.position.x, boundry.xMin, boundry.xMax), 0.0f, Mathf.Clamp(rigidBody.position.z, boundry.zMin, boundry.zMax));

        rigidBody.rotation = Quaternion.Euler(0.0f, 0.0f, rigidBody.velocity.x * -tilt);
    }

    void CalibrateAccellerometer()
    {
        Vector3 accelerationSnapshot = Input.acceleration;
        Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0.0f, 0.0f, -1.0f), accelerationSnapshot);
        calibrationQuaternion = Quaternion.Inverse(rotateQuaternion);
    }

    Vector3 FixAccelleration(Vector3 acceleration)
    {
        Vector3 fixedAcceleration = calibrationQuaternion * acceleration;
        return fixedAcceleration;
    }

}
