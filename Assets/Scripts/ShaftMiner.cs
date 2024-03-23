using System.Collections;
using UnityEngine;

public class ShaftMiner : BaseMiner
{
    public Shaft CurrentShaft;

    [HideInInspector] public Transform ShaftMiningLocation;
    [HideInInspector] public Transform ShaftDepositLocation;
    
    private Shaft _currentShaft => GetComponent<Shaft>();
    private Animator _animator => GetComponent<Animator>();
    public void GoToOre()
    {
        _animator.SetBool("IsWalking", true);
        MoveMiner(ShaftMiningLocation.position);
    }

    protected override void CollectGold()
    {
        _animator.SetBool("IsWalking", false);
        float collectTime = CollectCapacity / CollectPerSecond;
        StartCoroutine(IECollect(CollectCapacity, collectTime));
    }
    protected override IEnumerator IECollect(int collectGold, float collectTime)
    {
        _animator.SetBool("IsMining", true);
        yield return new WaitForSeconds(collectTime);
        _animator.SetBool("IsMining", false);
        CurrentGold = collectGold;
        ChangeGoal();
        _animator.SetBool("IsWalking", true);
        RotateMiner(-1);
        MoveMiner(ShaftDepositLocation.position);
    }
    protected override void DepositGold()
    {
        _animator.SetBool("IsWalking", false);
        CurrentShaft.CurrentDeposit.DepositGold(CurrentGold);

        CurrentGold = 0;
        ChangeGoal();
        RotateMiner(1);
        GoToOre();
    }
}
