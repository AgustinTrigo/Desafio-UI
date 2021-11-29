using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    
    [SerializeField] private PlayerController playerController;
    private Vector3 initPosition;
    private bool resetCamera;
    private float cameraSpeed;

    // Start is called before the first frame update
    void Start()
    {
        cameraSpeed = playerController.GetSpeedPlayer();
        initPosition = playerController.GetPlayerPosition();
        resetCamera = playerController.GetPlayerEstate();


        Debug.Log("velocidad del player" + cameraSpeed);
        Debug.Log("Posicion inicial  del player" + initPosition);
    }

    // Update is called once per frame
    void Update()
    {
        CameraRun(Vector3.forward);
        CameraMove();
    }

    private void CameraRun(Vector3 direction)
    {
        transform.Translate(cameraSpeed * direction * Time.deltaTime);
    }

    private void CameraMove()
    {
        if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.position = transform.position += (new Vector3(-0.5f, 0f, 0)  );
        }

        if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.position = transform.position += (new Vector3(0.5f, 0f, 0) );
        }
    }
}
