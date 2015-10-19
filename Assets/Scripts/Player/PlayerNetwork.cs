using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetwork : NetworkBehaviour
{
	public GameObject m_bulletPrefab;

    [Command]
    public void CmdShootBullet()
    {
        GameObject bulletRef = Instantiate(m_bulletPrefab, transform.position, Quaternion.identity) as GameObject;
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
