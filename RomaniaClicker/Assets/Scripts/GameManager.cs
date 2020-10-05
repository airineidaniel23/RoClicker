using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class GameManager : MonoBehaviour
{

	public Text pret1;
	public Text pret2;
	public Text pret3;
	public Text pret0;
	public Text actual1;
	public Text actual2;
	public Text actual3;
	public Text actual0;
	public Text owned0;
	public Text owned1;
	public Text owned2;
	public Text owned3;
	public Text currency;
	

	public int[, ] unitsPrice = new int[4,5 ];
	public float[ ] money = new float[5];	
	public int[, ] unitsOwned = new int[4,5];
	public int[, ] unitsBeneficiu = new int[4,5];
	public int[, ] unitsActual = new int[4,5];
	
    // Start is called before the first frame update
    void Start()
    {  
        for(int i = 0; i<4 ; i++){
			
			for(int j = 0; j < 5 ; j++){
				money[j] = 0;
				unitsOwned[i,j] = 0;
				unitsPrice[i,j] = 0;
				unitsBeneficiu[i,j] = 0;
				unitsActual[i,j] = 0;
			}
		}
		unitsPrice[0,0] = 10;
		unitsBeneficiu[0,0] = 1;
		unitsPrice[1,1] = 1;
		unitsBeneficiu[1,1] = 1;
		unitsPrice[2,2] = 100;
//		unitsBeneficiu[2,1] = 1;
		unitsPrice[3,2] = 1;
		unitsBeneficiu[3,2] = 1;
    }
	public string calculate(float[] mvalue){
		string sufix = "";
		float amount;
		for(int i = 0;i<4;i++){
			while(mvalue[i] > 1000){
				mvalue[i] -=1000;
				mvalue[i+1]++;
			}
		}
		for(int i = 4;i>=0;i--){
			if(mvalue[i] >0){
				if(i >0)
				     amount = mvalue[i] + mvalue[i-1]/1000;
				 else amount = mvalue[0];
				 if(i!=0)
				 amount = (float)Math.Round((double)amount, 2);
				else amount = (float)Math.Round((double)amount, 0);
				 if(i == 4) sufix = "" + amount + "T";
				 if(i == 3) sufix = "" + amount + "B";
				 if(i == 2) sufix = "" + amount + "M";
				 if(i == 1) sufix = "" + amount + "K";
				 if(i == 0) sufix = "" + amount;
				i = 0;
				 
			}
			
		}
		 return sufix;
		
	}

    // Update is called once per frame
    void Update()
    {   
		for(int i = 0;i<5 ;i++)
		money[i]+= (unitsActual[0,i] + unitsActual[1,i] + 
								unitsActual[2,i] + unitsActual[3,i] )* Time.deltaTime;
		
		currency.text = "Galbeni: " + calculate(money);
        
    }
}
