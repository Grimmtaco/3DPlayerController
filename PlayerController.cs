using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Quaternion targetRotation;
    private float speed = 3f;
    public float rotationSpeed = 380f;
    public float accelerate = 2f;
    public Transform spawnPoint;
    public Rigidbody bullet;


    void Start()
    {

    }

    void Update()
    {
        float acceleration = 1f;
        if (Input.GetKey(KeyCode.V))
        {
            acceleration = accelerate;
        }

        Vector3 playerInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        if (playerInput != Vector3.zero)
        {
            targetRotation = Quaternion.LookRotation(playerInput);
            transform.eulerAngles = Vector3.up * Mathf.MoveTowardsAngle(transform.eulerAngles.y, targetRotation.eulerAngles.y, rotationSpeed * Time.deltaTime);

            Vector3 playerMotion = Vector3.forward * speed * acceleration;
            transform.Translate(playerMotion * Time.deltaTime); //placing here will cause to stop. outside they will keep moving

        }





        else
        {
            speed = 5f;
        }
        if (Input.GetButtonDown("Fire1"))
        {
            Debug.Log("fire button pressed");
            Rigidbody instantiateBullet = Instantiate(bullet, spawnPoint.position, spawnPoint.rotation);
            instantiateBullet.velocity = spawnPoint.TransformDirection(new Vector3(0, 0, speed * 3f));
        }

    }
}