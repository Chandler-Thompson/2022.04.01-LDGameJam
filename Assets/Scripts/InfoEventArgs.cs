using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;

public class InfoEventArgs<T> : EventArgs 
{
	public T info1;
	
	public InfoEventArgs() 
	{
		info1 = default(T);
	}
	
	public InfoEventArgs (T info)
	{
		this.info1 = info;
	}
}

public class InfoEventArgs<T0, T1> : InfoEventArgs<T0>
{
	public T1 info2;

	public InfoEventArgs() : base()
	{
		info2 = default(T1);
	}

	public InfoEventArgs (T0 info1, T1 info2) : base (info1)
	{
		this.info2 = info2;
	}
}