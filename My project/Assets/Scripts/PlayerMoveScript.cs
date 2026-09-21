using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;


public class PlayerMoveScript : MonoBehaviour
{
    public static PlayerMoveScript Instance;
    public Camera PlayerPOVCam;
    public GameObject player;
    float rotationAmount = 90f;
    Coroutine camTurnRoutine;
    float playerMoveAmount = 5f;

    void Awake()
    {
        Instance = this;

        if (PlayerPOVCam == null)
        {
            PlayerPOVCam = GameObject.FindGameObjectWithTag("PlayerCamera").GetComponent<Camera>() as Camera;
            Debug.Log("Checked");
        }
    }

    private void Start()
    {
        player.transform.eulerAngles = new Vector3(player.transform.eulerAngles.x, 0f, player.transform.eulerAngles.z);
    }


    [ContextMenu("MovePlayer Forward")]
    public void MoveForward()
    {
        Debug.Log("Move player forward");

        if(camTurnRoutine == null)
        {
            camTurnRoutine = StartCoroutine(MoveForwardRoutine());
        }

    }


    IEnumerator MoveForwardRoutine()
    {
        Debug.Log("Coroutine ran");

        //Code to turn camera
        Vector3 startPosition = player.transform.position;
        Vector3 targetPosition = startPosition + (player.transform.forward * playerMoveAmount);

        Debug.Log(startPosition + " , " + targetPosition);

        float duration = 1f;
        float elapsed = 0f;
        
        while (elapsed < duration)
        {

            elapsed += Time.deltaTime;

            float currentT = Mathf.Clamp01(elapsed / duration);

            Vector3 currentPos = Vector3.Lerp(startPosition, targetPosition, currentT);
            player.transform.position = currentPos;

            yield return null;
        }

        Debug.Log("Coroutine end");

        yield return new WaitForSeconds(0f);

        camTurnRoutine = null;
    }

    [ContextMenu("Turn Cam Left")]
    public void TurnCameraLeft()
    {
        Debug.Log("Camera turned Left");

        //Interupt other turn

        /*
        if (camTurnRoutine != null) {
            StopCoroutine(nameof(camTurnRoutine)); 
            camTurnRoutine = null;
            }
        */
        if (camTurnRoutine == null)
        {
            camTurnRoutine = StartCoroutine(TurnCameraRoutine(true));

        }
    }

    [ContextMenu("Turn Cam Right")]
    public void TurnCameraRight()
    {
        Debug.Log("Camera turned right");

        /*
        if (camTurnRoutine != null)
        {
            
            StopCoroutine(camTurnRoutine); 
            camTurnRoutine = null;
            
        }
        */

        if (camTurnRoutine == null)
        {
            camTurnRoutine = StartCoroutine(TurnCameraRoutine(false));

        }

    }




    IEnumerator TurnCameraRoutine(bool turnLeft)
    {
        Debug.Log("Coroutine ran");

        //Code to turn camera
        Vector3 startRotation = player.transform.eulerAngles;
        Vector3 targetRotation = startRotation;

        Debug.Log(startRotation + " , " + targetRotation);


        float duration = 1f;
        float elapsed = 0f;

        if (turnLeft)
        {
            //Turn the camera to the left
            targetRotation = new Vector3(player.transform.eulerAngles.x, player.transform.eulerAngles.y - rotationAmount, player.transform.eulerAngles.z);
        }
        else if (!turnLeft)
        {
            //Turn the camera to the right
            targetRotation = new Vector3(player.transform.eulerAngles.x, player.transform.eulerAngles.y + rotationAmount, player.transform.eulerAngles.z);
        }

        Debug.Log(startRotation + " , " + targetRotation);


        while (elapsed < duration)
        {

            elapsed += Time.deltaTime;

            float currentT = Mathf.Clamp01(elapsed / duration);

            Vector3 currentEuler = Vector3.Lerp(startRotation, targetRotation, currentT);
            player.transform.rotation = Quaternion.Euler(currentEuler);

            yield return null;
        }



        Debug.Log("Coroutine end");

        yield return new WaitForSeconds(0f);

        camTurnRoutine = null;

    }



}
