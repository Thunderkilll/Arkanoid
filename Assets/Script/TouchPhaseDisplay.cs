using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TouchPhaseDisplay : MonoBehaviour
{
    private Touch theTouch;

    public TMP_Text displayText;

    public float timeTouchEnded;
    public float displayTime =.5f;

    public float speed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            theTouch = Input.GetTouch(0);
            if (theTouch.phase == TouchPhase.Ended)
            {
                displayText.text = theTouch.phase.ToString();
                timeTouchEnded = Time.time;
                transform.position += Vector3.left * speed * Time.deltaTime;
            }
            else if (Time.time - timeTouchEnded > displayTime)
            {
                displayText.text = theTouch.phase.ToString();
                timeTouchEnded = Time.time;
            }
        }
        else if (Time.time - timeTouchEnded > displayTime)
        {
            displayText.text = "test";
            
        }
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            displayText.text = theTouch.phase.ToString();
            timeTouchEnded = Time.time;
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
#endif

       
    }
}
