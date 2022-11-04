using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //hahmon objekti
    public Rigidbody rb;

    //sivuttaisliike ja sen nopeutus
    public float horizontalInput;
    public float horizontalMultiplier = 2;

    private void FixedUpdate()
    {
        //liike sivuttain
        Vector3 horizontalMove = -transform.forward * horizontalInput * Time.fixedDeltaTime * horizontalMultiplier;
        //hahmon objektin liikutus
        rb.MovePosition(rb.position + horizontalMove);

    }


    private void Update()
    {
        //sivuttais liikkeen kontrolli
        horizontalInput = Input.GetAxis("Horizontal");


    }
}
