using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSceneTileFunctions : MonoBehaviour
{

    [SerializeField] float forwardSpeedMultiplier;

    CharacterMovement characterMovement;

    void Update()
    {

        transform.position = transform.position + characterMovement.MoveForward() * forwardSpeedMultiplier * Vector3.back;

        if (transform.position.z < - 30.2f)
        {
            GameObject generator = GameObject.Find("ModularManager");
            TestSceneModularTiles generatedTiles = generator.GetComponent<TestSceneModularTiles>();
            generatedTiles.MakeNewTileLast();
            Destroy(gameObject);
        }
    }
}
