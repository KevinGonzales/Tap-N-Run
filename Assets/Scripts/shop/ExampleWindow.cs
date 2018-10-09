using System;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Soomla.Store.Example
{                                                                                                                                               //Allows for access to Soomla API                                                                              
	public class ExampleWindow : MonoBehaviour
	{      
		void Start ()
		{   
			PlayerPrefs.GetInt ("HasNoAdsBeenBought", 0);
			PlayerPrefs.Save (); 
			

			DontDestroyOnLoad(transform.gameObject);                                                                                                        //Allows this gameObject to remain during level loads, solving restart crashes
			StoreEvents.OnSoomlaStoreInitialized += onSoomlaStoreIntitialized;                                                      //Handle the initialization of store events (calls function below - unneeded in this case)
			SoomlaStore.Initialize (new PurchaseCharacters());                                                                                           //Intialize the store
		}
		
		//this is likely unnecessary, but may be required depending on how you plan on doing IAPS
		public void onSoomlaStoreIntitialized(){
		}


		public void BuyNoAdds()
		{
		   try {
				Debug.Log("attempt to purchase");
				
				StoreInventory.BuyItem ("no_ads");                                                                          // if the purchases can be completed sucessfully
			}
			catch (Exception e)
			{                                                                                                                                                                               // if the purchase cannot be completed trigger an error message connectivity issue, IAP doesnt exist on ItunesConnect, etc...)
				Debug.Log ("SOOMLA/UNITY" + e.Message);                                                
			}

		}

		public void Buy100Coins()
		{
			try {
				Debug.Log("attempt to purchase");
				
				StoreInventory.BuyItem ("100_coins");                                                                          // if the purchases can be completed sucessfully
			}
			catch (Exception e)
			{                                                                                                                                                                               // if the purchase cannot be completed trigger an error message connectivity issue, IAP doesnt exist on ItunesConnect, etc...)
				Debug.Log ("SOOMLA/UNITY" + e.Message);                                                
			}
			
		}

		public void Buy500Coins()
		{
			try {
				Debug.Log("attempt to purchase");
				
				StoreInventory.BuyItem("500_coins");                                                                          // if the purchases can be completed sucessfully
			}
			catch (Exception e)
			{                                                                                                                                                                               // if the purchase cannot be completed trigger an error message connectivity issue, IAP doesnt exist on ItunesConnect, etc...)
				Debug.Log ("SOOMLA/UNITY" + e.Message);                                                
			}
			
		}

		public void Buy1000Coins()
		{
			try {
				Debug.Log("attempt to purchase");
				
				StoreInventory.BuyItem ("1000_coins");                                                                          // if the purchases can be completed sucessfully
			}
			catch (Exception e)
			{                                                                                                                                                                               // if the purchase cannot be completed trigger an error message connectivity issue, IAP doesnt exist on ItunesConnect, etc...)
				Debug.Log ("SOOMLA/UNITY" + e.Message);                                                
			}
			
		}



	}



	//delegates

	public class ExampleEventHandler {
		
		/// <summary>
		/// Constructor.
		/// Subscribes to potential events.
		/// </summary>
		public ExampleEventHandler () {
			StoreEvents.OnMarketPurchase += onMarketPurchase;
			StoreEvents.OnMarketRefund += onMarketRefund;
			StoreEvents.OnItemPurchased += onItemPurchased;
			StoreEvents.OnGoodEquipped += onGoodEquipped;
			StoreEvents.OnGoodUnEquipped += onGoodUnequipped;
			StoreEvents.OnGoodUpgrade += onGoodUpgrade;
			StoreEvents.OnBillingSupported += onBillingSupported;
			StoreEvents.OnBillingNotSupported += onBillingNotSupported;
			StoreEvents.OnMarketPurchaseStarted += onMarketPurchaseStarted;
			StoreEvents.OnItemPurchaseStarted += onItemPurchaseStarted;
			StoreEvents.OnCurrencyBalanceChanged += onCurrencyBalanceChanged;
			StoreEvents.OnGoodBalanceChanged += onGoodBalanceChanged;
			StoreEvents.OnMarketPurchaseCancelled += onMarketPurchaseCancelled;
			StoreEvents.OnRestoreTransactionsStarted += onRestoreTransactionsStarted;
			StoreEvents.OnRestoreTransactionsFinished += onRestoreTransactionsFinished;
			StoreEvents.OnSoomlaStoreInitialized += onSoomlaStoreInitialized;
			StoreEvents.OnUnexpectedStoreError += onUnexpectedStoreError;
			
			#if UNITY_ANDROID && !UNITY_EDITOR
			StoreEvents.OnIabServiceStarted += onIabServiceStarted;
			StoreEvents.OnIabServiceStopped += onIabServiceStopped;
			#endif
		}
		
		/// <summary>
		/// Handles unexpected errors with error code.
		/// </summary>
		/// <param name="errorCode">The error code.</param>
		public void onUnexpectedStoreError(int errorCode) {
			SoomlaUtils.LogError ("ExampleEventHandler", "error with code: " + errorCode);
		}
		
		/// <summary>
		/// Handles a market purchase event.
		/// </summary>
		/// <param name="pvi">Purchasable virtual item.</param>
		/// <param name="purchaseToken">Purchase token.</param>
		public void onMarketPurchase(PurchasableVirtualItem pvi, string payload, Dictionary<string, string> extra) 			// for ads
		{
			if (pvi.ItemId == "no_ads") 
			{
				PlayerPrefs.SetInt ("HasNoAdsBeenBought", 1);
				PlayerPrefs.Save (); 
			}

			if (pvi.ItemId == "100_coins") 
			{
					int oldCurrency = PlayerPrefs.GetInt("Currency",0);    
					PlayerPrefs.SetInt ("Currency", oldCurrency += 100);
					PlayerPrefs.Save (); 
			}

			if (pvi.ItemId == "500_coins") 
			{
				int oldCurrency = PlayerPrefs.GetInt("Currency",0);    
				PlayerPrefs.SetInt ("Currency", oldCurrency += 500);
				PlayerPrefs.Save (); 
			}

			if (pvi.ItemId == "1000_coins") 
			{
				int oldCurrency = PlayerPrefs.GetInt("Currency",0);    
				PlayerPrefs.SetInt ("Currency", oldCurrency += 1000);
				PlayerPrefs.Save (); 
			}
		}
		
		/// <summary>
		/// Handles a market refund event.
		/// </summary>
		/// <param name="pvi">Purchasable virtual item.</param>
		public void onMarketRefund(PurchasableVirtualItem pvi) {
			
		}
		
		/// <summary>
		/// Handles an item purchase event.
		/// </summary>
		/// <param name="pvi">Purchasable virtual item.</param>
		public void onItemPurchased(PurchasableVirtualItem pvi, string payload) {
			
		}
		
		/// <summary>
		/// Handles a good equipped event.
		/// </summary>
		/// <param name="good">Equippable virtual good.</param>
		public void onGoodEquipped(EquippableVG good) {
			
		}
		
		/// <summary>
		/// Handles a good unequipped event.
		/// </summary>
		/// <param name="good">Equippable virtual good.</param>
		public void onGoodUnequipped(EquippableVG good) {
			
		}
		
		/// <summary>
		/// Handles a good upgraded event.
		/// </summary>
		/// <param name="good">Virtual good that is being upgraded.</param>
		/// <param name="currentUpgrade">The current upgrade that the given virtual
		/// good is being upgraded to.</param>
		public void onGoodUpgrade(VirtualGood good, UpgradeVG currentUpgrade) {
			
		}
		
		/// <summary>
		/// Handles a billing supported event.
		/// </summary>
		public void onBillingSupported() {
			
		}
		
		/// <summary>
		/// Handles a billing NOT supported event.
		/// </summary>
		public void onBillingNotSupported() {
			
		}
		
		/// <summary>
		/// Handles a market purchase started event.
		/// </summary>
		/// <param name="pvi">Purchasable virtual item.</param>
		public void onMarketPurchaseStarted(PurchasableVirtualItem pvi) {
			
		}
		
		/// <summary>
		/// Handles an item purchase started event.
		/// </summary>
		/// <param name="pvi">Purchasable virtual item.</param>
		public void onItemPurchaseStarted(PurchasableVirtualItem pvi) {
			
		}
		
		/// <summary>
		/// Handles an item purchase cancelled event.
		/// </summary>
		/// <param name="pvi">Purchasable virtual item.</param>
		public void onMarketPurchaseCancelled(PurchasableVirtualItem pvi) {
			
		}
		
		/// <summary>
		/// Handles a currency balance changed event.
		/// </summary>
		/// <param name="virtualCurrency">Virtual currency whose balance has changed.</param>
		/// <param name="balance">Balance of the given virtual currency.</param>
		/// <param name="amountAdded">Amount added to the balance.</param>
		public void onCurrencyBalanceChanged(VirtualCurrency virtualCurrency, int balance, int amountAdded) {
			
		}
		
		/// <summary>
		/// Handles a good balance changed event.
		/// </summary>
		/// <param name="good">Virtual good whose balance has changed.</param>
		/// <param name="balance">Balance.</param>
		/// <param name="amountAdded">Amount added.</param>
		public void onGoodBalanceChanged(VirtualGood good, int balance, int amountAdded) {
			
		}
		
		/// <summary>
		/// Handles a restore Transactions process started event.
		/// </summary>
		public void onRestoreTransactionsStarted() {
			
		}
		
		/// <summary>
		/// Handles a restore transactions process finished event.
		/// </summary>
		/// <param name="success">If set to <c>true</c> success.</param>
		public void onRestoreTransactionsFinished(bool success) {
			
		}
		
		/// <summary>
		/// Handles a store controller initialized event.
		/// </summary>
		public void onSoomlaStoreInitialized() {
			
		}
		
		#if UNITY_ANDROID && !UNITY_EDITOR
		public void onIabServiceStarted() {
			
		}
		public void onIabServiceStopped() {
			
		}
		#endif
	}
}