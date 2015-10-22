using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : NetworkBehaviour
{
	public float m_speed;

	private Vector3 m_direction;
	private Rigidbody2D m_rigidbody;

    //public void SetDirection(Vector3 direction)
    //{
    //    m_direction = direction;
    //}

    //private void Awake()
    //{
    //    m_rigidbody = GetComponent<Rigidbody2D>();
    //}

    //private void FixedUpdate()
    //{
    //    if(isServer)
    //    {
    //        m_rigidbody.velocity = m_direction * m_speed * Time.fixedDeltaTime;
    //    }
    //}

    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if(isServer)
    //    {
    //        Destroy(gameObject);
    //    }
    //}
}
