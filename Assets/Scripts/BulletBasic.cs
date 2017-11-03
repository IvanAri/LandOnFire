using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class BulletBasic : MonoBehaviour {

    public NetworkInstanceId bullet_id;

    //Check what bullet does on collision with player
	void OnCollisionEnter(Collision coll)
    {
        
        var hit = coll.gameObject;
        var hitPlayer = hit.GetComponent<Combat>();
        NetworkInstanceId hit_netid = hit.GetComponent<NetworkIdentity>().netId;
        if (hitPlayer != null && hit_netid!=bullet_id)
        {
            var combat = hit.GetComponent<Combat>();
            combat.TakeDamage(25);

            Destroy(gameObject);
        }
        
    }
	
}
