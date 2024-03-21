using System.Collections;
using UnityEngine;

public class ShaftMiner : BaseMiner
{
    [Header("}-----Own properties-----{")]
    [SerializeField] private Transform shaftMiningLocation;
    [SerializeField] private Transform shaftDepositLocation;

    private Animator _animator => GetComponent<Animator>();

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.M))
        {
            _animator.SetBool("IsWalking", true);
            MoveMiner(shaftMiningLocation.position);
        }
    }

    protected override void CollectGold()
    {
        _animator.SetBool("IsWalking", false);
        float collectTime = GoldCapacity / GoldPerSecond;
        StartCoroutine(IECollect(GoldCapacity, collectTime));
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
        MoveMiner(shaftDepositLocation.position);
    }
    protected override void DepositGold()
    {
        _animator.SetBool("IsWalking", false);
        CurrentGold = 0;
        ChangeGoal();
        _animator.SetBool("IsWalking", true);
        RotateMiner(1);
        MoveMiner(shaftMiningLocation.position);
    }
}
