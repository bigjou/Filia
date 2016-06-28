using UnityEngine;
using System.Collections;

public class PlayerControl : MonoBehaviour {

    public float maxSpeed = 5.0f;

    private bool facingRight = true;
    private Animator anim;
    private CharacterController _charController;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
        _charController = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame


    void Update() {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        if (moveX != 0)
            anim.SetFloat("Speed", Mathf.Abs(moveX));
        else
            anim.SetFloat("Speed", Mathf.Abs(moveZ));

        Vector3 move = new Vector3(moveX * maxSpeed, 0, moveZ * maxSpeed);

        move = Vector3.ClampMagnitude(move, maxSpeed);
        move *= Time.deltaTime;

        move = transform.TransformDirection(move);
        _charController.Move(move);

        if (moveX > 0 && !facingRight)
            Flip();
        else if (moveX < 0 && facingRight)
            Flip();
    }

    private void Flip() {
        facingRight = !facingRight;

        Vector3 theScale = transform.localScale;

        theScale.x *= -1;

        transform.localScale = theScale;
    }
}
