using UnityEngine;
using System.Collections;

public class Gravity : MonoBehaviour
{
    private Rigidbody2D rigidbody;

    void FollowTargetWitouthRotation(Transform target, float distanceToStop, float speed)
        {
            var direction = Vector3.zero;
            if (Vector3.Distance(transform.position, target.position) > distanceToStop)
            {
                direction = target.position - transform.position;
                rigidbody.AddRelativeForce(direction.normalized * speed, ForceMode2D.Force);
            }
        }
 
}