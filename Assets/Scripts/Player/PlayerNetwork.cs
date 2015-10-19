using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetwork : NetworkBehaviour
{
	public GameObject m_bulletPrefab;

    [Command]
    public void CmdShootBullet(Vector2 aimDirection)
    {
        Vector3 position = transform.position + new Vector3(aimDirection.x, aimDirection.y, 0.0f) * 0.5f;
        GameObject bulletRef = Instantiate(m_bulletPrefab, position, Quaternion.identity) as GameObject;
        NetworkServer.Spawn(bulletRef);
        Destroy(bulletRef, 2.0f);
        bulletRef.GetComponent<Bullet>().SetDirection(aimDirection);
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
