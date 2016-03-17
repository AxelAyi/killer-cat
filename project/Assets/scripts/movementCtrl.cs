using UnityEngine;
using System.Collections;

public class movementCtrl : MonoBehaviour {
	public float maxSpeed = 10.0f;
	public float jumpSpeed = 10.0f;

	//Empty gameobject created to determine the bounds/center of the object
	public Transform GroundCheck1;

	public LayerMask ground_layers;

	bool facingRight = true;

	Animator anim;
	Rigidbody2D rigidBody;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();	
		rigidBody = GetComponent<Rigidbody2D>();
	}

	//All the Physics related things to be done here
	void FixedUpdate(){
		bool isGrounded = IsGrounded();
		float moveX = Input.GetAxisRaw("Horizontal");
		float moveY = Input.GetAxisRaw("Vertical");
		float absVelocityX = Mathf.Abs(moveX) * maxSpeed;

		float velocityX = facingRight ? absVelocityX : -absVelocityX;
		float velocityY = rigidBody.velocity.y;

		anim.SetFloat("absMoveX", absVelocityX);
		anim.SetFloat("moveY", velocityY);
		anim.SetBool("grounded", isGrounded);

		if ((moveX > 0 && !facingRight) || (moveX < 0 && facingRight)) {
			FlipFacing();
		}

		if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
			velocityY = jumpSpeed;
		}

		rigidBody.velocity = new Vector2(velocityX, velocityY);
	}

	bool IsGrounded() {
		return Physics2D.OverlapCircle(GroundCheck1.position, 0.1f, ground_layers);
	}

	void FlipFacing() {
		facingRight = !facingRight;
		Vector3 charScale = transform.localScale;
		charScale.x *= -1;
		transform.localScale = charScale;
	}
}
