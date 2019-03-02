using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FossilController : MonoBehaviour
{

    public void CreateFossilPiece(GameObject gameObj){
        gameObj.transform.SetParent(null, true);
        gameObj.AddComponent<Rigidbody>();
    }

    ContactPoint[] contacts = new ContactPoint[128];
    int contactLength;

    public void OnCollisionEnter(Collision collision) {
        contactLength = collision.GetContacts(contacts);

        // Get all unique colliders
        List<Collider> uniqueColliders = new List<Collider>();
        Collider col;
        for (var i = 0; i < contactLength; i++) {
            col = contacts[i].thisCollider;
            if (!uniqueColliders.Contains(col)) {
                uniqueColliders.Add(col);
            }
        }
        Debug.LogFormat("Count: {0}", uniqueColliders.Count);

        // Apply integrity updates
        var force = (collision.impulse / Time.fixedDeltaTime).magnitude;    // Get total force
        foreach(var uCol in uniqueColliders){
            uCol.GetComponent<FossilPiece>().ApplyIntegrityUpdate(-force);
        }
    }

}
