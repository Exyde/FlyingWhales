using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private FlyLikeController m_character;
    [SerializeField] private Vector3 m_cameraOffset;
    [SerializeField] private float m_offsetSpeedX;
    [SerializeField] private float m_offsetSpeedY;
    [SerializeField] private float m_offsetSpeedZ;

    private Transform parent;
    private Vector3 currentOffsetX;
    private Vector3 currentOffsetY;
    private Vector3 currentOffsetZ;

    private void Awake()
    {
        parent = m_character.transform;
    }

    private void FixedUpdate()
    {
        currentOffsetX = Vector3.Lerp(currentOffsetX, m_character.MoveValue.x * Vector3.right, m_offsetSpeedX * Time.fixedDeltaTime);
        currentOffsetY = Vector3.Lerp(currentOffsetY, m_character.MoveValue.y * Vector3.up, m_offsetSpeedY * Time.fixedDeltaTime);

        currentOffsetZ = Vector3.Lerp(currentOffsetZ, (m_character.Boosting ? -2.5f : 0) * Vector3.forward, m_offsetSpeedZ * Time.fixedDeltaTime);

        transform.localPosition = m_cameraOffset + currentOffsetX + currentOffsetY + currentOffsetZ;
    }
}
