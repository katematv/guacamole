using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LylaController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Rigidbody2D rb;
    public Animator animator;
    private NPC npc;
    private Pies pies;
    Vector2 movement;


    void Start()
    {
        pies = GetComponentInChildren<Pies>();
    }

    // Update is called once per frame
    void Update()
    {
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");

            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
            animator.SetFloat("Speed", movement.sqrMagnitude);

            if (Input.GetAxisRaw("Horizontal") == 1 || Input.GetAxisRaw("Horizontal") == -1 || Input.GetAxisRaw("Vertical") == 1 || Input.GetAxisRaw("Vertical") == -1)

            {
                animator.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
                animator.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
            }

    }

    void FixedUpdate()
    {
    rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private bool inDialogue()
    {
        if (npc != null)
            return npc.DialogueActive();
        else
            return false;
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "NPC") 
        {
            npc = collision.gameObject.GetComponent<NPC>();

            if (Input.GetMouseButtonDown(0))
                npc.ActivateDialogue();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        npc = null;
    }

 private void Pisar()
    {
        pies.ReproducirSonido();
    }
}

