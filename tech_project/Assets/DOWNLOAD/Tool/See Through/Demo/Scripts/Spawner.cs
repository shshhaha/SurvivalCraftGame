using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CygnusProjects.SeeThrough
{
    public class Spawner : MonoBehaviour
    {
        public GameObject PlayerObject;
        public SeeThroughController STController;

        // Use this for initialization
        void Start()
        {
            // When no SeeThroughController is assigned in the editor find it in the scene
            if (STController == null)
            {
                // This is an expensive call Performance wise so if possible set the reference in the editor
                STController = GameObject.FindObjectOfType<SeeThroughController>();
            }

            // Disable the SeeThrough controller
            STController.enabled = false;

            // Instantiate the player - target for SeeThrough
            GameObject player = Instantiate(PlayerObject, transform.position, transform.rotation);
            // Pass the transform to the SeeThroughController
            STController.target = player.transform;

            // Enable the controller as everything is in place for the asset to work correctly
            STController.enabled = true;
        }
                
    }
}
