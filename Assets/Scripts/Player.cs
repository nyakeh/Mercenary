using UnityEngine;

public class Player : MonoBehaviour {
    private Rigidbody2D _playerBody;
    private Animator _playerAnimator;
    [SerializeField]
    private float _movementSpeed = 10;
    private bool facingRight = true;

	void Start() {
        _playerBody = GetComponent<Rigidbody2D>();
        _playerAnimator = GetComponent<Animator>();
	}
	
	void FixedUpdate() {
        float horizontal = Input.GetAxis("Horizontal");
        HandleMovement(horizontal);
        Flip(horizontal);
	}

    private void HandleMovement(float horizontal)
    {
        _playerBody.velocity = new Vector2(horizontal * _movementSpeed, _playerBody.velocity.y);
        _playerAnimator.SetFloat("speed", Mathf.Abs(horizontal));
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