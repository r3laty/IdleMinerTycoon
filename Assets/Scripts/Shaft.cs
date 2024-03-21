using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaft : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] ShaftMiner minerPrefab;
    [SerializeField] Deposit depositPrefab;

    [Header("Locations")]
    [SerializeField] private Transform miningLocation;
    [SerializeField] private Transform depositLocation;
    [SerializeField] private Transform depositInstatiatePosition;

    [Space]
    [HideInInspector] public Deposit CurrentDeposit;

    private GameObject _minerContainer;
    private void Start()
    {
        _minerContainer = new GameObject("Miners");
        CreateDepositBox();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            CreateMiner();
        }
    }
    private void CreateMiner()
    {
        var newMiner = Instantiate(minerPrefab, depositLocation.position, Quaternion.identity);
        newMiner.transform.SetParent(_minerContainer.transform);

        newMiner.ShaftMiningLocation = miningLocation;
        newMiner.ShaftDepositLocation = depositLocation;

        newMiner.CurrentShaft = this;

        newMiner.GoToOre();
    }
    private void CreateDepositBox()
    {
        CurrentDeposit = Instantiate(depositPrefab, depositInstatiatePosition.position, Quaternion.identity);
        CurrentDeposit.transform.SetParent(depositInstatiatePosition);
    }
}
