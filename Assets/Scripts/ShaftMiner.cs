using System.Collections;
using UnityEngine;

public class ShaftMiner : BaseMiner
{
    [Header ("}-----Own properties-----{")]
    [SerializeField] private Transform shaftMiningLocation;
    [SerializeField] private Transform shaftDepositLocation;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            MoveMiner(shaftMiningLocation.position);
        }
    }

    protected override void CollictGold()
    {
        float collectTime = GoldCapacity / GoldPerSecond;
        StartCoroutine(IECollect(GoldCapacity ,collectTime));
    }
    protected override IEnumerator IECollect(int collectGold, float collectTime)
    {
        yield return new WaitForSeconds(collectTime);
        CurrentGold = collectGold;
        MoveMiner(shaftDepositLocation.position);
    }
}
