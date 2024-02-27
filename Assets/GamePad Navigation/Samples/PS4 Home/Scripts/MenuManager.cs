//
//  MenuManager.cs
//
//  Author:
//       Frederic Moreau <info@unitycoach.ca>
//
//  Copyright (c) 2018 Frederic Moreau, UnityCoach (Jikkou Publishing Inc.)

using System.Collections.Generic;
using UnityCoach.GamePadNavigation;
using UnityCoach.UI;
using UnityEngine;
using UnityEngine.UI;

namespace PS4Home
{
	/// <summary>
	/// PS4 Demo Menu Manager.
	/// </summary>
	public class MenuManager : MonoBehaviour
	{
		[Header ("Top - Menu")]
		[SerializeField] Button buttonObject;
		[SerializeField] ScrollRect textScrollRectObject;
		[SerializeField] SelectionScrollView menuSSV;

		List<GameObject> buttonItems;
		List<GameObject> textItems;
		List<GameObject> autoHideButtonItems;
		List<GameObject> ribbonButtons;

		[Header ("Top - Content")]
		[SerializeField] Text titleField;
		[SerializeField] Text descriptionField;

		[Header ("Ribbon - Menu")]
		[SerializeField] Button ribbonItemObject;
		[SerializeField] SelectionScrollView ribbonSSV;
		SelectionGroup ribbonSelector;

		[Header ("Bottom - Content")]
//		[SerializeField] Text bTitleField;
		[SerializeField] Text bDescriptionField;

		[Header ("Sub Category - Menu")]
		[SerializeField] SelectionGroup subCategorySelector;

		[Header ("Background")]
		[SerializeField] GradientImage _gradientImage;
		[SerializeField] Gradient _topGradient;
		[SerializeField] Gradient _ribbonDefaultGradient;

		private List<MenuItem> menuItems;
		private List<RibbonItem> ribbonItems;
		void Awake ()
		{
			buttonItems = new List<GameObject> ();
			textItems = new List<GameObject> ();
			autoHideButtonItems = new List<GameObject> ();
			ribbonButtons = new List<GameObject> ();

			menuItems = new List<MenuItem> (Resources.LoadAll<MenuItem>(""));
			ribbonItems = new List<RibbonItem> (Resources.LoadAll<RibbonItem>(""));

			foreach (MenuItem item in menuItems)
			{
				GameObject o = Instantiate (buttonObject.gameObject, menuSSV.Content);
				o.transform.Find("Image").GetComponent<Image>().sprite = item.icon;

				if (item.hideByDefault)
				{
					o.SetActive (false);
					autoHideButtonItems.Add (o);
				}
				else
				{
					buttonItems.Add (o);
				}

				if (item.text != string.Empty)
				{
					GameObject t = Instantiate (textScrollRectObject.gameObject, menuSSV.Content);
					t.GetComponentInChildren<Text>().text = item.text;
					textItems.Add (t);
				}
			}

			foreach (RibbonItem rItem in ribbonItems)
			{
				GameObject o = Instantiate (ribbonItemObject.gameObject, ribbonSSV.Content);
				o.GetComponentInChildren<RawImage>().texture = rItem.thumbnail;

				if (rItem.type == RibbonItem.Type.Simple)
					o.transform.Find("SubPanel").transform.Find("Text").gameObject.SetActive(true);
				else
					o.transform.Find("SubPanel").transform.Find("Icon").gameObject.SetActive(true);
				ribbonButtons.Add(o);
			}
		}

		void Start ()
		{
			// pre-selecting Ribbon Item before Initialisation
			ribbonButtons[1].GetComponent<Selectable>().Select();

			menuSSV.ViewInitialised += MenuSSV_ViewInitialised;
			menuSSV.Init(true);
			
			menuSSV.SelectionChanged += MenuSSV_SelectionChanged;

			SelectionGroup sub = menuSSV.GetComponent<SelectionGroup>();
			sub.Init();
			sub.SelectionEnter += MenuEntered;
			sub.SelectionExit += MenuExit;

			ribbonSSV.Init();
			ribbonSelector = ribbonSSV.GetComponent<SelectionGroup>();
			ribbonSelector.SelectorInitialised += RibbonSelector_SelectorInitialised;
			ribbonSelector.SelectionEnter += RibbonSelector_SelectionEnter;
			ribbonSelector.Init();

			ribbonSSV.SelectionChanged += RibbonSSV_SelectionChanged;
			ribbonSSV.SelectionSubmitted += RibbonSSV_SelectionSubmitted;
		}

		void RibbonSSV_SelectionSubmitted (int selection)
		{
			if (ribbonItems[selection].type == RibbonItem.Type.SubCategory)
				subCategorySelector.Enter();
			else
				UnityEngine.SceneManagement.SceneManager.LoadScene(ribbonItems[selection].sceneName);
//				Debug.Log (string.Format("Ribbon Item {0} Launched", ribbonItems[selection].name));
		}

		void RibbonSSV_SelectionChanged (int selection)
		{
			_gradientImage.gradient = ribbonItems[selection].gradient;

			if (ribbonItems[selection].type == RibbonItem.Type.SubCategory)
			{
				bDescriptionField.enabled = false;
				subCategorySelector.gameObject.SetActive (true);
			}
			else
			{
				subCategorySelector.gameObject.SetActive (false);
				bDescriptionField.text = ribbonItems[selection].description;
				bDescriptionField.enabled = true;
			}
		}

		void RibbonSelector_SelectionEnter ()
		{
//			_gradientImage.gradient = _ribbonDefaultGradient;
			_gradientImage.gradient = ribbonItems[ribbonSSV.Selection].gradient;
		}

		void RibbonSelector_SelectorInitialised ()
		{
			for (int i = 0 ; i < ribbonItems.Count ; i++)
			{
				if (ribbonItems[i].type == RibbonItem.Type.SubCategory)
				{
					SelectionGroupElement sse = ribbonButtons[i].GetComponent<SelectionGroupElement>();
					sse.autoExitNavigationMode = Navigation.Mode.Explicit;
					sse.exitUp = true;
					sse.exitDown = true;
					sse.autoExitNavigationOverride = true;
				}
			}
		}

		void MenuSSV_ViewInitialised ()
		{
			menuSSV.Selection = 0;
			titleField.text = menuItems[menuSSV.Selection].title;
			descriptionField.text = menuItems[menuSSV.Selection].description;
		}

		void MenuExit ()
		{
			foreach (GameObject t in textItems)
				t.SetActive(true);

			foreach (GameObject b in autoHideButtonItems)
				b.SetActive(false);
		}

		void MenuSSV_SelectionChanged (int selection)
		{
			titleField.text = menuItems[selection].title;
			descriptionField.text = menuItems[selection].description;
		}

		void MenuEntered ()
		{
			foreach (GameObject t in textItems)
				t.SetActive(false);

//			BaseEventData data = new BaseEventData (EventSystem.current);

			foreach (GameObject b in autoHideButtonItems)
			{
				b.SetActive(true);
//				ExecuteEvents.Execute (b, data, ExecuteEvents.deselectHandler); // FIXME : highlighted objects when selector left will stay highlighted
			}

			_gradientImage.gradient = _topGradient;
		}
	}
}