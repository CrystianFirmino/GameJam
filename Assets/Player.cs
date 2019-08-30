using UnityEngine;

public class Player : MonoBehaviour
{
    float balaTime;
    private Rigidbody2D heroi;
    public int vel = 3;
    public bool mov = false;
    public GameObject bullet;
    public int force = 320;

    Vector3 scale;
    bool isGround = false;
    private void Start()
    {
        heroi = GetComponent<Rigidbody2D>();
        scale = transform.localScale;
    }
    
    public void Update()
    {
        mov = false;
        if (Input.GetKey(KeyCode.LeftArrow))
            MoveLeft();
        if (Input.GetKey(KeyCode.RightArrow))
            MoveRight();
        if (Input.GetKey(KeyCode.DownArrow))
            Agachar();
        else
        {
            transform.localScale = scale;
            if (Input.GetKeyDown(KeyCode.UpArrow) && isGround)
                Jump();

            if (Input.GetKeyDown(KeyCode.Space) & Time.time - balaTime >= 1)
                Attack();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = false;
        }
    }

    public void MoveRight()
    {
        //ir para bolsonaro
        mov = true;
        transform.position += Vector3.right * vel * Time.deltaTime;
    }
    public void MoveLeft()
    {
        //ir para haddad
        mov = true;
        transform.position += Vector3.left* vel * Time.deltaTime;
    }
    public void Jump()
    {
        //eu quero ir pra frente
        heroi.AddForce(new Vector3(0,1,0) * force);
    }
    public void Agachar()
    {
        
        //eu quero ir pra frente
        transform.localScale = scale /2;
    }
    public void Attack()
    {
        //atack
        Instantiate(bullet, transform.position + (Vector3.right), Quaternion.identity);
        balaTime = Time.time;
    }
}
