using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{

    [SerializeField] float minX = 1f;
    [SerializeField] float maxX = 15f;
    [SerializeField] float screenWidthInUnits = 16f;


    //cahced ref
    GameState theGameState;
    Ball theBall; 

    // Start is called before the first frame update
    void Start()
    {
        theGameState = FindObjectOfType<GameState>();
        theBall = FindObjectOfType<Ball>();

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 paddlePos = new Vector2(transform.position.x,transform.position.y);
        paddlePos.x = Mathf.Clamp(GetXPos(), minX, maxX);
        transform.position = paddlePos;

    }

    private float GetXPos()
    {
        if (theGameState.IsAutoPlayEnabled())
        {
            return theBall.transform.position.x; 
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }
    }
}
 