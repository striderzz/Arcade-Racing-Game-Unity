using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarChaseAI : MonoBehaviour
{
    public Transform target;
    public CarController carController;
    public float chaseDistance = 2f;

    private void Awake()
    {
        carController = GetComponent<CarController>();
    }

    private void Update()
    {
        float distanceToTarget = Vector3.Distance(transform.position, target.position);

        if (distanceToTarget > chaseDistance)
        {
            // Call a function to make the AI car chase the player
            ChasePlayer();
        }
    }

    private void ChasePlayer()
    {
        // Calculate the direction to the player
        Vector3 directionToPlayer = (target.position - transform.position).normalized;

        // Calculate the dot product to determine if the player is on the right or left
        float dotProduct = Vector3.Dot(transform.right, directionToPlayer);

        // Set the horizontal input based on the player's position
        float horizontalInput = (dotProduct > 0) ? 1f : -1f;

        // Set the vertical input based on the direction to the player
        float verticalInput = Mathf.Clamp01(Vector3.Dot(transform.forward, directionToPlayer));

        // Assuming the CarController script has a function named GetInput
        // Adjust the magnitude of verticalInput based on your desired speed
      

        // Call the GetInput function on the carController
        carController.GetAIInput(verticalInput, horizontalInput);
    }



}
