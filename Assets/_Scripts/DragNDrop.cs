using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
/**
 * Authors: Anmoldeep Singh Gill
 *          Chadwick Lapis
 *          Mohammad Bakir
 * Last Modified on: 4th Apr 2020
 */
public class DragNDrop : MonoBehaviour, IBeginDragHandler, IEndDragHandler, IDragHandler
{
    public GameObject itemDragged;
    public CanvasGroup canvasGroup;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        //Debug.Log("begin drag");
        GameData.objectSelected = eventData.selectedObject;
        canvasGroup.blocksRaycasts = false;
        //Debug.Log(eventData.pointerDrag);
    }

    public void OnDrag(PointerEventData eventData)
    {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("drag ended");
        canvasGroup.blocksRaycasts = true;
        transform.localPosition = Vector3.zero;
    }

    //public void OnPointerDown(PointerEventData eventData)
    //{
    //    Debug.Log("pointer pressed down");
    //}

}
