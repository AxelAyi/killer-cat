using UnityEngine;
using System.Collections;

public class movementCtrl : MonoBehaviour {
	public float maxSpeed = 10.0f;

	bool facingRight = true;

	Animator anim;
	Rigidbody2D rigidbody;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();	
		rigidbody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		float move = Input.GetAxis("Horizontal");
		anim.SetFloat("speed", Mathf.Abs(move));
		float absVelocityX = Mathf.Abs(move) * maxSpeed;
		float velocityX = facingRight ? absVelocityX : -absVelocityX;
		rigidbody.velocity = new Vector2(velocityX, rigidbody.velocity.y);

		if ((move > 0 && !facingRight) || (move < 0 && facingRight)) {
			//anim.SetTrigger("flip"); // run break
			FlipFacing();
		}
	}

	void FlipFacing() {
		facingRight = !facingRight;
		Vector3 charScale = transform.localScale;
		charScale.x *= -1;
		transform.localScale = charScale;
	}
}
