using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementWhale : MonoBehaviour
{
    public float TimeRotationAtSurface;
    bool ShouldTurn = false;

    float InitialRotation;
    float InitialTime;
    float LerpRotation;
    public float MaxHeight;
    public float MinHeight;


    private void FixedUpdate()
    {
        

        if (ShouldTurn)
        {

            LerpRotation = Mathf.InverseLerp(InitialTime, InitialRotation + TimeRotationAtSurface, Time.time);

            Mathf.LerpAngle(InitialRotation, -10, LerpRotation);

            if(Time.time >= InitialRotation + TimeRotationAtSurface)
            {
                ShouldTurn = false;
            }

        }

        transform.position = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y,MinHeight,MaxHeight), transform.position.z);

    }
    void ResetRotation()
    {
        ShouldTurn = true;
        InitialRotation = transform.eulerAngles.x;
        InitialTime = Time.time;
    }
}
