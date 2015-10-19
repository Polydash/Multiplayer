﻿using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody2D))]
public class Bullet : MonoBehaviour
{
	public float m_speed;

	private Vector3 m_direction;
	private Rigidbody2D m_rigidbody;

	public void Reset(Vector3 spawnPosition)
	{
		transform.position = spawnPosition;
		m_direction = Vector3.right;
	}

	private void Awake()
	{
		m_rigidbody = GetComponent<Rigidbody2D>();
	}

	private void FixedUpdate()
	{
		m_rigidbody.velocity = m_direction * m_speed * Time.fixedDeltaTime;
	}

	private void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log("Bullet Collision");
		gameObject.SetActive(false);
	}
}