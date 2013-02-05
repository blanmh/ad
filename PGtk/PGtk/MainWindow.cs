using System;
using Gtk;

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
	
	//protected void 

	
	protected void OnOpenAction1Activated (object sender, System.EventArgs e)
	{
		throw new System.NotImplementedException ();
	}



	protected void OnSaveActionActivated (object sender, System.EventArgs e)
	{
		throw new System.NotImplementedException ();
	}
}
