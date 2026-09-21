using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    GridCollection gridCollection;

    private void Awake()
    {
        Instance = this;
        gridCollection = GridCollection.Instance;
    }

    

}
