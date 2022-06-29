using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float moveForce = 10f;

    [SerializeField]
    private float jumpForce = 11f;
    private float movementX;

    //recuperer les objets
    private Rigidbody2D body;
    //sprite component
    private SpriteRenderer sr;
    private Animator anim;
    private string WALK_ANIMATION = "Walk";
    private string GROUND_TAG = "Ground";
    private string ENEMY_TAG = "Enemy";

    // si player est au sol
    private bool isGrounded;

    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        movePlayerKeyboard();
        animatePlayer();
        playerJump();
    }

    private void FixedUpdate()
    {
        // fixed update est appelé un certain nombre de fois dans un intervalle fixé
        // on utilise pour les calculs concernant la physique comme ce qui concerne le rigidbody
        //playerJump();
    }

    void movePlayerKeyboard()
    {
        // valeur positive si on appuis sur D et négative sur Q ou A (english) et 0 si rien appuyer
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce;
    }

    // Animer le deplacement du joueur
    void animatePlayer()
    {
        // on utilise le movementX pour savoir quoi animer
        if (movementX > 0f)
        {
            //on part à droite
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if(movementX < 0f)
        {
            //on part à gauche
            // pour faire tourner notre personnage on peut utiliser soit la propriétés flip du spriterendrer ou scale x de transform qu'on met à -1
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
        {
            //on reste sur place
            anim.SetBool(WALK_ANIMATION, false);
        }
        
    }

    void playerJump()
    {
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            // appliquer une force
            // forceMode2D.impulse donne une impulsin directe
            isGrounded = false;
            body.AddForce(new Vector2(0f, jumpForce), ForceMode2D.Impulse);
        }
    }

    //oncollisionenter2d pour gerer le fait qu'on soit au sol ou non
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(GROUND_TAG))
        {
            isGrounded = true; 
        }

        if (collision.gameObject.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ENEMY_TAG))
        {
            Destroy(gameObject);
        }
    }
}
