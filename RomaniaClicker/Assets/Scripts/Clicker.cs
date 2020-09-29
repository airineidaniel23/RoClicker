using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Clicker : MonoBehaviour
{
	public Text currency;
	public GameManager gm;
	public int[] gdp = new int[5];
    // Start is called before the first frame update
    void Start()
    {
        gdp[0] = 1;
		for(int i = 1;i<5;i++){
			gdp[i] = 0;
		}
    }
	public void OnClick(){
		gm.money[0] += gdp[0];
	}
	
	public bool buy(float[] money, int[,] price, int pos){
		

		for(int i = 0;i<5;i++){
			money[i] -= price[pos, i];
		}
		for(int i = 0;i<4;i++){
			if(money[i]<0){
				money[i]+=1000;
				money[i+1]--;
			}
		}
		for(int i = 0;i<5;i++){
			if(money[i]<0) return false;
		}
	
		return true;
	}
	
	public void reshape(int[,] array, int pos){
		for(int i = 0;i<4;i++){
			while(array[pos,i]>1000){
				array[pos,i]-=1000;
				array[pos,i+1]++;
			}
		}
		
	}
	
	public void Click0(){
		float[] initial = new float[5];
		for(int i = 0;i<5;i++) initial[i] = gm.money[i];
		if(buy(gm.money, gm.unitsPrice, 0)){
			gm.unitsOwned[0,0] = gm.unitsOwned[0,0]+1;
			//reshape(gm.unitsOwned, 0);
			for(int i = 0;i<5;i++){
				gm.unitsActual[0,i] = gm.unitsActual[0,i] + gm.unitsBeneficiu[0,i];
			}
			
			
			gm.owned0.text = "Detinuti: " + calculate(gm.unitsOwned, 0);
			gm.actual0.text = ""+calculate(gm.unitsActual,0)+" g/s";
			gm.pret0.text = "50 galbeni";
		} else {
			for(int i = 0;i<5;i++) gm.money[i] = initial[i];
		}
	}
	public void Click1(){
		float[] initial = new float[5];
		for(int i = 0;i<5;i++) initial[i] = gm.money[i];
		if(buy(gm.money, gm.unitsPrice, 1)){
			gm.unitsOwned[1,0] = gm.unitsOwned[1,0]+1;
			//reshape(gm.unitsOwned, 0);
			for(int i = 0;i<5;i++){
				gm.unitsActual[1,i] = gm.unitsActual[1,i] + gm.unitsBeneficiu[1,i];
			}
			
			
			gm.owned1.text = "Detinuti: " + calculate(gm.unitsOwned, 1);
			gm.actual1.text = ""+calculate(gm.unitsActual,1)+" g/s";
			gm.pret1.text = "50 galbeni";
		} else {
			for(int i = 0;i<5;i++) gm.money[i] = initial[i];
		}
	}



	public string calculate(int[,] mvalue,int pos){
		string sufix = "";
		float amount;
		for(int i = 0;i<4;i++){
			while(mvalue[pos, i] > 1000){
				mvalue[pos, i] -=1000;
				mvalue[pos, i+1]++;
			}
		}
		for(int i = 4;i>=0;i--){
			if(mvalue[pos, i] >0){
				if(i >0)
				     amount = mvalue[pos, i] + (float)mvalue[pos, i-1]/1000;
				 else amount = mvalue[pos, 0];
				 amount = (float)Math.Round((double)amount, 2);
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

    }
}
