package md58ad980f9ccdca464748eb55e3c3d492a;


public class GUI
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("Calculator.GUI, Calculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", GUI.class, __md_methods);
	}


	public GUI () throws java.lang.Throwable
	{
		super ();
		if (getClass () == GUI.class)
			mono.android.TypeManager.Activate ("Calculator.GUI, Calculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
