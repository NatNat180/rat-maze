using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoseCollider : MonoBehaviour
{

	public Transform rat;

    void OnTriggerEnter(Collider collider)
    {
        // turn rat around if it collides with wall
        if (collider.transform.tag == "Wall")
        {
            Vector3 rotateAngles = rat.rotation.eulerAngles;
            rotateAngles = new Vector3(rotateAngles.x, rotateAngles.y + 180, rotateAngles.z);
            rat.rotation = Quaternion.Euler(rotateAngles);
        }
    }
}
