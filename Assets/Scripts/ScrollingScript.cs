using System.Collections.Generic;
using System.Linq;
using UnityEngine;


public static class RendererExtensions
{
    public static bool IsVisibleFrom(this Renderer renderer, Camera camera)
    {
        Plane[] planes = GeometryUtility.CalculateFrustumPlanes(camera);
        return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    }
}

/// <summary>
/// Parallax scrolling script that should be assigned to a layer
/// </summary>
public class ScrollingScript : MonoBehaviour
{
    private Vector2 size;
    /// <summary>
    /// 2 - List of children with a renderer.
    /// </summary>
    private List<Transform> backgroundPart;

    // 3 - Get all the children
    void Start()
    {
        // Get all the children of the layer with a renderer
        backgroundPart = new List<Transform>();

        for (int i = 0; i < transform.childCount; i++)
        {
            Transform child = transform.GetChild(i);

            // Add only the visible children
            if (child.GetComponent<Renderer>() != null)
            {
                backgroundPart.Add(child);
            }
        }

        size = (backgroundPart[0].GetComponent<Renderer>().bounds.max - backgroundPart[0].GetComponent<Renderer>().bounds.min);

        // Sort by position.
        // Note: Get the children from left to right.
        // We would need to add a few conditions to handle
        // all the possible scrolling directions.
        backgroundPart = backgroundPart.OrderBy(
            t => t.position.y
        ).ToList();
        
    }

    void Update()
    {
        // Get the first object.
        // The list is ordered from left (x position) to right.
        Transform firstChild = backgroundPart.FirstOrDefault();
        Transform lastChild = backgroundPart.LastOrDefault();
        Transform midChild = backgroundPart.ElementAt(1);

        if (midChild != null)
        {
            if (Camera.main.transform.position.y > midChild.position.y + size.y/2)
            {
                // Get the last child position.
                Vector3 lastPosition = lastChild.transform.position;
                Vector3 lastSize = (lastChild.GetComponent<Renderer>().bounds.max - lastChild.GetComponent<Renderer>().bounds.min);

                // Set the position of the recyled one to be AFTER
                // the last child.
                firstChild.position = new Vector3(firstChild.position.x, lastPosition.y + lastSize.y, firstChild.position.z);

                // Set the recycled child to the last position
                // of the backgroundPart list.
                backgroundPart.Remove(firstChild);
                backgroundPart.Add(firstChild);

            }
            else if (Camera.main.transform.position.y < midChild.position.y - size.y/2)
            {
                // Get the last child position.
                Vector3 firstPosition = firstChild.transform.position;
                Vector3 firstSize = (firstChild.GetComponent<Renderer>().bounds.max - firstChild.GetComponent<Renderer>().bounds.min);

                // Set the position of the recyled one to be AFTER
                // the last child.
                // Note: Only work for horizontal scrolling currently.
                lastChild.position = new Vector3(lastChild.position.x, firstPosition.y - firstSize.y, lastChild.position.z);

                // Set the recycled child to the last position
                // of the backgroundPart list.
                backgroundPart.Remove(lastChild);
                backgroundPart.Insert(0, lastChild);
            }
        }
    }
}