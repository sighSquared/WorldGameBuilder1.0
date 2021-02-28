using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    [SerializeField] private ConstructTypeSObj currentConstructType;

    private void Update()
    {
    	if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())	//When left click and not on any gameObject/UI
    	{
    		Vector3 mouseWorldPosition = Mouse3D.GetMouseWorldPosition();
    		if(CanSpawnBuilding(currentConstructType, mouseWorldPosition))
    		{
    			Instantiate(currentConstructType.prefab,mouseWorldPosition, Quaternion.identity);
    		}

    	}
        
    }

    public void SetCurrentContructType(ConstructTypeSObj constructTypeSO)
    {
    	currentConstructType = constructTypeSO;
    }

    public ConstructTypeSObj GetCurrentConstructType()
    { 
    	return currentConstructType;
    }

    private bool CanSpawnBuilding(ConstructTypeSObj constructTypeSO, Vector3 position)
	{
		BoxCollider buildingBoxCollider = constructTypeSO.prefab.GetComponent<BoxCollider>();

		
		 Collider[] hitColliders = Physics.OverlapBox(position + buildingBoxCollider.center, buildingBoxCollider.size, Quaternion.identity);
		 if(hitColliders.Length > 1)
		{
			return false;
		}
		else
		{
			return true;
		}
	}

}
