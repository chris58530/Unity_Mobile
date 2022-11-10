using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.EventSystems;

public class PlanetSwipe : MonoBehaviour, IDragHandler, IEndDragHandler
{
    private Vector3 panelLocation;

    [SerializeField]
    private int currentChild = 0;
    [SerializeField]
    private Transform[] childIndex;

    [SerializeField]
    private float percentThreshold = 0.2f;

    [SerializeField]
    private float easing = 0.5f;

    [SerializeField]
    private float targetSize;


    //UI TITLE,INTRODUTION
    [SerializeField]
    private TextMeshProUGUI titleText;
    [SerializeField]
    private TextMeshProUGUI introtuctionText;


    private void Start()
    {
       


        panelLocation = transform.position;
        //titleText.text = "hello~~";
        Debug.Log(Screen.width);
    }


    public void OnDrag(PointerEventData eventData)
    {
        float difference = eventData.pressPosition.x - eventData.position.x;
        transform.position = panelLocation - new Vector3(difference, 0, 0);

    }
    public void OnEndDrag(PointerEventData eventData)
    {
        float percentage = (eventData.pressPosition.x - eventData.position.x) / Screen.width;
        if (Mathf.Abs(percentage) >= percentThreshold)
        {
            Vector3 newLocation = panelLocation;
            if (percentage > 0 && currentChild < childIndex.Length)
            {

                //newLocation = new Vector3(childIndex[currentChild].position.x, transform.position.y,0);
                newLocation += new Vector3(-Screen.width/2, 0, 0);//插在這

                currentChild++;

                Debug.Log(currentChild);
            }
            else if (percentage < 0 && currentChild > 0)
            {
                newLocation += new Vector3(Screen.width/2, 0, 0);//插在這
                currentChild--;
            }
            StartCoroutine(SmoothMove(transform.position, newLocation, easing));
            panelLocation = newLocation;
        }
        else
        {
            StartCoroutine(SmoothMove(transform.position, panelLocation, easing));

        }
    }
    IEnumerator SmoothMove(Vector3 startPos, Vector3 endPos, float seconds)
    {
        float t = 0;
        while (t <= 1.0f)
        {
            t += Time.deltaTime / seconds;
            transform.position = Vector3.Lerp(startPos, endPos, Mathf.SmoothStep(0, 1, t));
            yield return null;
        }
    }
}
