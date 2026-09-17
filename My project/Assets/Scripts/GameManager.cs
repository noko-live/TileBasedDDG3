using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public Camera PlayerPOVCam;
    float rotationAmount = 90f;
    public Coroutine camTurnRoutine;

    public Vector3 temp;

    void Awake()
    {
        Instance = this;
    }

[ContextMenu("Turn Cam Left")]
    public void TurnCameraLeft()
    {
        Debug.Log("Camera turned Left");

        if (camTurnRoutine != null) {
            StopCoroutine(nameof(camTurnRoutine)); 
            camTurnRoutine = null;
            }
        camTurnRoutine = StartCoroutine(TurnCameraRoutine(true));
    }

[ContextMenu("Turn Cam Right")]
    public void TurnCameraRight()
    {
        Debug.Log("Camera turned right");

        if (camTurnRoutine != null){
            StopCoroutine(nameof(camTurnRoutine)); 
            camTurnRoutine = null;
            }
        camTurnRoutine = StartCoroutine(TurnCameraRoutine(false));
    }




    IEnumerator TurnCameraRoutine(bool turnLeft)
    {

        Debug.Log("Coroutine ran"); 

        //Code to turn camera
        Vector3 targetRotation = new Vector3(0f,0f,0f);
        Vector3 startRotation = new Vector3(PlayerPOVCam.transform.rotation.x, PlayerPOVCam.transform.rotation.y, PlayerPOVCam.transform.rotation.z);


        float duration = 1f;
        float elapsed = 0f;

        if (turnLeft)
        {
            //Turn the camera to the left
            targetRotation = new Vector3(PlayerPOVCam.transform.rotation.x, PlayerPOVCam.transform.rotation.y - rotationAmount, PlayerPOVCam.transform.rotation.z);
        }
        else if (!turnLeft)
        {
            //Turn the camera to the right
            startRotation = new Vector3(PlayerPOVCam.transform.rotation.x, PlayerPOVCam.transform.rotation.y + rotationAmount, PlayerPOVCam.transform.rotation.z);
        }

        temp = targetRotation;


        while (elapsed < duration)
        {
   
            elapsed += Time.deltaTime;

            float currentT = Mathf.Clamp01(elapsed / duration);

            PlayerPOVCam.transform.rotation = Quaternion.Euler(Vector3.Lerp(startRotation,targetRotation,currentT));

            yield return null; 
        }



        Debug.Log("Coroutine end"); 

        yield return new WaitForSeconds(0f);
    }
    



}
