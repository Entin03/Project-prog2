using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Létrehoz automatikusan egy rgbodyt
[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    Rigidbody2D rigidbody2d;
    [SerializeField] float speed = 2f;
    Vector2 motionVector;
    public Vector2 lastMotionVector;
    Animator animator;
    public bool moving;

    void Awake()
    {
        rigidbody2d = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {   
        
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical =  Input.GetAxisRaw("Vertical");

        motionVector = new Vector2(
            horizontal,
            vertical
        );
        //Animáció
        animator.SetFloat("horizontal", horizontal);
        animator.SetFloat("vertical", vertical);

        //Megnézzük hogy mozog-e a karakter
        moving = horizontal !=0 || vertical !=0;
        animator.SetBool("moving", moving);

        //Ha nem 0 az érték akkor beállítjuk a megelelő mozgást
        if(horizontal !=0 || vertical !=0)
        {
            lastMotionVector = new Vector2(
                horizontal,
                vertical
            ).normalized;
            animator.SetFloat("lastHorizontal", horizontal);
            animator.SetFloat("lastVertical", vertical);
        }
    }

    void FixedUpdate()
    {
        Move();
    }

    //A mozgási sebesség beállítása
    private void Move()
    {
        rigidbody2d.velocity = motionVector * speed;
    }

}
