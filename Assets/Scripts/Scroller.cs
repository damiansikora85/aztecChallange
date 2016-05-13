using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Scroller : MonoBehaviour
{
	public float Speed = 2.5f;

	private List<Transform> backgroundPart;
	private Vector2 size;

	// Use this for initialization
	void Start ()
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

	// Update is called once per frame
	void Update()
	{
		transform.position -= new Vector3(0, Speed*Time.deltaTime, 0);

		Transform firstChild = backgroundPart.FirstOrDefault();
		Transform lastChild = backgroundPart.LastOrDefault();
		Transform midChild = backgroundPart.ElementAt(1);

		if (midChild != null)
		{
			if (Camera.main.transform.position.y > midChild.position.y + size.y / 2)
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
			else if (Camera.main.transform.position.y < midChild.position.y - size.y / 2)
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
