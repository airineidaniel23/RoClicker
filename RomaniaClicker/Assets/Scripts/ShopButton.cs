using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
	public GameObject UnitsBar;
	public GameObject Shop;
	int state;
    // Start is called before the first frame update
    void Start()
    {
        state = 1;
    }
	
	public void onClick(){
		if(state == 1){
			UnitsBar.transform.position = new Vector2( UnitsBar.transform.position.x - 550, UnitsBar.transform.position.y);
			Shop.transform.position = new Vector2( Shop.transform.position.x + 550, Shop.transform.position.y);
			
			state = 2;
		} else {
			UnitsBar.transform.position = new Vector2(UnitsBar.transform.position.x + 550, UnitsBar.transform.position.y);
			Shop.transform.position = new Vector2( Shop.transform.position.x - 550, Shop.transform.position.y);
			
			state = 1;
		}
		
		
	}

    // Update is called once per frame
    void Update()
    {
        
    }
}
