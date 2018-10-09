using UnityEngine;
using System.Collections;
using System.Collections.Generic;

namespace Soomla.Store.Example {
	
	/// <summary>
	/// This class defines our game's economy, which includes virtual goods, virtual currencies
	/// and currency packs, virtual categories 
	/// </summary>
public class PurchaseCharacters : IStoreAssets{

		public const string No_Ads = "no_ads";
		
	public int GetVersion() {
		return 1;
	}
	
	// NOTE: Even if you have no use in one of these functions, you still need to
	// implement them all and just return an empty array.
	
	public VirtualCurrency[] GetCurrencies() {
		return new VirtualCurrency[]{};
	}
	
	public VirtualGood[] GetGoods() {
			return new VirtualGood[] {NO_ADS_LTVG, Coins100 , Coins500, Coins1000};
	}
	
	public VirtualCurrencyPack[] GetCurrencyPacks() {
		return new VirtualCurrencyPack[] {};
	}
	
	public VirtualCategory[] GetCategories() {
		return new VirtualCategory[]{};
	}
	
	
	// NOTE: Create non-consumable items using LifeTimeVG with PurchaseType of PurchaseWithMarket.
	public static VirtualGood NO_ADS_LTVG = new LifetimeVG(
		"No Ads",                             // Name
		"Anoying Ads? For less then a cup of coffe say goodbye to apps for good!",                       // Description
		"no_ads",                          // Item ID
		new PurchaseWithMarket(               // Purchase type (with real money $)
		No_Ads,                      		  // Product ID
	    0.99                                  // Price (in real money $)
	                       )
		);

	public static VirtualGood Coins100 = new SingleUseVG(
			"Get 100 coins!",                             // Name
			"Need some Coins? Have 100",                       // Description
			"100_coins",                          // Item ID
			new PurchaseWithMarket(               // Purchase type (with real money $)
		    "100_coins",                      	  // Product ID
		    0.99                                  // Price (in real money $)
		              )
		);

	public static VirtualGood Coins500 = new SingleUseVG(
			"Get 500 coins!",                             // Name
			"Need some Coins? Have 500. Its better than 100",                       // Description
			"500_coins",                          // Item ID
			new PurchaseWithMarket(               // Purchase type (with real money $)
		                       "500_coins",                      	  // Product ID
		                       1.50                                  // Price (in real money $)
		                       )
			);
	public static VirtualGood Coins1000 = new SingleUseVG(
			"Get 1000 coins!",                             // Name
			"Need some Coins? Have  100. Fit for all your needs.",                       // Description
			"1000_coins",                          // Item ID
			new PurchaseWithMarket(               // Purchase type (with real money $)
		       "1000_coins",                      	  // Product ID
		       1.99                                  // Price (in real money $)
		                       )
			);
	
	/** Virtual Categories **/
	}
}