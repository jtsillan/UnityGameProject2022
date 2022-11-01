using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    //tile:n nopeus
    [SerializeField] float speed = 5;


    private void FixedUpdate()
    {
        //liike pelaajaan päin
        Vector3 backwardMove = transform.forward * speed * Time.fixedDeltaTime;

    }
}