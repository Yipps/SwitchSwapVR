using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour {

	/// <summary>
	/// Version 1.2 30/03/2018
	/// Version 1.3 08/11/2018
	///		Added the default button option (for controller navigation)
	///		Changed sound methods to public, to be called by buttons and other scripts
	///		Changed the activate/deactivate sound methods so they would save the status
	///		Added a method to select a button by code, used for multi menu navigation in consoles
	///		Added a navigate to method, to open webpages
	/// Version 1.4 06/02/2019
	///		Added support for loading level asynchronously and loading screens
	/// Version 1.5 13/05/2019
	///		Added "restart this level" functionality,
	///		Updated GoToScene with the proper Camel notation
	///		Added the "Load menus from hierarchy", this helps create menus faster since they do not need to be added manually everytime a new menu is created
	/// This menus are the ones present on this screen, the 0th element will be the one visible at the start of the scene, all other elements will be centered, and made invisible
	/// </summary>
	public Image[] containedMenus;
	public bool debugMode;
	public bool loadMenusFromHierarchy = false;

	[Header("Sound Control")]
	public bool hasSound;
	public Sprite soundOn, soundOff;
	public Sprite musicOn, musicOff;

	public Image imageButton;

	public Button defaultButton;

	[Header("Scene Loading")]
	public Image loadBar;


	public void HideMenu(Image im){
		CanvasGroup cgm = im.GetComponent<CanvasGroup> ();
		if (cgm != null) {
			cgm.alpha = 0;
			cgm.blocksRaycasts = false;
			cgm.interactable = false;
		}
	}

	public void ShowMenu(Image im){
		if (im != null) {
			CanvasGroup cgm = im.GetComponent<CanvasGroup> ();
			if (cgm != null) {
				cgm.alpha = 1;
				cgm.blocksRaycasts = true;
				cgm.interactable = true;
			}
		}
	}

	public void InitializeMenu(Image menu){
		Vector2 pos = new Vector2 (0,0);
		if (menu != null) {
			menu.GetComponent<RectTransform> ().anchoredPosition = pos;
			HideMenu (menu);
		}
	}

	IEnumerator WaitFor(float timeToWait, string func){
		yield return new WaitForSeconds (timeToWait);
		this.SendMessage(func);
	}

	public void GoToScene(string levelName){
		
		Time.timeScale = 1.0f;
		SceneManager.LoadScene (levelName);
	}

	public void RestartThisLevel(){
		GoToScene(SceneManager.GetActiveScene().name);
	}

	public void LoadScenePretty(string sceneName){
		StartCoroutine(LoadSceneWithScreen(sceneName));
	}

	IEnumerator LoadSceneWithScreen(string levelName){
		Time.timeScale = 1.0f;
		AsyncOperation async = Application.LoadLevelAsync(levelName);
		while(!async.isDone){
			if(loadBar != null){
				loadBar.fillAmount = Mathf.Clamp01(async.progress / 0.9f);
			}
			yield return null;
		}
	}

	void Awake(){
		
	}

	public void Start () {
		if(loadMenusFromHierarchy){
			containedMenus = new  Image[transform.childCount];
			for(int i = 0; i < transform.childCount; i++){
				containedMenus[i] = transform.GetChild(i).GetComponent<Image>();
			}
		}
		
		OrganizeMenus ();

		if (!PlayerPrefs.HasKey ("HasSound")) {
			PlayerPrefs.SetInt ("HasSound", 1);
			Debug.Log("Has Sound Key created");
			PlayerPrefs.Save ();
		}

		if(defaultButton != null){
			defaultButton.Select();
		}
		SoundCheck();
	}

	public void SoundCheck () {
		if (PlayerPrefs.GetInt ("HasSound") == 1) {
			hasSound = true;
			ActivateSound ();
		} else {
			hasSound = false;
			DeactivateSound ();
		}
	}

	public bool HasSound(){
		if (PlayerPrefs.GetInt ("HasSound") == 1) {
			hasSound = true;
		} else {
			hasSound = false;
		}
		return hasSound;
	}

	public void AlternateSound(){
		hasSound = !hasSound;
		if (hasSound) {
			ActivateSound ();
		} else {
			DeactivateSound ();
		}
	}

	public void ActivateSound(){
		AudioListener.volume = 1;
		if (imageButton != null) {
			imageButton.GetComponent<Image> ().sprite = soundOff;
		}
		PlayerPrefs.SetInt ("HasSound", 1);
		PlayerPrefs.Save ();
	}

	public void DeactivateSound(){
		AudioListener.volume = 0;
		if (imageButton != null) {
			imageButton.GetComponent<Image> ().sprite = soundOn;
		}
		PlayerPrefs.SetInt ("HasSound", 0);
		PlayerPrefs.Save ();
	}

	public void OrganizeMenus (){
		if (containedMenus.Length > 0) {
			for (int i = 0; i < containedMenus.Length; i++) {
				InitializeMenu (containedMenus [i]);
			}
			ShowMenu (containedMenus [0]);
		}
		//Debug.Log("Menus are now aligned");
	}



	public void NavigateTo(string url){
		Application.OpenURL(url);
	}

	public void SelectButton(Button selectableButton){
		if(selectableButton.interactable){
			selectableButton.Select();
		}
	}

	public void QuitGame () {
		Application.Quit();
	}
}
