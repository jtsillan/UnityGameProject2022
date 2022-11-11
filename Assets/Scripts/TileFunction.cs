using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TileFunction : MonoBehaviour
{

    [SerializeField] float Velocity = 0f;
    [SerializeField] float MaxVelocity = -0.015f;   // Maxima Velocity
    [SerializeField] float Acc = 0.001f;           // Current Acceleration
    [SerializeField] float AccSpeed = 0.001f;      // Amount to increase Acceleration with.
    [SerializeField] float MaxAcc = 0.001f;        // Max Acceleration
    [SerializeField] float MinAcc = -0.001f;       // Min Acceleration

    GameObject modular;

    ModularTiles tiles;

    // Start is called before the first frame update
    void Start()
    {

        modular = GameObject.Find("ModularGenerating");
        tiles = modular.GetComponent<ModularTiles>();

    }

    // Update is called once per frame
    void Update()
    {
        // Pelin nopeus
        transform.position = transform.position + Vector3.forward * Velocity;

        if (Input.GetKey(KeyCode.UpArrow))
            Acc += AccSpeed;

        if (Input.GetKey(KeyCode.DownArrow))
            Acc -= AccSpeed;

        if (Acc > MaxAcc)
            Acc = MaxAcc;
        else if (Acc < MinAcc)
            Acc = MinAcc;

        Velocity = (Velocity + Acc);

        if (Velocity > MaxVelocity)
            Velocity = MaxVelocity;

        else if (Velocity < -MaxVelocity)
            Velocity -= MaxVelocity;

        // Poistaa tilet, jotka menneet ohitte
        if (transform.position.z < -30f)
        {
            tiles.NewTileLast();
            Destroy(gameObject);
        }
        
    }

    public void SpeedUp()
    {
        Velocity = Velocity + 0.02f;
    }
}
