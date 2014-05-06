using System;

public class Stock
{
	public delegate void AskPriceDelegate(object aPrice);
	public event AskPriceDelegate AskPriceChanged;
	
	object askPrice;
	public object AskPrice{
		set
		{
			askPrice = value;
			AskPriceChanged(askPrice);
		}
	}
}

public class StockDisplay
{
	public void AskPriceChanged(object aPrice)
	{
		Console.Write("The new ask price is: " + aPrice + "\r\n");
	}
}

public class MainClass
{
	public static void Main()
	{
		StockDisplay stockDisplay = new StockDisplay();
		Stock stock = new Stock();
		
		Stock.AskPriceDelegate aDelegate = new Stock.AskPriceDelegate(stockDisplay.AskPriceChanged);
		
		stock.AskPriceChanged += aDelegate;
		
		for(int looper = 0; looper < 100; looper++)
			stock.AskPrice = looper;
			
		stock.AskPriceChanged -= aDelegate;
	}
}