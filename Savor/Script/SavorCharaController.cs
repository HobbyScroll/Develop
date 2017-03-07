using UnityEngine;
using Spine.Unity;
using System.Collections;

public class SavorCharaController : MonoBehaviour {

	public float MaxSpeed = 10.0f;
	public float jumpForce = 700;
	bool facingRight = false;
	//Animator anim;

	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround; 
    private Rigidbody2D _rigid;
    private SkeletonAnimation _Skel;

	// Use this for initialization
	void Start () {

		//anim = GetComponentInChildren<Animator> ();
        _rigid = GetComponent<Rigidbody2D>();
        _Skel = GetComponent<SkeletonAnimation>();
        
     

    }
	
	// Update is called once per frame
	void FixedUpdate () 
		{
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
        //anim.SetBool ("Ground", grounded);
        //anim.SetFloat ("vSpeed", _rigid.velocity.y);
       // _Skel.set


        float move = Input.GetAxis ("Horizontal");
        //anim.SetFloat ("Speed", Mathf.Abs (move));
        _Skel.AnimationState.SetAnimation(0,"idle",true);

        _rigid.velocity = new Vector2 (move * MaxSpeed, _rigid.velocity.y);
		if (move > 0 && !facingRight)
			Flip ();
		else if (move < 0 && facingRight)
			Flip ();
		}

	void Update()
		{
            if (Input.GetKeyDown(KeyCode.Space))
            //  if (grounded && Input.GetKeyDown(KeyCode.Space))
              {
			//	anim.SetBool("Grounded", false);
                 _rigid.AddForce(new Vector2(0,jumpForce));
                  _Skel.AnimationState.SetAnimation(1, "move", true);
                 }
		}

	void Flip()
		{
			facingRight = !facingRight;
			Vector3 theScale = transform.localScale;
			theScale.x *= -1;
			transform.localScale = theScale;

		}
}
