using UnityEngine;


public class CameraFollow : MonoBehaviour
{

    public Transform player;

    //eteisyys pelaajasta
    Vector3 offset;

    private void Start()
    {
        offset = transform.position - player.position;
    }


    //kameran seuranta ja keskitt�minen
    private void Update()
    {

        Vector3 targetPos = player.position + offset;
        targetPos.x = 0;
        transform.position = targetPos;
    }
}
