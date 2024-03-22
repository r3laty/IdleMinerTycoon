using UnityEngine;

public class BaseUpgrade : MonoBehaviour
{
    public int CurrentLvl { get; set; }
    public float UpgradeCost { get; set; }

    [Header("Upgrades")]
    [SerializeField] private float collectCapacityMultiplier = 2;
    [SerializeField] private float collectPerSecondMultiplier = 2;
    [SerializeField] private float moveSpeedMultiplier = 1.25f;

    [Header("Cost")]
    [SerializeField] private float initialUpgradeCost = 200;
    [SerializeField] private float upgradeCostMultiplier = 2;

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
        // Remove gold
    }
    protected virtual void UpgradeValues()
    {
        // Update values
    }
    protected virtual void RunUpdate()
    {
        // Upgrade logic
    }
}
