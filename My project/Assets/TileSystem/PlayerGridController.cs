using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class PlayerGridController : MonoBehaviour
{
    GridTransform gridTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        gridTransform = GetComponent<GridTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2Int input = new Vector2Int(0, 0);
        if (Keyboard.current.wKey.wasPressedThisFrame) {
            input.y = 1;
        }
        if (Keyboard.current.sKey.wasPressedThisFrame) {
            input.y = -1;
        }
        if (Keyboard.current.aKey.wasPressedThisFrame) {
            input.x = -1;
        }
        if (Keyboard.current.dKey.wasPressedThisFrame) {
            input.x = 1;
        }

        gridTransform.Move(input);
    }
}
