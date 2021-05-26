using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour
{
    public GameObject elephantTarget;
    private int currentChild = -1;
    // Start is called before the first frame update
    void Start()
    {
        MoveTheTarget();
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void MoveTheTarget()
    {
        // Keep track of the current child
        currentChild += 1;
        if (currentChild > transform.childCount)
            return;
        // Find MEsh Center in child
        Transform child = transform.GetChild(currentChild);
        MeshFilter childMeshContainer = child.GetComponent<MeshFilter>();
        Vector3 center = childMeshContainer.mesh.bounds.center;
        // Create or Move the partcles to the child
        elephantTarget.transform.SetParent(child);
        elephantTarget.transform.localPosition = center;
        // Enable interaction for the child
        InteractionController interactionController = child.GetComponent<InteractionController>();
        interactionController.enabled = true;
    }
}
