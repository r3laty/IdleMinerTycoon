using System.Collections.Generic;
using UnityEngine;

public class Shaft : MonoBehaviour
{
    [Header("Prefabs")]
    [SerializeField] private ShaftMiner minerPrefab;
    [SerializeField] private Deposit depositPrefab;

    [Header("Locations")]
    [SerializeField] private Transform miningLocation;
    [SerializeField] private Transform depositLocation;
    [SerializeField] private Transform depositInstatiatePosition;

    [HideInInspector] public Deposit CurrentDeposit;
    [HideInInspector] public List<ShaftMiner> Miners => _miners;

    private List<ShaftMiner> _miners = new List<ShaftMiner>();
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

        _miners.Add(newMiner);
    }
    private void CreateDepositBox()
    {
        CurrentDeposit = Instantiate(depositPrefab, depositInstatiatePosition.position, Quaternion.identity);
        CurrentDeposit.transform.SetParent(depositInstatiatePosition);
    }
}
