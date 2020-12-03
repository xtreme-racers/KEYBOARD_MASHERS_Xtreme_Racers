using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIController : MonoBehaviour
{

    public float acceleration = 0.3f;
    public float steering = 4.0f;

    Vector3 target;

    public void OnNextTrigger(Track next){
       //Debug.Log(Random.value);
        target = Vector3.Lerp(next.transform.position - next.transform.right, 
		                      next.transform.position + next.transform.right, 
		                      Random.value);
        //Debug.Log(target);
    }

    // Update is called once per frame
    void FixedUpdate() {
        
        steer();

	    float velocity = GetComponent<Rigidbody2D>().velocity.magnitude;
		velocity += acceleration;

        GetComponent<Rigidbody2D>().velocity = transform.up * velocity;
        GetComponent<Rigidbody2D>().angularVelocity = 0.0f;
    }


    private void steer(){
        Vector2 towardNextTrigger = target - transform.position;
		float targetRot = Vector2.Angle (Vector2.up, towardNextTrigger);
                //Debug.Log("ROT: "+ targetRot);

		if (towardNextTrigger.y < 0.0f || (towardNextTrigger.x>0.0f && towardNextTrigger.y>0.0f)) {
			targetRot = -targetRot;
            
		}
        
        //Debug.Log(towardNextTrigger.x +" "+ towardNextTrigger.y + " " + targetRot);
		float rot = Mathf.MoveTowardsAngle (transform.localEulerAngles.z, targetRot, steering);
        //rot = rot % rot + 270f;
        //De-transform.localEulerAngles.z
        //Debug.Log(rot % rot + 270f);
		transform.eulerAngles = new Vector3 (0.0f, 0.0f, rot);
    }

}
