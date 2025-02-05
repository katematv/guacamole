using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPC : MonoBehaviour
{
    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;
    

    public Rigidbody2D rb;
    Animator animator;

    internal Transform thisTransform;


    [SerializeField] private GameObject dialogue;
    public void ActivateDialogue()
    {
        dialogue.SetActive(true);
    }

    public bool DialogueActive() {
        return dialogue.activeInHierarchy;
    }


    // The movement speed of the object
    public float moveSpeed = 0.2f;

    // A minimum and maximum time delay for taking a decision, choosing a direction to move in
    public Vector2 decisionTime = new Vector2(1, 1);
    internal float decisionTimeCount = 0;

    // The possible directions that the object can move int, right, left, up, down, and zero for staying in place. I added zero twice to give a bigger chance if it happening than other directions
    internal Vector3[] moveDirections = new Vector3[] { Vector3.right, Vector3.left, Vector3.up, Vector3.down, Vector3.zero, Vector3.zero };
    internal int currentMoveDirection;


    // Start is called before the first frame update
    void Start()
    {
       

        rb = GetComponent<Rigidbody2D>();
       // timer = changeTime;
        animator = GetComponent<Animator>();

        // Cache the transform for quicker access
        thisTransform = this.transform;
        // Set a random time delay for taking a decision ( changing direction,or standing in place for a while )
        decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);

        // Choose a movement direction, or stay in place
        ChooseMoveDirection();
    }

    void Update()
    {
        // Move the object in the chosen direction at the set speed
        Vector3 direction = moveDirections[currentMoveDirection];
        float xDir = direction.x;
        float yDir = direction.y;

        thisTransform.position += direction * Time.deltaTime * moveSpeed;

        if (animator)
        {
            animator.SetFloat("MoveX", xDir);
            animator.SetFloat("MoveY", yDir);
        }

        if (decisionTimeCount > 0) decisionTimeCount -= Time.deltaTime;
        else
        {
            // Choose a random time delay for taking a decision ( changing direction, or standing in place for a while )
            decisionTimeCount = Random.Range(decisionTime.x, decisionTime.y);

            // Choose a movement direction, or stay in place
            ChooseMoveDirection();
        }
     }

    void ChooseMoveDirection()
    {
        // Choose whether to move sideways or up/down
        currentMoveDirection = Mathf.FloorToInt(Random.Range(0, moveDirections.Length));
    }
 

    void OnCollisionEnter2D(Collision2D other)
    {
        LylaController player = other.gameObject.GetComponent<LylaController>();

        if (player != null)
        {

        rb.isKinematic = true;
        }
    }
}