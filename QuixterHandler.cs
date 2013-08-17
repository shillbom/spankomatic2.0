using System;
using System.Xml;
using System.Text;
using System.Net;
using System.IO;
using System.Web;

namespace Spankomatic
{
	public class QuixterHandler
	{
		private String url = "http://192.168.7.2:8080/";
		private HttpWebRequest request;

		public QuixterHandler()
		{
 		
		}

		public string Status()
		{
			return GetFromTerminal("status");
		}

		/*
		 * Initiate new transaction.
		 */
		public string Transaction()
		{
			string content = 
				"<request>" +
					"<amount>" +
						"0" +
					"</amount>" +
					"<message>" +
					"Testing, attention please." +
					"</message>" +
				"</request>";

			return PushToTerminal("transaction", content);
		}

		/*
		 * Refund user.
		 */
		public string ReturnTransaction()
		{
			string content = 
				"<request>" +
					"<amount>" +
						"0" +
					"</amount>" +
					"<message>" +
						"Testing returntransaction" +
					"</message>" +
				"</request>";

			return PushToTerminal("returntransaction", content);
		}

		/*
		 * Abort a ongoing transaction.
		 */
		public string Abort()
		{
			return PushToTerminal("abort", "");
		}

		/**
		 * Toggle debug mode
		 */
		public string Debug()
		{
			return PushToTerminal("debug", "");
		}

		/*
		 * List all available locations.
		 */
		public string ListLocation()
		{
			return GetFromTerminal("listlocations");
		}

		/*
		 * Pick a location.
		 */
		public string PickLocation(string location)
		{
			string content =
				"<newsalelocation>" +
					"<location>" + 
						location + 
					"</location>" +
				"</newsalelocation>";

			return PushToTerminal("picklocation", content);
		}

		/*
		 * Show current location.
		 */
		public string CurrentLocation()
		{
			return GetFromTerminal("currentlocation");
		}

		/*
		 * Show sales statistics.
		 */
		public string CurrentSales()
		{
			return GetFromTerminal("currentsales");
		}

		/*
		 * Reset sales statistics.
		 */
		public string ResetTransactions()
		{
			return PushToTerminal("resettransactions", "");
		}

		/**
		 * Sends command to the terminal to change its state,
		 * eg. start a new transaction, set it in debug mode etc.
		 */
		private string PushToTerminal(string command, string content)
		{
			request = (HttpWebRequest) WebRequest.Create(url+command);

			request.Method = "POST";
			request.ContentType = "application/xml";

			byte[] bytecontent = System.Text.Encoding.ASCII.GetBytes (content);

			request.ContentLength = bytecontent.Length;

			Stream datastream = request.GetRequestStream ();
			datastream.Write (bytecontent, 0, bytecontent.Length);
			datastream.Close ();

			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();
			datastream = response.GetResponseStream ();
			StreamReader reader = new StreamReader (datastream);

			string server_response = reader.ReadToEnd (); 

			return server_response;
		}

		/**
		 * Get information from the terminal,
		 * eg. status, listlocations etc.
		 */
		private string GetFromTerminal(string command)
		{
			request = (HttpWebRequest) WebRequest.Create(url+command);
			request.Method = "GET";

			HttpWebResponse response = (HttpWebResponse) request.GetResponse ();

			Stream datastream = response.GetResponseStream ();
			StreamReader reader = new StreamReader (datastream);

			string server_response = reader.ReadToEnd ();

			return server_response;
		}
	}
}
