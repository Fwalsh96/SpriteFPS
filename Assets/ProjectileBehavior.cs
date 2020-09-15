using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior : MonoBehaviour
{
    // When Colliding with anything
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Projectile Collided with something");
        Destroy(this.gameObject);
    }
}
