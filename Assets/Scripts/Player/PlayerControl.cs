using UnityEngine;
using System.Collections;
using InControl;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerControl : MonoBehaviour
{
    public float m_speed;

    private Rigidbody2D m_rigidbody;
    private Vector2 m_moveDirection;
    private PlayerActions m_playerActions;
	private GameObject m_bulletRef;

	public void SetBulletRef(GameObject bulletRef)
	{
		m_bulletRef = bulletRef;
	}

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

		if(m_playerActions.Shoot.IsPressed)
		{
			TryShoot();
		}
    }

    private void FixedUpdate()
    {
        m_rigidbody.velocity = m_moveDirection * m_speed * Time.fixedDeltaTime;
    }

	private void TryShoot()
	{
		if(!m_bulletRef.activeInHierarchy)
		{
			m_bulletRef.SetActive(true);
			m_bulletRef.GetComponent<Bullet>().Reset(transform.position);
		}
	}

}
