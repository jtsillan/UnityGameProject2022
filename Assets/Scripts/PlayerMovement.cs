using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //hahmon nopeus
    [SerializeField] float speed = 5;

    //hahmon objekti
    public Rigidbody rb;

    //sivuttaisliike ja sen nopeutus
    float horizontalInput;
    public float horizontalMultiplier = 2;


    private void FixedUpdate()
    {
        //liike eteenpain
        Vector3 forwardMove = transform.forward * speed * Time.fixedDeltaTime;
        //liike sivuttain
        Vector3 horizontalMove = transform.right * horizontalInput * speed * Time.fixedDeltaTime * horizontalMultiplier;
        //hahmon objektin liikutus
        rb.MovePosition(rb.position + forwardMove + horizontalMove);

    }



    private void Update()
    {
        //sivuttais liikkeen kontrolli
        horizontalInput = Input.GetAxis("Horizontal");
    }
}
