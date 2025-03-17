using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DraggableItem : MonoBehaviour,IPointerDownHandler, IBeginDragHandler, IEndDragHandler,IDragHandler
{

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private Vector2 initialPos;

    public bool isInsideDropSlot=false;

    public bool canBeDropped=false;

    public static DraggableItem instance;

    public bool myBool = false;

    private void Awake()
    {
        if(instance==null)
        {
            instance=this;
        }


        rectTransform=GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }
    private void Start()
    {
        initialPos = rectTransform.anchoredPosition;
    }

    private void Update()
    {
    
    }


   

    public void OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointerDown");
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        Debug.Log("OnEndDrag");
        canvasGroup.alpha = 1f;
        canvasGroup.blocksRaycasts = true;

        if(!DropSlot.instance.correctlyPlaced )
        {
            ResetPos();

            print("Calling reset because not placed correctly");
        }

        

        
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("OnBeginDrag");
        canvasGroup.alpha = 0.6f;
        canvasGroup.blocksRaycasts = false;
        

    }

    public void OnDrag(PointerEventData eventData)
    {
        Debug.Log("OnDrag");
        rectTransform.anchoredPosition += eventData.delta;
    }

    public void ResetPos()
    {
        GameAudioMnagaer.instance.PlaySwooshAudio();
        rectTransform.anchoredPosition = initialPos;
    }



}
