using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragAndDrop : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private string tagToCheck;

    private void OnMouseDown()
    {
        if (gameObject.CompareTag("Rubbish") || gameObject.CompareTag("Recycle"))
        {
            isDragging = true;
            offset = transform.position - Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f));
            tagToCheck = gameObject.CompareTag("Rubbish") ? "RubbishBin" : "RecycleBin";
        }
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }

    private void Update()
    {
        if (isDragging)
        {
            Vector3 newPosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10.0f)) + offset;
            transform.position = newPosition;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (isDragging && other.CompareTag(tagToCheck))
        {
            gameObject.SetActive(false);
        }
    }
}
