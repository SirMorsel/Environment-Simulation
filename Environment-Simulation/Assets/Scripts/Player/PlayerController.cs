using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    private PlayerStats playerStats;
    private UIManager uiManager;

    private GameObject objectToInteract = null;

    // Start is called before the first frame update
    void Start()
    {
        playerStats = this.GetComponent<PlayerStats>();
        uiManager = UIManager.Instance;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Interact();
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

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Interactable")
        {
            uiManager.ChangeInteractableUITextVisibility(true);
            objectToInteract = other.gameObject;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Interactable")
        {
            uiManager.ChangeInteractableUITextVisibility(false);
            objectToInteract = null;
        }
    }

    private void Interact()
    {
        if (Input.GetKeyDown(KeyCode.E) && objectToInteract != null)
        {
            objectToInteract.gameObject.GetComponent<SnowMelt>().ChangeIsOnState();
        }
    }
}
