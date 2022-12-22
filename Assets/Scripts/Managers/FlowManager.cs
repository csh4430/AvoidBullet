using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class FlowManager : MonoBehaviour
{
    [SerializeField]
    private GameObject midBoss, finalBoss;

    [SerializeField]
    private GameObject healPrefab, soldierPrefab;
    [SerializeField]
    private GameObject moveTextPanel;
    [SerializeField]
    private GameObject endingPanel;

    private HealItemBase heal;
    private SoldierBase enemy1;
    private SoldierBase enemy2;

    private static FlowManager _instance;
    public static FlowManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType<FlowManager>();
            }
            return _instance;
        }
    }
    private PoolManager poolMgr = null;
    //0 : move tuto 1 : shoot tuto 2 : mid boss 3 : finalboss 4 : ending
    private static int step = 0;
    private Action[] stepActions;
    private void Awake()
    {
        poolMgr = GameManager.Instance.GetManager<PoolManager>();
        GameManager.Instance.GetManager<PoolManager>().CreatePool(soldierPrefab, 2);
        GameManager.Instance.GetManager<PoolManager>().CreatePool(healPrefab, 1);
    }
    private void Start()
    {
        Init();
    }
    public void Init()
    {
        stepActions[0] += MoveTuto;
        stepActions[1] += ShootTuto;
        stepActions[2] += MidBoss;
        stepActions[3] += FinalBoss;
        stepActions[4] += Ending;
    }
    public void NextStep()
    {
        stepActions[step++].Invoke();
    }
    private void MoveTuto()
    {
        moveTextPanel.SetActive(true);
    }
    private void ShootTuto()
    {
        moveTextPanel.SetActive(false);
        enemy1 = poolMgr.ReuseObject(soldierPrefab, new Vector3(1, 0.7f, 0), Quaternion.identity).GetComponent<SoldierBase>();
        enemy2 = poolMgr.ReuseObject(soldierPrefab, new Vector3(-1, 0.7f, 0), Quaternion.identity).GetComponent<SoldierBase>();
        heal = poolMgr.ReuseObject(healPrefab, new Vector3(0, 0.7f, 0), Quaternion.identity).GetComponent<HealItemBase>();
        StartCoroutine(CheckEndTuto());
    }
    private void MidBoss()
    {
        StopCoroutine(CheckEndTuto());
        Heal();
        Sound.PlayBgm(SoundType.BgmType.MidBoss);
        midBoss.SetActive(true);
    }
    private void FinalBoss()
    {
        Sound.PlayBgm(SoundType.BgmType.FinalBoss);
        Heal(50);
        finalBoss.SetActive(true);
    }
    private void Ending()
    {
        Sound.PlayBgm(SoundType.BgmType.End);
        endingPanel.SetActive(true);
    }
    private void Heal(float healAmount = 0)
    {
        PlayerBase[] players = Resources.FindObjectsOfTypeAll(typeof(PlayerBase)) as PlayerBase[];
        foreach (var player in players)
        {
            if (healAmount == 0)
                player.State.Stat.Health = player.State.Stat.MaxHealth;
            else
                player.State.Stat.Health = Math.Clamp(player.State.Stat.Health + healAmount, 0, 100);
        }
    }
    private IEnumerator CheckEndTuto()
    {
        while (true)
        {
            if (enemy1.State.NowState == StateEnum.Death && enemy2.State.NowState == StateEnum.Death && heal.State.NowState == StateEnum.Death)
            {
                NextStep();
                break;
            }
            yield return new WaitForSeconds(1f);
        }
    }
}
