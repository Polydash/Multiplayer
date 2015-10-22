using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerMovement : NetworkBehaviour 
{

    private PlayerActions m_playerActions;
    private float m_MovementInput;              // The current value of the movement input.

    private Vector2 m_moveDirection;
    public float m_speed = 100.0f;
    private Rigidbody2D m_rigidbody;

    private void OnEnable()
    {
        m_playerActions = PlayerActions.Create();
    }

    private void OnDisable()
    {
        m_playerActions.Destroy();
    }

	// Use this for initialization
	void Start () {
        m_rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () 
    {
        if (!isLocalPlayer)
            return;

        m_moveDirection = m_playerActions.Move.Value;

	}

    void FixedUpdate()
    {
        if (!isLocalPlayer)
            return;

        m_rigidbody.MovePosition(m_rigidbody.position + (m_moveDirection * m_speed * Time.fixedDeltaTime));
    }
}
