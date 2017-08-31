using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHealth : MonoBehaviour {

	public int initialHealth = 100;
	public int currentHealth;
	public float initialEnergy = 200;
	public float currentEnergy;
	public Slider healthSlider;
	public Slider energySlider;
	public bool tired = false;

	// Use this for initialization
	void Start () {
		currentEnergy = initialEnergy;
		currentHealth = initialHealth;
		energySlider.value = currentEnergy;
		healthSlider.value = currentHealth;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void consumeEnergy(float amount)
	{
		if (currentEnergy < 20) {
			tired = true;
		} else {
			currentEnergy -= amount;
			energySlider.value = currentEnergy;
		}
	}

	public void getEnergy(float amount)
	{
		if (currentEnergy < initialEnergy) {
			currentEnergy += amount;
			energySlider.value = currentEnergy;
		}
		if (currentEnergy > 20)
			tired = false;
	}

	public void getHurt(int amount)
	{
		if (currentHealth <= amount) {
			currentHealth = 0;
			healthSlider.value = currentHealth;
			//Die
			//This part is for the trigger of death status
		} else {
			currentHealth -= amount;
			healthSlider.value = currentHealth;
		}
	}

	public void getBlood(int amount)
	{
		if (currentHealth < initialHealth) 
		{
			currentHealth += amount;
			if (currentHealth > initialHealth)
				currentHealth = initialHealth;
			healthSlider.value = currentHealth;
		}
	}

	public bool isFullEnergy()
	{
		if (currentEnergy == initialEnergy)
			return true;
		return false;
	}

	public bool isFullBlood()
	{
		if (currentHealth == initialHealth)
			return true;
		return false;
	}
}
