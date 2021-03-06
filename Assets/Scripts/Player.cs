﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum Control
{
    PianoKeys,
    SixKeys
}

public class Player : MonoBehaviour {

    private RectTransform myTransform;

    public float moveSpeed = 0.1f;
    public Control controlType = Control.PianoKeys;

    
    private Vector3 targetPos = new Vector3(0, 0, 0);
    private Vector3 lastTarget = new Vector3(0, 0, 0);
    private float distnace;
    private float moveTime = 0.5f;
    private float direction = 1f;

    #region SixKeysValues
    private float majorNumDelta = 200.0f;
    private float minorNumDelta = 50.0f;
    private float majorNum = 0.0f;
    private float minorNum = 0.0f;
    #endregion

    #region LocationValues
    private Vector3 posL3 = new Vector3(-250, 0, 0);
    private Vector3 posL2 = new Vector3(-200, 0, 0);
    private Vector3 posL1 = new Vector3(-150, 0, 0);
    private Vector3 posL = new Vector3(-50, 0, 0);
    private Vector3 pos0 = new Vector3(0, 0, 0);
    private Vector3 posR = new Vector3(50, 0, 0);
    private Vector3 posR1 = new Vector3(150, 0, 0);
    private Vector3 posR2 = new Vector3(200, 0, 0);
    private Vector3 posR3 = new Vector3(250, 0, 0);
    #endregion

    // Use this for initialization
	void Start () {
        myTransform = this.gameObject.GetComponent<RectTransform>();
	}
	
	// Update is called once per frame
	void Update () {
        switch(controlType)
        {
            case Control.PianoKeys:
                PianoKeys();
                MovePlayer();
                break;

            case Control.SixKeys:
                SixKeys();
                MovePlayer();
                break;

            default:
                PianoKeys();
                MovePlayer();
                break;
        }
	}

    //Handles 6 sey system
    void SixKeys()
    {
        
        //Handles major Movement
        if(Input.GetKeyDown("a"))
        {
            majorNum = (-majorNumDelta);
        }

        if (Input.GetKeyDown("s"))
        {
            majorNum = 0.0f;
        }

        if (Input.GetKeyDown("d"))
        {
            majorNum = majorNumDelta;
        }

        //Handles minor movement
        if (Input.GetKeyDown("j"))
        {
            minorNum = (-minorNumDelta);
        }

        if (Input.GetKeyDown("k"))
        {
            minorNum = 0.0f;
        }

        if (Input.GetKeyDown("l"))
        {
            minorNum = minorNumDelta;
        }


        targetPos = new Vector3(majorNum + minorNum,0,0);

    }

    //Handles Piano Style Controls
    void PianoKeys()
    {
        if(Input.GetKeyDown("a"))
        {
            targetPos = posL3;
        }

        if (Input.GetKeyDown("s"))
        {
            targetPos = posL2;
        }

        if (Input.GetKeyDown("d"))
        {
            targetPos = posL1;
        }

        if (Input.GetKeyDown("f"))
        {
            targetPos = posL;
        }

        if (Input.GetKeyDown("g"))
        {
            targetPos = pos0;
        }

        if (Input.GetKeyDown("h"))
        {
            targetPos = posR;
        }

        if (Input.GetKeyDown("j"))
        {
            targetPos = posR1;
        }

        if (Input.GetKeyDown("k"))
        {
            targetPos = posR2;
        }

        if (Input.GetKeyDown("l"))
        {
            targetPos = posR3;
        }
    }

    //moves the player to the desired loaction
    void MovePlayer()
    {
        //Grabs current Position
        Vector3 tempPos = myTransform.localPosition;

        if(targetPos != lastTarget)
        {
            Vector3 holdPos = tempPos;

            distnace = Vector3.Distance(targetPos,holdPos);
            if(targetPos.x > tempPos.x)
            {
                direction = 1;
            }
            else
            {
                direction = -1;
            }

            lastTarget = targetPos;
        }

        float step = (distnace / moveTime) * direction;

        tempPos.x += (step * Time.deltaTime);

        if(direction == 1 && tempPos.x > targetPos.x)
        {
            tempPos = targetPos;
        }

        if (direction == (-1) && tempPos.x < targetPos.x)
        {
            tempPos = targetPos;
        }

        myTransform.localPosition = tempPos;
        
    }
}
