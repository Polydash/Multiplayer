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
    private Vector2 m_aimDirection;
    private PlayerActions m_playerActions;
    private PlayerNetwork m_playerNetwork;
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
        m_playerNetwork = GetComponent<PlayerNetwork>();
        m_aimDirection = Vector2.right;
    }

    private void Update()
    {
        m_moveDirection = m_playerActions.Move.Value;
        
        if(m_playerActions.Aim.Value.SqrMagnitude() > 0.3f)
        {
            m_aimDirection = m_playerActions.Aim.Value;
            m_aimDirection.Normalize();
        }

        float shootElapsed = Time.time - m_lastShoot;
		if(m_playerActions.Shoot.IsPressed && shootElapsed > m_shootInterval)
		{
            m_playerNetwork.CmdShootBullet(m_aimDirection);
            m_lastShoot = Time.time;
		}

        float angle = Mathf.Acos(Vector2.Dot(Vector2.right, m_aimDirection)) / (2.0f*Mathf.PI) * 360.0f;
        float sign = Vector2.Dot(Vector2.up, m_aimDirection);
        sign = (sign > 0) ? 1 : -1;
        m_rigidbody.rotation = sign * angle;
    }

    private void FixedUpdate()
    {
        m_rigidbody.velocity = m_moveDirection * m_speed * Time.fixedDeltaTime;
    }
}
