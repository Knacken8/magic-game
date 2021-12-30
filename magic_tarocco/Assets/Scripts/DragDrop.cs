using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DragDrop : MonoBehaviour
{
    public GameObject Canvas;
    public GameObject DropZone;
    private bool isDragging = false;
    private Vector2 startPosition;
    private GameObject startParent;
    private GameObject dropZone;
    private bool isOverDropZone;
    // Update is called once per frame
    public void Start() 
    {
        Canvas = GameObject.Find("Canvas");
        DropZone = GameObject.Find("CreatureArea");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        isOverDropZone = true;
        dropZone = collision.gameObject;
    }

    private void OnCollisionExit2D(Collision2D collision) 
    {
        dropZone = null;
    }

    public void Update()
    {
        if(isDragging)
        {
            transform.position = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            transform.SetParent(Canvas.transform, false);
        }
    }

    public void StartDrag() 
    {
        startPosition = transform.position;
        isDragging = true;
        startParent = transform.parent.gameObject;
    }

    public void EndDrag()
    {
        
        isDragging = false;
        if (isOverDropZone)
        {
            transform.SetParent(dropZone.transform, false);

        }
        else 
        {
            transform.position = startPosition;
            transform.SetParent(startParent.transform, false);
        }

    }
}
