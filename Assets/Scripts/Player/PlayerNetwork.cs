using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayerNetwork : NetworkBehaviour
{
	private void Start()
    {
	    if(isLocalPlayer)
        {
            GetComponent<PlayerMovement>().enabled = true;
        }
	}
}
