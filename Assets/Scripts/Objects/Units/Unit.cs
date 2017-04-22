using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : baseObject {
    private Vector3 destination;

    public Vector3 Destination
    {
        get { return destination; }
        set { destination = value; }
    }


    private bool isMoving;

    public bool IsMoving
    {
        get { return isMoving; }
        set { isMoving = value; }
    }

    public Unit()
    {
        IsMoving = false;
    }
	
}
