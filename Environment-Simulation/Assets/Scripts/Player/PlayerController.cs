using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private PlayerStats playerStats;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = this.GetComponent<PlayerStats>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
        if (movement != Vector3.zero)
        {
            float movementSpeed = playerStats.GetWalkSpeed();
            if (Input.GetKey(KeyCode.LeftShift))
            {
                movementSpeed = playerStats.GetRunSpeed();
            }
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), Time.deltaTime * playerStats.GetTurnSpeed());
            transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);
        }
    }
}
