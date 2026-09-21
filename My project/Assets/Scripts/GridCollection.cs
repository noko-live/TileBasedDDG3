using UnityEngine;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine.InputSystem;
using UnityEngine.EventSystems;

public class GridCollection : MonoBehaviour
{
    public static GridCollection Instance;

    public List<GameObject> InventoryList;
    public List<GameObject> MapInvList;
    public List<GameObject> MapGridList;
    public List<GameObject> ItemHeldList;


    [SerializeField] GameObject InvetoryParent;
    [SerializeField] GameObject MapInvParent;
    [SerializeField] GameObject MapGridParent;
    [SerializeField] GameObject ItemHeldParent;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        FillList(InventoryList, InvetoryParent);
        FillList(MapInvList, MapInvParent);
        FillList(MapGridList, MapGridParent);
        FillList(ItemHeldList, ItemHeldParent);
    }

    public void FillList(List<GameObject> gameobjList, GameObject parent)
    {
        gameobjList.Clear();

        for(int i = 0; i < parent.transform.childCount; i++)
        {
            GameObject child = parent.transform.GetChild(i).gameObject;
            gameobjList.Add(child);

            //Debug.Log(i + " run off array. Slotting" + parent.transform.GetChild(i).gameObject + " into " + gameobjList);
        }
        Debug.Log(gameobjList + "list filled.");
    }





}
