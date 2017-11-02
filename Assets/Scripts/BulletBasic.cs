using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBasic : MonoBehaviour {

    //Check what bullet does on collision with player
	void OnCollisionEnter(Collision coll)
    {
        var hit = coll.gameObject;
        var hitPlayer = hit.GetComponent<Combat>();
        if (hitPlayer != null)
        {
            var combat = hit.GetComponent<Combat>();
            combat.TakeDamage(25);

            Destroy(gameObject);
        }

    }
	
}
