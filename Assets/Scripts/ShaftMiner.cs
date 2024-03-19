using System.Collections;
using UnityEngine;

public class ShaftMiner : BaseMiner
{
    [Header("}-----Own properties-----{")]
    [SerializeField] private Transform shaftMiningLocation;
    [SerializeField] private Transform shaftDepositLocation;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            // walk animation (true)
            MoveMiner(shaftMiningLocation.position);
        }
    }

    protected override void CollectGold()
    {
        // walk animation (false)
        float collectTime = GoldCapacity / GoldPerSecond;
        StartCoroutine(IECollect(GoldCapacity, collectTime));
    }
    protected override IEnumerator IECollect(int collectGold, float collectTime)
    {
        // mining animation (true)
        yield return new WaitForSeconds(collectTime);
        // mining animation (false)
        CurrentGold = collectGold;
        ChangeGoal();
        // walk animation (true)
        RotateMiner(-1);
        MoveMiner(shaftDepositLocation.position);
    }
    protected override void DepositGold()
    {
        // walk animation (false)
        CurrentGold = 0;
        ChangeGoal();
        // walk animation (true)
        RotateMiner(1);
        MoveMiner(shaftMiningLocation.position);
    }
}
