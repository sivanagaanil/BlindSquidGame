using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipManager : MonoBehaviour
{
    Vector2 firstPressPos;
    Vector2 secondPressPos;
    Vector2 currentSwipe;

    //Declare a Delegate
    public delegate void OnswipRight();
    public static event OnswipRight onSwipRight;

    private void Start()
    {
        onSwipRight += SwipRight;
        onSwipRight += Swiped;
    }

    public void SwipRight()
    {
        Debug.Log("Event SwipRight");
    }

    public void Swiped()
    {
        Debug.Log("Working");
    }

    private void Update()
    {
        Swipe();
    }

    public void Swipe()
    {
        if (Input.GetMouseButtonDown(0))
        {
            //save began touch 2d point
            firstPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        }
        if (Input.GetMouseButtonUp(0))
        {
            //save ended touch 2d point
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);

            //create vector from the two points
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);

            //normalize the 2d vector
            currentSwipe.Normalize();

            //swipe upwards
            if (currentSwipe.y > 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {

            }
       
            //swipe down
            if (currentSwipe.y < 0 && currentSwipe.x > -0.5f && currentSwipe.x < 0.5f)
            {
                Debug.Log("SwipDown");
            }
        
            //swipe left
            if (currentSwipe.x < 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {

            }
        
            //swipe right
            if (currentSwipe.x > 0 && currentSwipe.y > -0.5f && currentSwipe.y < 0.5f)
            {
                onSwipRight();
            }
        
        }
    }
}
