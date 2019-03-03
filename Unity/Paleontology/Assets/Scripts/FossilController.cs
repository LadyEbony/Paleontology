using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using System.Linq;

public class FossilController : MonoBehaviour
{

    private Rigidbody _rb;
    public Rigidbody Rb {
        get {
            return _rb ?? (_rb = GetComponent<Rigidbody>());
        }
    }

    private List<FossilPiece> _pieces;
    private List<FossilPiece> pieces {
        get {
            if (_pieces == null){
                _pieces = GetComponentsInChildren<FossilPiece>().ToList();
                UpdateMass();
            }
            return _pieces;
        }
    }

    ContactPoint[] contacts = new ContactPoint[128];
    int contactLength;

    public void SplitFossilPiece(FossilPiece piece) {
        // Seperate fossil to its own gameobject with its own rigidboy
        var gameObj = piece.gameObject;
        gameObj.transform.SetParent(null, true);
        var rbTEMP = gameObj.AddComponent<Rigidbody>();
        gameObj.AddComponent<OVRGrabbable>();
        rbTEMP.mass = piece.mass;

        pieces.Remove(piece);

        // Destroy once no more exists
        if (pieces.Count() > 0) {
            UpdateMass();
        } else {
            Destroy(gameObject);
        }

    }

    private void UpdateMass(){
        float mass = 0.0f;
        foreach(var piece in pieces) {
            mass += piece.mass;
        }
        Rb.mass = mass;
    }

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
