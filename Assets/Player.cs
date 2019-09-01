using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private int vida = 5;
    float balaTime;
    private Rigidbody2D heroi;
    private SpriteRenderer renderer;
    public Collider2D col;
    public int vel = 3;
    public bool mov = false; //<-------------- Movimento
    public bool agc = false; //<-------------- Agachado
    public bool pol = false; //<-------------- Pulando
    public bool ati = false; //<-------------- Atirando
    public GameObject bullet;
    private int force = 540;
    public HealthBar healthBar;

    int hitCount = 0;

    Vector3 scale;
    bool isGround = false;
    public int direcao = 1;

    private Animator anin; //<--------------
    private void Start()
    {
        heroi = GetComponent<Rigidbody2D>();
        renderer = GetComponent<SpriteRenderer>();

        scale = transform.localScale;
        anin = GetComponent<Animator>();//<--------------
    }
    
    public void Update()
    {
        anin.SetBool("mov", mov); //<--------------
        anin.SetBool("agc", agc); //<--------------
        anin.SetBool("pul", pol); //<--------------
        anin.SetBool("ati", ati); //<--------------
        agc = false; //<--------------
        mov = false; //<--------------
        pol = false; //<--------------
        ati = false; //<--------------
        

        if (Input.GetKey(KeyCode.DownArrow) && isGround)
            Agachar();
        else
        {
            col.enabled = true;
            transform.localScale = scale;

            if (Input.GetKeyDown(KeyCode.UpArrow) && isGround)
                Jump();

            if(!isGround)
                pol = true;

            if (Input.GetKeyDown(KeyCode.X) & Time.time - balaTime >= 0.05f)
                AttackRight();
            
            if (Input.GetKeyDown(KeyCode.Z) & Time.time - balaTime >= 0.05f)
                AttackLeft();

            if (Input.GetKey(KeyCode.LeftArrow))
                MoveLeft();

            if (Input.GetKey(KeyCode.RightArrow))
                MoveRight();
        }
        if (hitCount >= vida)
            SceneManager.LoadScene(6);
        
    }

    private void Damage()
    {
        healthBar.TakeDamage(hitCount);
        hitCount += 1;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
        }
        if (collision.gameObject.tag == "Balainimiga")
        {
            Damage();
        }
        if (collision.gameObject.tag == "nimigo")
        {
            print("kjhjk");
            Damage();
        }
        if (collision.gameObject.tag == "Finish")
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
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
        mov = true; //<--------------
        transform.position += Vector3.right * vel * Time.deltaTime;
        direcao = 1;

    }
    public void MoveLeft()
    {
        //ir para haddad
        mov = true; //<--------------
        transform.position += Vector3.left* vel * Time.deltaTime;
        direcao = -1;
    }
    public void Jump()
    {
        //eu quero ir pra frente
        
        heroi.AddForce(new Vector3(0,1,0) * force);
    }
    public void Agachar()
    {
        //eu quero ir pra frente
        agc = true; //<--------------
        col.enabled = false;
        

        //transform.localScale = scale /2;

    }
    public void AttackRight()
    {
        //atack
        direcao = 1;
        GameObject newBala = Instantiate(bullet, transform.position + (Vector3.right), Quaternion.identity);
        newBala.GetComponent<Bala>().Initialize(direcao);

        renderer.flipX = false;
         
        balaTime = Time.time;
        anin.ResetTrigger("sho");
        anin.SetTrigger("sho");
    }
    public void AttackLeft()
    {
        //atack
        direcao = -1;
        GameObject newBala = Instantiate(bullet, transform.position + (Vector3.left), Quaternion.identity);
        newBala.GetComponent<Bala>().Initialize(direcao);

        renderer.flipX = true;

        balaTime = Time.time;
        anin.ResetTrigger("sho");
        anin.SetTrigger("sho");
    }
}