using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
using CygnusProjects.SeeThrough;

namespace CygnusProjects.SeeThrough
{
    /// <summary>
    /// SeeThroughController is the trigger that drives the ObjectFader components. It uses a Ray to determine which objects are between the player (target) and the camera 
    /// setting those materials accordingly.
    /// </summary>
    [RequireComponent(typeof(Camera))]
    public class SeeThroughController : MonoBehaviour
    {

        public Transform target;                                        // Object we try to follow.              
        public Vector3 targetOffSet = Vector3.zero;                     // The offset added to the target.position to determine the actual raycast target.
        public bool fadeObjects = false;                                // Enable objects of a certain layer to be faded.
        public LayerMask fadeLayer;                                     // The layer where we will allow transparency.
        public bool inversedRay;                                        // Can Player see the camera (true) iso camera looking for player (false)? Works only in perspective mode!

        private Transform myTransform;                                  // The transform of the current (camera) object
        private List<ObjectFader> prevHit = new List<ObjectFader>();    // List of objects which can fade (detetmined by physics hits)
        private float maxDistance;                                      // Maximum distance between the camera an the target, used to termine the physics ray length.

        private Camera cam;                                             // Hold a reference to the camera, to determine if we are in orthographic or perspective.

        void Start()
        {
            myTransform = transform;                        
            if (target == null)
            {
                target = GameObject.FindGameObjectWithTag("Player").transform;
            }
            cam = GetComponent<Camera>();            
        }
                

        void LateUpdate()
        {
            // No target == no fun
            if (target == null)
            {
                return;
            }
            
            // Failesafe the current camera position
            myTransform = transform;                      

            // Start checking if object between camera and target.
            if (fadeObjects)
            {
                // Calculate the ray length
                Vector3 offset = (target.position + targetOffSet) - myTransform.position;                  
                float maxDistance = Mathf.Sqrt(offset.sqrMagnitude);

                // Store the raycast hits
                RaycastHit[] hits;

                //check the camera projection mode
                if (cam.orthographic)
                {
                    // Cast a ray towards the target using the screen point.
                    Vector3 screenPos = cam.WorldToScreenPoint(target.position + targetOffSet);
                    Ray ray = cam.ScreenPointToRay(screenPos);                    
                    hits = Physics.RaycastAll(ray, maxDistance, fadeLayer);
                }
                else
                {
                    // Cast ray from camera.position to target.position and check if the specified layers are between them.
                    Ray ray;
                    if (!inversedRay)
                        ray = new Ray(myTransform.position, ((target.position + targetOffSet) - myTransform.position).normalized);               
                    else
                        ray = new Ray((target.position + targetOffSet), (myTransform.position - (target.position + targetOffSet)).normalized);

                    hits = Physics.RaycastAll(ray, maxDistance, fadeLayer);
                }                

                // Did we hit something?
                if (hits.Length > 0)
                {                    
                    // Check every object we do hit with the ray
                    for (int i = 0; i < hits.Length; i++)
                    {
                        RaycastHit hit;
                        hit = hits[i];
                        Transform objectHit = hit.transform;

                        // There should be an ObjectFader component on the object we hit
                        ObjectFader fader = objectHit.gameObject.GetComponent<ObjectFader>();
                        /*if (prevHit.Contains(fader))
                        {
                            if (fader != null)
                                fader.Fade(false);
                        }*/
                        
                        // If there is a renderer we will swap the materials
                        if (objectHit.GetComponent<Renderer>() != null)
                        {
                            if (!prevHit.Contains(fader))
                            {
                                if (fader != null)
                                {
                                    prevHit.Add(fader);
                                    fader.Fade(true);
                                }
                            }
                        }
                        // In some cases (like fi Speedtree) we need an ObjectFader on the root model for driving the underlying parts
                        else
                        {
                            if (!prevHit.Contains(fader))
                            {
                                // in such a case we will past the fade request to the linked objects without swapping the materials of the root (there won't be any most lickly anyway)                                                           
                                if (fader != null)
                                {
                                    prevHit.Add(fader);
                                    fader.Fade(true);
                                }
                            }
                        }
                        
                    }
                }
                else
                {
                    // No hits on the raycast? Swap the materials back to there original states
                    for (int j = prevHit.Count - 1; j >= 0; j--)
                    {
                        prevHit[j].Fade(false);
                        prevHit.Remove(prevHit[j]);
                    }
                }
            }


        }
    }
}
