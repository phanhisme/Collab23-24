using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //singleton - only one working camera
    public static CameraController instance;
    public Room currentRoom;
    public float moveSpeed; //speed when changing between rooms

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        UpdateCameraPosition();
    }

    void UpdateCameraPosition()
    {
        if (currentRoom == null)
        {
            return;
        }

        Vector3 targetPos = GetCameraTargetPosition();

        //get to the position using move towards 
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime * moveSpeed);
    }

    Vector3 GetCameraTargetPosition()
    {
        //if there is no assigned room => camera = 0
        if (currentRoom == null)
        {
            return Vector3.zero;
        }

        //get location for the camera = centre of the scene(room)
        Vector3 targetPos = currentRoom.GetRoomCentre();
        targetPos.z = transform.position.z;

        //get target position
        return targetPos;
    }

    public bool isSwitchingScene()
    {
        //Unity API: Determines whether this instance and a specified object, which must also be a PropertyName object, have the same value.
        //if target position != location of the player?
        return transform.position.Equals(GetCameraTargetPosition()) == false;
    }
}
