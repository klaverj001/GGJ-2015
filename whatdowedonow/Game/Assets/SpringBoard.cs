using UnityEngine;
using System.Collections;

public class SpringBoard : MonoBehaviour {
    bool firing = false;
    float timeToDrop = 0.1f;
    float timer = 0.1f;

    private tk2dSpriteAnimator anim;
	// Use this for initialization
	void Start () {
        anim = GetComponent<tk2dSpriteAnimator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (firing)
        {
            // return to original state after .1s
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = timeToDrop;
                firing = false;
                anim.SetFrame(0);
            }
        }
	}
    void OnTriggerEnter2D(Collider2D c)
    {
        //&& !firing
        if (c.gameObject.tag == "Player" )
        {
            // c.gameObject.rigidbody2D.velocity.Set(c.gameObject.rigidbody2D.velocity.x, 0.0f);
//            c.gameObject.GetComponent<Player1>().physVel.Scale(new Vector2(1, 0));

            if (c.gameObject.rigidbody2D.velocity.y < -9)
            {
                c.gameObject.rigidbody2D.AddForce(new Vector2(0, 20), ForceMode2D.Impulse);
            }
            else
            {
                c.gameObject.rigidbody2D.AddForce(new Vector2(0, 10), ForceMode2D.Impulse);
            }

            
            //c.gameObject.GetComponent<Player1>().physVel.Set(c.gameObject.GetComponent<Player1>().physVel.x, 10.0f); ;
            //c.gameObject.GetComponent<Player1>().physVel.y = 10.0f;
            anim.SetFrame(1);
            firing = true;
        }
    }
}
