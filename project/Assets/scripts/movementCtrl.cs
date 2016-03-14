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
		rigidbody.velocity = new Vector2(move * maxSpeed, rigidbody.velocity.y);

		if (move > 0 && !facingRight) {
			FlipFacing();
		}
		else if (move < 0 && facingRight) {
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
