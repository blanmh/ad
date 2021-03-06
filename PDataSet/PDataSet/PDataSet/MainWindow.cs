using Gtk;
using Npgsql;
using System;
using System.Data;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
	
	protected void OnExecuteActionActivated(object sender, System.EventArgs a)
	{
		IDbConnection dbConnection = new NpgsqlConnection("Server=localhost; Database = dbprueba; User Id=dbprueba; Password= sistemas");
		IDbCommand selectCommand = dbConnection.CreateCommand();
		selectCommand.CommandText = "select * from articulo";
		IDbDataAdapter dbDataAdapter = new NpgsqlDataAdapter();
		dbDataAdapter.SelectCommand = selectCommand;
		
		
		DateSet dataSet = new DataSet();
		
		dbDataAdapter.Fill(dataSet);
		
		Console.WriteLine("Tables.Count={0}", dataSet.Tables.Count);
	}
}
