using UnityEngine;
using System.Collections;
using InControl;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float m_speed;

    private Rigidbody2D m_rigidbody;
    private Vector2 m_moveDirection;
    private PlayerActions m_playerActions;

    private void OnEnable()
    {
        m_playerActions = PlayerActions.Create();
    }

    private void OnDisable()
    {
        m_playerActions.Destroy();
    }

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        m_moveDirection = m_playerActions.Move.Value;
    }

    private void FixedUpdate()
    {
        m_rigidbody.velocity = m_moveDirection * m_speed * Time.fixedDeltaTime;
    }
}
