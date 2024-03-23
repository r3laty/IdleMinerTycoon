using UnityEngine;

public class ShaftUpgrade : BaseUpgrade
{
    protected override void RunUpdate()
    {
        if (_shaft != null)
        {
            foreach (var miner in _shaft.Miners)
            {
                miner.CollectCapacity *= (int)collectCapacityMultiplier;
                miner.CollectPerSecond *= collectPerSecondMultiplier;

                if (CurrentLvl % 10 == 0)
                {
                    miner.MoveSpeed *= moveSpeedMultiplier;
                }
            }
        }
    }
}
