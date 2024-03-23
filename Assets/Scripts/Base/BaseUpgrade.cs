using System;
using UnityEngine;

public class BaseUpgrade : MonoBehaviour
{
    public static Action<int> Upgraded;

    public int CurrentLvl { get; set; }
    public float UpgradeCost { get; set; }

    [Header("Upgrades")]
    [SerializeField] protected float collectCapacityMultiplier = 2;
    [SerializeField] protected float collectPerSecondMultiplier = 2;
    [SerializeField] protected float moveSpeedMultiplier = 1.25f;

    [Header("Cost")]
    [SerializeField] protected float initialUpgradeCost = 200;
    [SerializeField] protected float upgradeCostMultiplier = 2;

    protected Shaft _shaft => GetComponent<Shaft>();
    private void Start()
    {
        CurrentLvl = 1;
        UpgradeCost = initialUpgradeCost;
    }

    public virtual void Upgrade(int upgradeAmount)
    {
        if (upgradeAmount > 0)
        {
            for (int i = 0; i < upgradeAmount; i++)
            {
                UpgradeSuccess();
                UpgradeValues();
                RunUpdate();
            }
        }
    }

    protected virtual void UpgradeSuccess()
    {
        CurrentLvl++;
        Upgraded?.Invoke(CurrentLvl); 
    }
    protected virtual void UpgradeValues()
    {
        UpgradeCost *= upgradeCostMultiplier;
    }
    protected virtual void RunUpdate()
    {
        // Upgrade logic
    }
}
