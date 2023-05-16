using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player2 : MonoBehaviour
{
    private CharacterController controller;
    private Animator anim;

    
    public float speed;
    public float gravity;
    public float rotSpeed;
    public float JumpForce;
    public LayerMask Ground;

    public float forcaDoSalto = 5f;
    private bool estaNoChao;
    private Rigidbody rb;

    private float rot;
    private Vector3 moveDirection;
    
    bool grounded, jump;

    public GameObject bombaPrefab;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        CheckGrounded();

        if (Input.GetKeyDown(KeyCode.B))
        {
            // Instancia uma nova bomba no mesmo local do personagem
            Instantiate(bombaPrefab, transform.position, Quaternion.identity);
        }
    }

    void CheckGrounded()
    {
        grounded = Physics.Raycast(transform.position + Vector3.up * 0.1f, Vector3.down, .2f, Ground);
    }

    void Move()
    {
        if(controller.isGrounded)
        {
            if(Input.GetKey(KeyCode.W))
            {
               moveDirection = Vector3.forward * speed;
               anim.SetInteger("transition", 1);      
            }
            if(Input.GetKeyUp(KeyCode.W))
            {
                moveDirection = Vector3.zero;
                anim.SetInteger("transition", 0); 
            }
                
                estaNoChao = Physics.Raycast(transform.position, Vector3.down, 0.1f);

            // Verifica se a tecla de espaço foi pressionada e o personagem está no chão
            if (Input.GetKeyDown(KeyCode.Space) && estaNoChao)
            {
            // Aplica uma força vertical para fazer o personagem pular
                rb.AddForce(Vector3.up * forcaDoSalto, ForceMode.Impulse);
            }
        
        }

        rot += Input.GetAxis("Horizontal") * rotSpeed * Time.deltaTime;
        transform.eulerAngles = new Vector3(0, rot, 0);

        moveDirection.y -= gravity * Time.deltaTime;
        moveDirection = transform.TransformDirection(moveDirection);
        controller.Move(moveDirection * Time.deltaTime);
    }
}
