using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    public Animator anim;

    public float speed = 10f;

    public float jumpVelocity;
    public float fallMultiplier = 2.5f;
    public float lowJumpMultiplier = 1f;

    [SerializeField]
    GameObject Wall;
    public static bool isGrounded = false;
    public float distToGround = 0.7f;
    public static bool canMove = true;
    [SerializeField]
    GameObject edge1;
    [SerializeField]
    GameObject edge2;

    bool Dash = false;
    float dashTime = 0;
    public float dashSpeed;
    public float dashDuration;
    int DashDirection;
    float dStartPos;
    float dEndPos;
    bool canDash = false;

    public static bool canGroundCheck = true;

    Rigidbody rb;

	// Use this for initialization
	void Start () {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (canGroundCheck)
        {
            GroundCheck();
        }
        if (canMove)
        {
            float hAxis = Input.GetAxis("Horizontal");

            Vector3 movement = new Vector3(hAxis, 0, 0) * speed * Time.deltaTime;
            rb.MovePosition(transform.position + movement);

            if (hAxis < 0)
            {
                DashDirection = -1;
            }
            if (hAxis > 0)
            {
                DashDirection = 1;
            }

            if (Input.GetKeyDown(KeyCode.Mouse1) && canDash)
            {
                Dash = true;
                canDash = false;
                anim.SetBool("Dash", true);
                StartCoroutine(DashAnim());
            }

            if (Dash)
            {
                if (dashTime < dashDuration)
                {
                    dashTime += 1 * Time.deltaTime;
                    Vector3 dash = new Vector3(DashDirection, 0, 0) * dashSpeed * Time.deltaTime;
                    rb.MovePosition(transform.position + dash);
                }
                else
                {
                    dashTime = 0;
                    Dash = false;
                }
            }

            if (Input.GetButton("Jump") && isGrounded)
            {
                GetComponent<Rigidbody>().velocity = Vector2.up * jumpVelocity;
            }
            if (rb.velocity.y < 0)
            {
                rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (rb.velocity.y > 0 && !Input.GetButton("Jump"))
            {
                rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }
	}

    void GroundCheck()
    {
        if (Physics.Raycast(edge1.transform.position, Vector3.down, distToGround) == true || Physics.Raycast(edge2.transform.position, Vector3.down, distToGround) == true)
        {
            isGrounded = true;
            canDash = true;
        }
        else
        {
            isGrounded = false;
        }
    }

    IEnumerator DashAnim()
    {
        yield return new WaitForSeconds(0.2f);
        anim.SetBool("Dash", false);
    }
}
