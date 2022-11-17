using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //hahmon nopeus
    public float speed = 0;

    //hahmon objekti
    public Rigidbody rb;

    //sivuttaisliike ja sen nopeutus
    float horizontalInput;


    private void FixedUpdate()
    {
        //liike eteenpin
        Vector3 forwardMove = transform.right * speed * Time.fixedDeltaTime;
        //liike sivuttain
        Vector3 horizontalMove = -transform.forward * horizontalInput * speed * Time.fixedDeltaTime;
        //hahmon objektin liikutus
        rb.MovePosition(rb.position  + horizontalMove);

    }



    private void Update()
    {
        //sivuttais liikkeen kontrolli
        horizontalInput = Input.GetAxis("Horizontal");

    }
}
