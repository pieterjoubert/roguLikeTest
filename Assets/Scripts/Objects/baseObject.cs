using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class baseObject  {

    public GameObject prefab;
    private GameObject displayObject;
    private string type;
    private bool needsUpdating;

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


    public GameObject DisplayObject
    {
        get { return displayObject; }
        set { displayObject = value; }
    }

    public bool NeedsUpdating
    {
        get { return needsUpdating; }
        set { needsUpdating = value; }
    }


    public string Type
    {
        get { return type; }
        set { type = value; }
    }

 



}
