using UnityEngine;
using System.Collections;

public class HorizontalControl : MonoBehaviour {

    public float force = 10;
    Rigidbody2D rigidbody2d;
    
	void Start () {
        rigidbody2d = this.GetComponent<Rigidbody2D>();
    }
	
	void Update () {
        float translation = Input.GetAxis("Horizontal") * force;
        updateForce(new Vector2(translation, 0));
    }

    private void updateForce(Vector2 force)
    {
        rigidbody2d.AddForce(force);
    }
}
