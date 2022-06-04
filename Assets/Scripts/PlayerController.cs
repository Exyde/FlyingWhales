using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : Entity
{
    [Header("Game Objects References")]


    [Header("Speeds")]
    [Range(0, 200)] public float _forwardForce = 6f;
    [Range(0, 200)] public float _moveForce = 6f;


    [Range (0, 200)] public float _minSpeed;
    [Range (0, 200)] public float _maxSpeed;

    [Range(0, 100)] public float _dashForce = 6f;
    [Range(20, 100)] public float _torqueForce = 6f;
    [Range(20, 100)] public float _turnForce = 6f;

    private Rigidbody rb;
    private Vector3 _inputs;

    private void Awake() {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * _moveForce;
    }

    void FixedUpdate()
    {
        Move();
    }

    void Move() {
        
        // HandleDash();

        // rb.velocity = transform.forward * _forwardForce;
        HandleMovement();


        rb.AddForce(transform.forward * _forwardForce * Time.deltaTime);
        float maxVelZ = Mathf.Clamp (rb.velocity.z, _minSpeed, _maxSpeed);
        rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, maxVelZ);

    }

    void HandleMovement()
    {

        rb.AddForce(_inputs * Time.deltaTime * _moveForce);
        Debug.Log(rb.velocity);

        // //Left & Right Rotation (Barrel Roll)
        // if (Input.GetKey(KeyCode.Q))
        // {
        //     transform.Rotate(Vector3.forward * _torqueForce * Time.deltaTime);
        // }

        // if (Input.GetKey(KeyCode.D))
        // {
        //     transform.Rotate(-Vector3.forward * _torqueForce * Time.deltaTime);
        // }

        // //Left & Right Drafting (Direction Switch)
        // if (Input.GetKey(KeyCode.A))
        // {
        //     transform.Rotate(-transform.up * _turnForce * Time.deltaTime);
        // }

        // if (Input.GetKey(KeyCode.E))
        // {
        //     transform.Rotate(transform.up * _turnForce * Time.deltaTime);
        // }

        // //Down & Up Rotation (Plane Joystick)
        // if (Input.GetKey(KeyCode.Z))
        // {
        //     transform.Rotate(Vector3.right * _torqueForce * Time.deltaTime);
        // }

        // if (Input.GetKey(KeyCode.S))
        // {
        //     transform.Rotate(-Vector3.right * _torqueForce * Time.deltaTime);
        // }
    }

     void HandleMovementLegacy()
    {
        //Left & Right Rotation (Barrel Roll)
        if (Input.GetKey(KeyCode.Q))
        {
            transform.Rotate(Vector3.forward * _torqueForce * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * _torqueForce * Time.deltaTime);
        }

        //Left & Right Drafting (Direction Switch)
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(-transform.up * _turnForce * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.E))
        {
            transform.Rotate(transform.up * _turnForce * Time.deltaTime);
        }

        //Down & Up Rotation (Plane Joystick)
        if (Input.GetKey(KeyCode.Z))
        {
            transform.Rotate(Vector3.right * _torqueForce * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(-Vector3.right * _torqueForce * Time.deltaTime);
        }
    }


    public void HandleMoveInputs(Vector2 inputs) => _inputs = new Vector3(inputs.x, inputs.y, 0);

    void HandleDash()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(Dash());
        }
    }

    IEnumerator Dash() {

        print("Dashing");

        yield return new WaitForSeconds(0.7f);
        Time.timeScale = .48f;
        yield return new WaitForSeconds(0.7f);

        //rb.AddForce(transform.forward * _dashForce, ForceMode.Impulse);
        // _dashParticle.Play();
        rb.MovePosition(transform.position + _dashForce * transform.forward);
        ExydeToolbox.CameraShake.Shake(.2f, .6f);
        Time.timeScale = 1f;
        yield return new WaitForSeconds (.5f);

        yield return null;
    }
}