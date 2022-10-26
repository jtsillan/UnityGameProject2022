using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    //hahmon nopeus
    [SerializeField] float speed = 5;


    private void FixedUpdate()
    {
        //liike eteenpain
        Vector3 backwardMove = transform.forward * speed * Time.fixedDeltaTime;

    }
}