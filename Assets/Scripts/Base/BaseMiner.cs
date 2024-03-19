using DG.Tweening;
using System.Collections;
using UnityEngine;


public class BaseMiner : MonoBehaviour
{
    [HideInInspector] public int GoldCapacity = 200;
    [HideInInspector] public float GoldPerSecond = 50;

    [SerializeField] private float moveSpeed = 5;

    public int CurrentGold { get; set; }
    public bool IsTimeToCollect { get; set; }
    private void Awake()
    {
        IsTimeToCollect = true;
        CurrentGold = 0;
    }
    public void MoveMiner(Vector3 newPosition)
    {
        transform.DOMove(newPosition, 10 / moveSpeed).OnComplete((() =>
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
