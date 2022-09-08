using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Rigidbody2D rb;
    private Vector2 movement;
    [SerializeField] private float moveSpeed = 200f;

    public Animator anim;

    public static PlayerController instance;
    public string areaTransitionName;

    private Vector3 bottomLeftLimit;
    private Vector3 topRightLimit;

    public bool canMove = true;
    public bool canHarvest = false;
    public float timeRemaining = 0.33f;

    public Quest quest;
    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        DontDestroyOnLoad(gameObject);
        
    }
    void Update()
    {
        movement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));


        anim.SetFloat("moveX", rb.velocity.x);
        anim.SetFloat("moveY", rb.velocity.y);
        if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)
        {
            if (canMove)
            {
                anim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
                anim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
            }
            
        }

        if (Input.GetKeyDown(KeyCode.E) && canHarvest == true)
        {
            anim.SetBool("Attack", true);
            anim.SetBool("Attack", false);
            
        }
        

    }
    

    private void FixedUpdate()
    {
        if (canMove)
        {
            rb.velocity = movement.normalized * moveSpeed * Time.fixedDeltaTime;
        }
        else
        {
            rb.velocity = Vector2.zero;
        }
        
        transform.position = new Vector3(Mathf.Clamp(transform.position.x, bottomLeftLimit.x, topRightLimit.x), Mathf.Clamp(transform.position.y, bottomLeftLimit.y, topRightLimit.y), transform.position.z);
    }

    public void SetBounds(Vector3 botLeft, Vector3 TopRight)
    {
        bottomLeftLimit = botLeft + new Vector3(0.5f, 0.5f, 0f);
        topRightLimit = TopRight + new Vector3(-0.5f, -0.5f, 0f);
    }
}
