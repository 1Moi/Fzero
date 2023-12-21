using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCarRotation : MonoBehaviour
{
    private Rigidbody rb;
    public float speed = 10f;
    //private float rotationSpeed = 100f;

    private bool isMoving = false;
    public bool isTurningRight = false;
    public bool isTurningLeft = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        //if space is pressed, set isMoving to true
        if (Input.GetKey(KeyCode.Space))
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

        //if "A" is pressed, set isTurningLeft to true
        if (Input.GetKey(KeyCode.A))
        {
            isTurningLeft = true;
        }
        else
        {
            isTurningLeft = false;
        }

        //if "D" is pressed, set isTurningRight to true
        if (Input.GetKey(KeyCode.D))
        {
            isTurningRight = true;
        }
        else
        {
            isTurningRight = false;
        }
        
    }

    //cast a ray from the middle of the car to the ground
    //if the ray hits something, rotate the car so that it is aligned with the ground
    private void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, -transform.up, out hit, 10f))
        {
            //draw a red line that represents the normal of the surface the raycast hit
            Debug.DrawLine(hit.point, hit.point + hit.normal * 5f, Color.red);

            //draw a green line that represents the local up vector of the car
            Debug.DrawLine(transform.position, transform.position + transform.up * 5f, Color.green);

            //calculate the rotation that would align the car with the ground
            Quaternion targetRotation = Quaternion.FromToRotation(transform.up, hit.normal) * transform.rotation;

            //rotate the car towards the target rotation
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.fixedDeltaTime * 10f);
        }

        //if isMoving is true, move the car forward
        if (isMoving)
        {
            rb.velocity = transform.forward * speed;
        }

        if (isTurningRight)
        {
            //rotate the car to the right
            transform.Rotate(0f, 1f, 0f);

        }

        if (isTurningLeft)
        {
            //rotate the car to the left or right depending if the car is upside down or not
            transform.Rotate(0f, -1f, 0f);

        }

        //Physics.gravity = new Vector3(0, -1.0F, 0);
        //set the gravity to be the opposite of the normal of the surface the car is on
        Physics.gravity = -hit.normal * 9.81f * 3f;

    }
}
