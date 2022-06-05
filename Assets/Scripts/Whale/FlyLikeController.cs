using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class FlyLikeController : MonoBehaviour
{
    [SerializeField] private InputActionReference m_moveAction;
    [SerializeField] private InputActionReference m_boostAction;
    [SerializeField] private float m_constantSpeed = 50f;
    [SerializeField] private float m_boostSpeed = 150f;
    [SerializeField] private float m_boostDuration = 2f;
    [SerializeField] private float m_endBoostDuration = 1f;
    [SerializeField] private float m_yaw = 25f;
    [SerializeField] private float m_pitch = 25f;

    private Rigidbody rb;
    private Vector2 moveValue;
    private float speed;
    private float endBoostTime;
    private bool boosting;

    public Vector2 MoveValue { get => moveValue; }
    public bool Boosting { get => boosting; }

    //Bordel Rubens

    [SerializeField] float TimeRotationAtSurface = 1;
    bool ShouldTurn = false;

    float InitialRotation;
    float InitialTime;
    float LerpRotation;
    [SerializeField] float MaxHeight;
    [SerializeField] float MinHeight;

    [Header ("Audio")]
    [SerializeField] AudioClip[] _splashesClips;
    [SerializeField] AudioClip[] _dashClips;


    private void Awake()
    {
        speed = m_constantSpeed;
        rb = GetComponent<Rigidbody>();
        m_moveAction.action.performed += OnMovePerformed;
        m_moveAction.action.canceled += OnMoveCanceled;
        m_boostAction.action.performed += OnBoostPerformed;
    }

    private void OnBoostPerformed(InputAction.CallbackContext obj)
    {
        if (boosting) return;
        StartCoroutine(BoostingCoroutine());
    }

    private IEnumerator BoostingCoroutine()
    {
        boosting = true;
        speed = m_boostSpeed;
        yield return new WaitForSeconds(m_boostDuration);

        endBoostTime = m_endBoostDuration;

        while (endBoostTime >= 0f)
        {
            speed = Mathf.Lerp(speed, m_constantSpeed, (m_boostSpeed - m_constantSpeed) * Time.deltaTime / m_endBoostDuration);
            yield return null;
            endBoostTime -= Time.deltaTime;
        }
        boosting = false;
    }

    private void OnMoveCanceled(InputAction.CallbackContext obj)
    {
        moveValue = Vector2.zero;
    }

    private void OnMovePerformed(InputAction.CallbackContext obj)
    {
        moveValue = obj.ReadValue<Vector2>();
    }

    private void FixedUpdate()
    {
        rb.velocity = transform.forward * speed;
        float fixedDeltaTime = Time.fixedDeltaTime;

        //LIGNE DEGUEU
        if (transform.position.y >= 59.5 && !ShouldTurn)
        {
            
            ResetRotation();
        }
        //LIGNE DEGUEU fin

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, MinHeight, MaxHeight), transform.position.z);
        
        if (ShouldTurn)
        {

            LerpRotation = Mathf.InverseLerp(InitialTime, (InitialTime + TimeRotationAtSurface), Time.time);


            transform.eulerAngles = new Vector3 (Mathf.LerpAngle(InitialRotation, 30, LerpRotation), transform.eulerAngles.y, transform.eulerAngles.z);

            if (Time.time >= InitialTime + TimeRotationAtSurface)
            {
                ShouldTurn = false;
            }

        }
        else
        {
            transform.rotation = Quaternion.AngleAxis(moveValue.y * m_yaw * fixedDeltaTime, transform.right)
            * Quaternion.AngleAxis(moveValue.x * m_pitch * fixedDeltaTime, transform.up) * transform.rotation;
        }

        transform.eulerAngles = new Vector3 (transform.eulerAngles.x, transform.eulerAngles.y, 0);
    }


    public void ResetRotation()
    {
        ShouldTurn = true;
        InitialRotation = transform.eulerAngles.x;
        InitialTime = Time.time;

        StartCoroutine(PlaySoundDelayed( TimeRotationAtSurface / 2.0f));
    }

    IEnumerator PlaySoundDelayed(float delay){
        
        yield return new WaitForSeconds(delay);
        AudioClipPlayer.PlaySoundRandomFromArray(_splashesClips);
        yield return null;
    }

}
