using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : NetworkBehaviour
{
    private Rigidbody2D m_rigidbody;
    private Vector2 m_aimDirection;

    public void Shoot(Vector2 spawnPos, Vector2 aimDirection)
    {
        m_aimDirection = aimDirection;
        m_rigidbody.position = spawnPos + 0.5f * m_aimDirection;
        m_rigidbody.velocity = m_aimDirection * 5.0f;
    }

    private void Awake()
    {
        m_rigidbody = GetComponent<Rigidbody2D>();
    }

    public override void OnStartAuthority()
    {
        PlayerControl playerControl = ClientScene.readyConnection.playerControllers[0].gameObject.GetComponent<PlayerControl>();
        playerControl.SetBulletRef(this);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(hasAuthority && collision.collider.tag == "Wall")
        {
            m_aimDirection = Vector2.Reflect(m_aimDirection, collision.contacts[0].normal);
            m_rigidbody.velocity = m_aimDirection * 5.0f;
        }
    }
}
