﻿using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetwork : NetworkBehaviour
{
	public GameObject m_bulletPrefab;

    [Command]
    public void CmdInstantiateBullet()
    {
        GameObject bulletRef = Instantiate(m_bulletPrefab, Vector3.zero, Quaternion.identity) as GameObject;
        NetworkServer.SpawnWithClientAuthority(bulletRef, connectionToClient);
    }

    [Command]
    public void CmdShootBullet(Vector2 aimDirection)
    {
        Vector3 position = transform.position + new Vector3(aimDirection.x, aimDirection.y, 0.0f) * 0.5f;
        GameObject bulletRef = Instantiate(m_bulletPrefab, position, Quaternion.identity) as GameObject;
        bulletRef.GetComponent<Rigidbody2D>().velocity = aimDirection * Time.deltaTime * 350.0f;
        NetworkServer.Spawn(bulletRef);
        Destroy(bulletRef, 2.0f);
    }

	private void Start()
    {
		AuthoritySetup();
	}

	private void AuthoritySetup()
	{
		if(isLocalPlayer)
        {
            PlayerControl playerControl = GetComponent<PlayerControl>();
			playerControl.enabled = true;
        }
	}
}
