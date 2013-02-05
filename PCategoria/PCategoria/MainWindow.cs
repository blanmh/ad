using System;
using Gtk;
using System.Data;
using Npgsql;

public partial class MainWindow: Gtk.Window
{	
	public MainWindow (): base (Gtk.WindowType.Toplevel)
	{
		Build ();
		fillComboBox();
	}
	
	private void fillComboBox() {
		
		CellRenderer cellRenderer = new CellRendererText();
		comboBox.PackStart(cellRenderer, false);
		comboBox.AddAttribute(cellRenderer, "text", 1);
		
		ListStore listStore = new ListStore(typeof(string), typeof(string));
		
		comboBox.Model = listStore;
		
		String connectionString = 
			"Server= localhost; Database= dbprueba; User Id=dbprueba; Password = 12345";
		IDbConnection dbConnection = new NpgsqlConnection(connectionString);
		dbConnection.Open();
		
		IDbCommand dbCommand = dbConnection.CreateCommand();
		dbCommand.CommandText= "select id, nombres from categoria";
		
		IDataReader dataReader = dbCommand.ExecuteReader();
		
		while (dataReader.Read()) {
			listStore.AppendValues(dataReader["id"].ToString(), dataReader["nombres"].ToString());
		}
		
		dataReader.Close();
		dbConnection.Close();
		
	}
	
	protected void OnDeleteEvent (object sender, DeleteEventArgs a)
	{
		Application.Quit ();
		a.RetVal = true;
	}
}
