using UnityEngine;
using System.Collections;

public class MovingPlatform : MonoBehaviour {


    float move = 0.0625f;
    int direction = 1;

    public bool upDown = true;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

        if(upDown){
            if((transform.position.y >= 20f && direction == 1) || (transform.position.y <= 10f && direction == -1))
            direction *= -1;
        transform.Translate(0, direction * move, 0);
        }
        else
        {
            if ((transform.position.x >= 48f && direction == 1) || (transform.position.x <= -48f && direction == -1))
                direction *= -1;
            transform.Translate(5*direction * move,0, 0);
        }
        
	}
}
