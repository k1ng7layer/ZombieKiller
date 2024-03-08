//
//  CraftSystem.cs
//
//  Author:
//       Frederic Moreau <info@unitycoach.ca>
//
//  Copyright (c) 2018 Frederic Moreau, UnityCoach (Jikkou Publishing Inc.)

using System.Collections.Generic;
using UnityCoach.GamePadNavigation;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class Item
{
	public Sprite icon;
	public string name;
	[TextArea (3, 10)]
	public string description;
	public List<string> categories;
}

/// <summary>
/// Craft system demo.
/// </summary>
public class CraftSystem : MonoBehaviour
{
	public List<Item> items;

//	public Button categoryButtonReference;
	public SelectionGroup inventorySelector;
	public ScrollingListItemView categoryButtonReference;
	public Button itemButtonReference;
	public ScrollingListView categoriesView;
	public SelectionScrollView itemsView;
	public Text descriptionText;

	private Dictionary<string, List<Item>> itemsByCategory;
	private List<string> categories;
	private Dictionary <Item, GameObject> itemsGameObjects;

	private void Start ()
	{
		itemsByCategory = new Dictionary<string, List<Item>> ();
		itemsGameObjects = new Dictionary<Item, GameObject> ();
		categories = new List<string>();

		foreach (Item i in items)
		{
			foreach (string c in i.categories)
			{
				if (!itemsByCategory.ContainsKey(c))
				{
					itemsByCategory.Add(c, new List<Item>());
					categories.Add(c);
				}
				
				itemsByCategory[c].Add(i);
			}
		}

		foreach (string c in itemsByCategory.Keys)
		{
			GameObject catObject = (GameObject) Instantiate (categoryButtonReference.gameObject, categoriesView.Content);
			catObject.GetComponentInChildren<Text>().text = c;
		}

		foreach (Item i in items)
		{
			GameObject itemObject = (GameObject) Instantiate (itemButtonReference.gameObject, itemsView.Content);
			itemsGameObjects.Add (i, itemObject);
			itemObject.GetComponentInChildren<Text>().text = i.name;
			itemObject.SetActive (false);
		}

		categoriesView.SelectionChanged += CategoriesView_SelectionChanged;
		itemsView.SelectionChanged += ItemsView_SelectionChanged;
		itemsView.SelectionSubmitted += ItemsView_SelectionSubmitted;

		categoriesView.Init ();
		categoriesView.Select ();

		UpdateItemView ();

		inventorySelector.Init ();
	}

	private void OnDestroy ()
	{
		categoriesView.SelectionChanged -= CategoriesView_SelectionChanged;
		itemsView.SelectionChanged -= ItemsView_SelectionChanged;
		itemsView.SelectionSubmitted -= ItemsView_SelectionSubmitted;
	}

	private void UpdateItemView ()
	{
		foreach (GameObject g in itemsGameObjects.Values)
			g.SetActive (false);

		string c = categories[categoriesView.Selection];
		foreach (Item i in itemsByCategory[c])
		{
			itemsGameObjects[i].SetActive(true);
		}
		itemsView.Init ();
	}

	void ItemsView_SelectionSubmitted (int selection)
	{
		
	}

	void ItemsView_SelectionChanged (int selection)
	{
		descriptionText.text = itemsByCategory[categories[categoriesView.Selection]][selection].description;
	}

	void CategoriesView_SelectionChanged (int selection)
	{
		UpdateItemView ();
		descriptionText.text = "Select an Item";
	}
}