using TMPro;
using UnityEngine;

public class ShaftUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI goldCount;
    [SerializeField] private TextMeshProUGUI lvlCount;

    private Shaft _shaft => GetComponent<Shaft>();
    private string _textPattern = "Level\n";
    private void OnEnable()
    {
        ShaftUpgrade.Upgraded += UpgradeLvl;
    }
    private void Update()
    {
        goldCount.text = _shaft.CurrentDeposit.CurrentGold.ToString();
    }

    private void UpgradeLvl(int currentLvl)
    {
        lvlCount.text = _textPattern + currentLvl.ToString();
    }
    private void OnDisable()
    {
        ShaftUpgrade.Upgraded -= UpgradeLvl;
    }
}
