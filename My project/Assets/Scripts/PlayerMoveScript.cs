using UnityEngine;
using NUnit;
using NUnit.Framework.Constraints;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;


public class PlayerMoveScript : MonoBehaviour
{
    public static PlayerMoveScript Instance;
    public Camera PlayerPOVCam;
    float rotationAmount = 90f;
    Coroutine camTurnRoutine;

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
        PlayerPOVCam.transform.eulerAngles = new Vector3(PlayerPOVCam.transform.eulerAngles.x, 90f, PlayerPOVCam.transform.eulerAngles.z);
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
        Vector3 startRotation = PlayerPOVCam.transform.eulerAngles;
        Vector3 targetRotation = startRotation;

        Debug.Log(startRotation + " , " + targetRotation);


        float duration = 1f;
        float elapsed = 0f;

        if (turnLeft)
        {
            //Turn the camera to the left
            targetRotation = new Vector3(PlayerPOVCam.transform.eulerAngles.x, PlayerPOVCam.transform.eulerAngles.y - rotationAmount, PlayerPOVCam.transform.eulerAngles.z);
        }
        else if (!turnLeft)
        {
            //Turn the camera to the right
            targetRotation = new Vector3(PlayerPOVCam.transform.eulerAngles.x, PlayerPOVCam.transform.eulerAngles.y + rotationAmount, PlayerPOVCam.transform.eulerAngles.z);
        }

        Debug.Log(startRotation + " , " + targetRotation);


        while (elapsed < duration)
        {

            elapsed += Time.deltaTime;

            float currentT = Mathf.Clamp01(elapsed / duration);

            Vector3 currentEuler = Vector3.Lerp(startRotation, targetRotation, currentT);
            PlayerPOVCam.transform.rotation = Quaternion.Euler(currentEuler);

            yield return null;
        }



        Debug.Log("Coroutine end");

        yield return new WaitForSeconds(0f);

        camTurnRoutine = null;

    }



}
