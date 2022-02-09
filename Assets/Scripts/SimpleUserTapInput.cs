using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface SimpleUserTapInputListener
{
   void OnDirectiveTap(Vector2 direction);
}

public class SimpleUserTapInput : MonoBehaviour
{
    private Vector2 screenSize;

    private Vector3 previousTapPosition;
    SimpleUserTapInputListener listener;
    public float moveThresholdScreenPercent;
    public float sensitivity;
    public float keyboardSensitivity;

    // Update is called once per frame
    void Update()
    {
        CheckUserTap();
        CheckKeyboard();
    }

    void CheckUserTap()
    {
        if (Input.GetMouseButtonDown(0))
        {
            previousTapPosition = Input.mousePosition;
        }
        else if (Input.GetMouseButton(0))
        {
            Vector3 tapDifference = Input.mousePosition - previousTapPosition;
            tapDifference = tapDifference * sensitivity / Screen.dpi;
            tapDifference.x = Mathf.Clamp(tapDifference.x, -1, 1);
            listener.OnDirectiveTap(tapDifference);
            previousTapPosition = Input.mousePosition;
           
        }

        if (Input.GetMouseButtonUp(0))
        {
            previousTapPosition = Vector3.zero;
        }
        
    }

    public void SetListener(SimpleUserTapInputListener listener)
    {
        this.listener = listener;
    }

    public void CheckKeyboard()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            listener.OnDirectiveTap(Vector3.left * keyboardSensitivity);
        }else if (Input.GetKey(KeyCode.RightArrow))
        {
            listener.OnDirectiveTap(Vector3.right * keyboardSensitivity);
        }
    }
}