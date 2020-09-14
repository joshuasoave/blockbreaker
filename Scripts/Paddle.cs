using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    //configuration paramaters 
    [SerializeField] float screenWidthInUnits = 16f;
    [SerializeField] float xMin = 0f;
    [SerializeField] float xMax = 15f;

    //cached ref
    Ball theBall;
    GameSession theGameSession;

    // Start is called before the first frame update
    void Start()
    {
        theBall = FindObjectOfType<Ball>();
        theGameSession = FindObjectOfType<GameSession>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), xMin, xMax);
        transform.position = paddlePos;
    }

    private float GetXPos()
    {
        if(theGameSession.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x;
        } else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
