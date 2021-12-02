using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetController : PlayerController
{
    public override void Move()
    {
        // base.Move();
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {

            transform.position = transform.position += (new Vector3(-0.13f, 0f, 0) * myData.SideSpeedPlayer);

        }
        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {

            transform.position = transform.position += (new Vector3(0.13f, 0f, 0) * myData.SideSpeedPlayer);

        }

    }

}
