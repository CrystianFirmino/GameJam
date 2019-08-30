using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D heroi;
    private void Start()
    {
        heroi = GetComponent<Rigidbody2D>();
    }
    public void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
            MoveLeft();
        if (Input.GetKey(KeyCode.RightArrow))
            MoveRight();
        if (Input.GetKeyDown(KeyCode.UpArrow) & transform.position.y< -3.2)
            Jump();
        if (Input.GetKeyDown(KeyCode.Space))
            Attack();
    }

    

    public void MoveRight()
    {
        //ir para bolsonaro
        transform.position += Vector3.right * 3 * Time.deltaTime;
    }
    public void MoveLeft()
    {
        //ir para haddad
        transform.position += Vector3.left*3*Time.deltaTime;
    }
    public void Jump()
    {
        //eu quero ir pra frente
        heroi.AddForce(new Vector3(0,1,0) * 250);
    
        
    }
    public void Attack()
    {
        //ataca
    }
}
