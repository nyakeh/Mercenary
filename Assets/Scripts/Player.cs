using UnityEngine;

public class Player : MonoBehaviour {
    private Rigidbody2D _playerBody;
    [SerializeField]
    private float _movementSpeed = 10;
    private bool facingRight = true;

	void Start() {
        _playerBody = GetComponent<Rigidbody2D>();
	}
	
	void FixedUpdate() {
        float horizontal = Input.GetAxis("Horizontal");
        HandleMovement(horizontal);
        Flip(horizontal);
	}

    private void HandleMovement(float horizontal)
    {
        _playerBody.velocity = new Vector2(horizontal * _movementSpeed, _playerBody.velocity.y);
    }

    private void Flip(float horizontal)
    {
        if (horizontal > 0 && !facingRight || horizontal < 0 && facingRight)
        {
            facingRight = !facingRight;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
    }
}