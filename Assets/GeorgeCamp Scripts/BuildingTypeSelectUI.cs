using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingTypeSelectUI : MonoBehaviour
{
    [SerializeField] private List<BuildingTypeSO> buildingTypeSOList;
    [SerializeField] private BuildingManager buildingManager;

    private Dictionary<BuildingTypeSO, Transform> buildingTypeDictionary;

    private void Awake()
    {
        //créer un bouton pour chaque type de batiment
        Transform buildingButtonTemplate = transform.Find("BuildingButtonTemplate");
        buildingButtonTemplate.gameObject.SetActive(false);

        buildingTypeDictionary = new Dictionary<BuildingTypeSO, Transform>();

        int index = 0;
        foreach(BuildingTypeSO buildingTypeSO in buildingTypeSOList)
        {
            Transform buildingBtnTransform = Instantiate(buildingButtonTemplate, transform);
            buildingBtnTransform.gameObject.SetActive(true);

            buildingBtnTransform.GetComponent<RectTransform>().anchoredPosition += new Vector2(index * 110, 0);
            buildingBtnTransform.Find("buttonImage").GetComponent<Image>().sprite = buildingTypeSO.sprite;

            buildingBtnTransform.GetComponent<Button>().onClick.AddListener(() =>
            {
                buildingManager.SetActiveBuildingType(buildingTypeSO);
                UpdateSelectedVisual();
            });

            buildingTypeDictionary[buildingTypeSO] = buildingBtnTransform;
            index++;
        }
    }

    private void Start()
    {
        UpdateSelectedVisual();
    }

    private void UpdateSelectedVisual()
    {
        //met a jour l'icone sélectionéee
        foreach (BuildingTypeSO buildingTypeSO in buildingTypeDictionary.Keys)
        {
            buildingTypeDictionary[buildingTypeSO].Find("Selected").gameObject.SetActive(false);
        }
        BuildingTypeSO activeBuildingType = buildingManager.GetActiveBuildingType();
        buildingTypeDictionary[activeBuildingType].Find("Selected").gameObject.SetActive(true);
    }
}
