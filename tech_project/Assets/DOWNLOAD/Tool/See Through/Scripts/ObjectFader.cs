using UnityEngine;
using System.Collections;
using System;

namespace CygnusProjects.SeeThrough
{ 
    public class ObjectFader : MonoBehaviour
    {        
        public Material[] MaterialToFade;       // List of materials you want to fade away
        public Material[] FadeMaterial;         // List of the replacement materials
        public ObjectFader[] FadeAlsoObjects;   // List of object you are also want to fade at the same time. The so called Linked Objects.

        private Renderer objrenderer;
        private Material[] materials;
        private int[] oldMaterial;
        private bool isAlreadyFaded = false;    // Make sure we don't go into stack overflow.

        // Use this for initialization
        void Start()
        {
            isAlreadyFaded = false;

            // No materials to fade then do nothing
            if (MaterialToFade.Length == 0) return;
            // There most be as many replacement materials as there are materials indicated to be faded.
            if (MaterialToFade.Length != FadeMaterial.Length )
            {
                Debug.LogWarning("Material arrays are not the same length, fading will not work.");
                return;
            }

            // Prepare the caching of the old materials
            oldMaterial = new int[MaterialToFade.Length];
            // Get the renderer of the gameobject
            objrenderer = GetComponent<Renderer>();
            // and copy its materials
            materials = objrenderer.materials;

            // As long as we have materials we like to fade
            for (int j = 0; j < MaterialToFade.Length; j++)
            {
                // look within the renderers materials for a match
                for (int i = 0; i < objrenderer.sharedMaterials.GetLength(0); i++)
                {                    
                    // if a material is matching (Instance is used for SpeedTree) then cache that material
                    if (objrenderer.sharedMaterials[i] == MaterialToFade[j] || objrenderer.sharedMaterials[i].name == MaterialToFade[j].name + " (Instance)")
                    {                        
                        oldMaterial[j] = i;
                    }

                }
            }
            
        }

        /// <summary>
        /// This routine replaces the old materials by there new fade material or the other way around.
        /// </summary>
        /// <param name="isFaded">Is the object/linked object faded?</param>
        public void Fade(bool isFaded)
        {
            try
            {
                // Don't perform fading over and over as this will lead to stack overflow
                if (isFaded != isAlreadyFaded)
                {
                    // Make sure we only do the fading once.
                    isAlreadyFaded = isFaded;
                    // Do we have a renderer object?
                    if (objrenderer != null)
                    {
                        // For every material in the to fade array
                        for (int j = 0; j < MaterialToFade.Length; j++)
                        {
                            // If the object is faded
                            if (isFaded)
                            {
                                // assign the new fade material from the array
                                materials[oldMaterial[j]] = FadeMaterial[j];
                            }
                            else
                            {
                                // reset to the old material
                                materials[oldMaterial[j]] = MaterialToFade[j];
                            }
                        }
                        // Pass the array of materials back to the renderer.
                        objrenderer.materials = materials;
                    }

                    // Do we have objects linked?
                    if (FadeAlsoObjects != null && FadeAlsoObjects.Length > 0)
                    {
                        // For every ibject within the linked object list
                        for (int i = 0; i < FadeAlsoObjects.Length; i++)
                        {
                            // Pass through the fade request.
                            FadeAlsoObjects[i].Fade(isFaded);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log(e.Message);
            }
        }
        
    }
}