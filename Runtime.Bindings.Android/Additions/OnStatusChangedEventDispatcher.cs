using System;
using Java.Nio;
using Com.Esri.Android.Map.Event;

namespace Com.Esri.Android.Map
{

	internal partial class OnStatusChangedEventDispatcher : Java.Lang.Object, IOnStatusChangedListener
	{
		MapView sender;

		public OnStatusChangedEventDispatcher(MapView sender)
		{
			this.sender = sender;
		}

		internal EventHandler<StatusChangedEventArgs> StatusChanged;

		public void OnStatusChanged (Java.Lang.Object sender, Com.Esri.Android.Map.Event.OnStatusChangedListenerSTATUS status)
		{
			var h = StatusChanged;
			if (h != null)
				h(sender, new StatusChangedEventArgs() { Status = status });
		}
	}

	public class StatusChangedEventArgs : EventArgs
	{
		public OnStatusChangedListenerSTATUS Status { get; internal set; }
	}

	public partial class MapView
	{
		private WeakReference statusChangedDispatcher;

		private OnStatusChangedEventDispatcher StatusChangedEventDispatcher
		{
			get
			{
				if (statusChangedDispatcher == null || !statusChangedDispatcher.IsAlive)
				{
					var d = new	OnStatusChangedEventDispatcher(this);
					OnStatusChangedListener = d;
					statusChangedDispatcher = new WeakReference(d);
				}
				return(OnStatusChangedEventDispatcher)	statusChangedDispatcher.Target;
			}
		}

		public event EventHandler<StatusChangedEventArgs> StatusChanged
		{
			add
			{
				StatusChangedEventDispatcher.StatusChanged += value;
			}

			remove
			{
				StatusChangedEventDispatcher.StatusChanged -= value;
			}
		}
	}
}