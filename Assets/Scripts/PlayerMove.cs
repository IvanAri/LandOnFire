using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class PlayerMove : NetworkBehaviour {

	// Use this for initialization
	void Start () {
	}

	public GameObject bulletPrefab;

	// Good place to make initialization for local players
	public override void OnStartLocalPlayer()
	{
		GetComponent<MeshRenderer> ().material.color = Color.cyan;
	}

	// Update is called once per frame
	void Update () {
		if (!isLocalPlayer)
			return;

		var x = Input.GetAxis ("Horizontal") * 0.1f;
		var z = Input.GetAxis ("Vertical") * 0.1f;

		transform.Translate (x, 0, z);

		//Fire by pressing SPACE!
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			CmdFire();
		}

	}

	//Function to fire our bullet prefab
	[Command]
	void CmdFire()
	{
		//Creating bullet
		var bullet = (GameObject)Instantiate (
			             bulletPrefab,
			             transform.position - transform.forward,
			             Quaternion.identity);

		//Making bullet to move
		bullet.GetComponent<Rigidbody> ().velocity = -transform.forward * 4;

		NetworkServer.Spawn (bullet);

		//Making bullet to disappear after some time/traveled distance/etc.
		Destroy(bullet, 2.0f);
	}
}
