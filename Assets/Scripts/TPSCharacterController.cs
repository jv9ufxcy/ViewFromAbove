using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TPSCharacterController : MonoBehaviour
{
    [SerializeField] private float playerSpeed = 10f;
    private float horizontal, vertical;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    private void PlayerMovement()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");
        Vector3 playerMovement = new Vector3(horizontal, 0f, vertical);
        playerMovement=Vector3.ClampMagnitude(playerMovement,1)* playerSpeed * Time.deltaTime;
        transform.Translate(playerMovement, Space.Self);
    }
}
