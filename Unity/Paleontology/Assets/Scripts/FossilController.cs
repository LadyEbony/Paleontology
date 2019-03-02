using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FossilController : MonoBehaviour
{

    private Rigidbody _rb;
    public Rigidbody Rb {
        get {
            return _rb ?? (_rb = GetComponent<Rigidbody>());
        }
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

        // Apply integrity updates
        var force = (collision.impulse / Time.fixedDeltaTime).magnitude;    // Get total force
        // var force = (Rb.mass * collision.relativeVelocity / Time.fixedDeltaTime).magnitude;  // Wrong
        foreach (var uCol in uniqueColliders){
            uCol.GetComponent<FossilPiece>().ApplyIntegrityUpdate(-force);
        }
    }

}
