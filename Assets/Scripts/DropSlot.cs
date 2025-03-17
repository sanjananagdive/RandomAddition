using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DropSlot : MonoBehaviour, IDropHandler
{

    public static DropSlot instance;
    public bool correctlyPlaced = false;


    public bool isCorrect=false;


    private void Awake()
    {
        if(instance==null)
        {
            instance=this;
        }
    }


    public void OnDrop(PointerEventData eventData)
    {
        Debug.Log("OnDrop");

        DraggableItem draggedItem = eventData.pointerDrag.GetComponent<DraggableItem>();

        if(draggedItem != null)
        {
            Debug.Log("Item dropped: " + draggedItem.name);

            Transform childObject = draggedItem.transform.GetChild(0);

           // bool isCorrect= draggedItem.canBeDropped;


            if(childObject.CompareTag("correct"))
            {
                GameAudioMnagaer.instance.PlayDroppedAudio();
                Debug.Log("Correct placement");
                draggedItem.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
                correctlyPlaced = true;



                ScoreManagerScript.instance.IncrementScore();



                //AudioManagerScript.instance.PlaySelectAudio();


            }
            else if(childObject.CompareTag("incorrect"))
            {
                ScoreManagerScript.instance.DecrementScore();
            }
            else
            {
                Debug.Log("Incorrect placement, resetting position");
                draggedItem.ResetPos();
            }
            
            
           // eventData.pointerDrag.GetComponent<RectTransform>().anchoredPosition = GetComponent<RectTransform>().anchoredPosition;
        }
        else
        {
            Debug.Log("No draggable item found");
        }
        
    }

    

    
}
