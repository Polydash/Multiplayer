using UnityEngine;
using System.Collections;
using InControl;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControl : MonoBehaviour
{
    public float m_speed;
    public float m_shootInterval;

    private Rigidbody2D m_rigidbody;
    private Vector2 m_moveDirection;
    private PlayerActions m_playerActions;
    private float m_lastShoot;

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
        float shootElapsed = Time.time - m_lastShoot;

		if(m_playerActions.Shoot.IsPressed && shootElapsed > m_shootInterval)
		{
            GetComponent<PlayerNetwork>().CmdShootBullet();
            m_lastShoot = Time.time;
		}
    }

    private void FixedUpdate()
    {
        m_rigidbody.velocity = m_moveDirection * m_speed * Time.fixedDeltaTime;
    }
}
