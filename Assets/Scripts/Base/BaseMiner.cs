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
                CollictGold();
            }
        })).Play();
    }

    protected virtual void CollictGold()
    {

    }
    protected virtual IEnumerator IECollect(int collectGold, float collectTime)
    {
        yield return null;
    }
}
