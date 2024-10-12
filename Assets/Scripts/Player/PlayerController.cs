using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private CharacterController m_CharacterController;
    [SerializeField]
    private float m_Speed = 5.0f;
    [SerializeField]
    private float m_JumpHeight = 2.0f; 

    private Vector3 m_PlayerVelocity = Vector3.zero;

    private bool m_IsGrounded;

    private bool m_OnJump = false;

    public void Move(Vector2 movement)
    {
        m_IsGrounded = m_CharacterController.isGrounded;

        if (m_IsGrounded && m_PlayerVelocity.y < 0)
        {
            m_PlayerVelocity.y = 0f;

        }

        // Calcular el movimiento plano XZ
        Vector3 move = new Vector3(movement.x, 0, movement.y);
        move = move * m_Speed;

        // Calculamos la nueva velocidad en Y
        if (m_OnJump &&  m_IsGrounded)
        {
            m_PlayerVelocity.y += Mathf.Sqrt(
                -2f * Physics.gravity.y * m_JumpHeight
            );
            m_OnJump = false;
        }

        m_PlayerVelocity.y += Physics.gravity.y * Time.deltaTime;
        move = new Vector3(
            move.x * Time.deltaTime,
            m_PlayerVelocity.y * Time.deltaTime,
            move.z * Time.deltaTime
        );
        m_CharacterController.Move(move);
    }

    public void Jump()
    {
        m_OnJump = true;
    }
}
