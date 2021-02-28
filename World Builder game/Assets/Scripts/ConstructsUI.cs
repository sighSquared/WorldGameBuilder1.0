using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstructsUI : MonoBehaviour
{
    [SerializeField] private List<ConstructTypeSObj>  constructsSObjList;
    [SerializeField] private BuildingManager buildingManager;

    private Dictionary<ConstructTypeSObj, Transform> constructButtonDictionary;

    private void Awake()
    {    	
    	Transform constructButtonTemp = transform.Find("constructButtonTemp");
    	constructButtonTemp.gameObject.SetActive(false);

    	constructButtonDictionary = new Dictionary<ConstructTypeSObj, Transform>();

    	int curr_idx = 0;
    	foreach (ConstructTypeSObj constructTypeSO in constructsSObjList)
    	{
    		Transform constructButtonTrans = Instantiate(constructButtonTemp, transform);
    		constructButtonTrans.gameObject.SetActive(true);
    		
    		constructButtonTrans.GetComponent<RectTransform>().anchoredPosition += new Vector2 (curr_idx*60,0);
    		constructButtonTrans.Find("image").GetComponent<Image>().sprite = constructTypeSO.sprite;


    		//Tell building manager to build particular type
    		constructButtonTrans.GetComponent<Button>().onClick.AddListener(() => {
    			buildingManager.SetCurrentContructType(constructTypeSO);
    			UpdateSelectedVisual();

    		});

    		constructButtonDictionary[constructTypeSO] = constructButtonTrans;
    		curr_idx++;

    	}
    }

    private void Start()
    {
    	UpdateSelectedVisual();
    }

    private void UpdateSelectedVisual()
    {
    	foreach (ConstructTypeSObj constructTypeSO in constructButtonDictionary.Keys)
    	{
    		constructButtonDictionary[constructTypeSO].Find("selected").gameObject.SetActive(false);
    	}

    	ConstructTypeSObj currentConstructType = buildingManager.GetCurrentConstructType();
    	constructButtonDictionary[currentConstructType].Find("selected").gameObject.SetActive(true);
    }

}
