package md58ad980f9ccdca464748eb55e3c3d492a;


public class ActivityTwo
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Calculator.ActivityTwo, Calculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", ActivityTwo.class, __md_methods);
	}


	public ActivityTwo () throws java.lang.Throwable
	{
		super ();
		if (getClass () == ActivityTwo.class)
			mono.android.TypeManager.Activate ("Calculator.ActivityTwo, Calculator, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

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
