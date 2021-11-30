using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDController : MonoBehaviour
{
    [SerializeField] private Text textAlienCoin;

    [SerializeField] private ItemManager mgItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        UpdateRewardsUI();
    }

    void UpdateRewardsUI()
    {
        int[] rewardsCount = mgItem.GetRewardsQuantity();
        textAlienCoin.text = "x" + rewardsCount[0];
    }
}
