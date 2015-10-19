using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetwork : NetworkBehaviour
{
	public  GameObject m_bulletPrefab;
  	private GameObject m_bulletRef;

	private void Start()
    {
		AuthoritySetup();
	}

	private void AuthoritySetup()
	{
		if(isLocalPlayer)
        {			
			m_bulletRef = Instantiate<GameObject>(m_bulletPrefab);
			NetworkServer.Spawn(m_bulletRef);
			m_bulletRef.SetActive(false);
 
			PlayerControl playerControl = GetComponent<PlayerControl>();
			playerControl.enabled = true;
			playerControl.SetBulletRef(m_bulletRef);
        }
	}
}
