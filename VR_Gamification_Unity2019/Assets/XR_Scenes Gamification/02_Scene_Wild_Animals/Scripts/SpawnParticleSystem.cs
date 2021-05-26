using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnParticleSystem : MonoBehaviour
{
    public GameObject particleSystemPrefab;
    private GameObject currentParticles;
    private int currentChild = -1;
    // Start is called before the first frame update
    void Start()
    {
        ActivateCurrentParticles();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ActivateCurrentParticles() {
        // Keep track of the current child
        currentChild += 1;
        if (currentChild > transform.childCount)
            return;
        // Find MEsh Center in child
        Transform child = transform.GetChild(currentChild);
        MeshFilter childMeshContainer = child.GetComponent<MeshFilter>();
        Vector3 center = childMeshContainer.mesh.bounds.center;
        // Create or Move the partcles to the child
        if(currentParticles == null)
            currentParticles = GameObject.Instantiate(particleSystemPrefab);
        currentParticles.transform.SetParent(child);
        currentParticles.transform.localPosition = center;
        // Enable interaction for the child
        InteractionController interactionController = child.GetComponent<InteractionController>();
        interactionController.enabled = true;
    }
}
