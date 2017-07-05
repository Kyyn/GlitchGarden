using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour {

    public GameObject defenderPrefab;
    public static GameObject selectedDefender = null;

    private Button[] buttonArray;
    private Text costText;


	// Use this for initialization
	void Start () {
        buttonArray = GameObject.FindObjectsOfType<Button>();

        costText = GetComponentInChildren<Text>();  
        if (!costText) { Debug.LogWarning(name + " has no cost text");}
        int costValue = defenderPrefab.GetComponent<Defender>().starCost; // mio
        costText.text = costValue.ToString(); // mio
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    private void OnMouseDown()
    {
        foreach (Button thisbutton in buttonArray)
        {
            thisbutton.GetComponent<SpriteRenderer>().color = Color.black;
        }
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;

        selectedDefender = defenderPrefab;
        print(selectedDefender);
    }
}
