using DG.Tweening;
using System.Collections;
using UnityEngine;


public class BaseMiner : MonoBehaviour
{
    [SerializeField] private int initialCollectCapacity = 200;
    [SerializeField] private float initialGoldPerSecond = 50;

    [SerializeField] private float initialMoveSpeed = 5;
    
    // Character skills
    public float MoveSpeed { get; set; }
    public int CollectCapacity { get; set; }
    public float CollectPerSecond { get; set; }

    // Gold
    public int CurrentGold { get; set; }

    //Collect
    public bool IsTimeToCollect { get; set; }
    private void Awake()
    {
        MoveSpeed = initialMoveSpeed;
        CollectCapacity = initialCollectCapacity;
        CollectPerSecond = initialGoldPerSecond;

        IsTimeToCollect = true;
        CurrentGold = 0;
    }
    public void MoveMiner(Vector3 newPosition)
    {
        transform.DOMove(newPosition, 10 / MoveSpeed).OnComplete((() =>
        {
            if (IsTimeToCollect)
            {
                CollectGold();
            }
            else
            {
                DepositGold();
            }
        })).Play();
    }

    protected virtual void CollectGold()
    {

    }
    protected virtual IEnumerator IECollect(int collectGold, float collectTime)
    {
        yield return null;
    }
    protected virtual void DepositGold()
    {

    }
    public void RotateMiner(int direction)
    {
        switch (direction)
        {
            case -1:
                transform.localScale = new Vector3(-1, 1, 1);
                break;

            case 1:
                transform.localScale = new Vector3(1, 1, 1);
                break;
        }
    }
    public void ChangeGoal()
    {
        IsTimeToCollect = !IsTimeToCollect;
    }
}
