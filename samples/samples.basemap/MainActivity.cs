/* Copyright 2014 ESRI
 *
 * All rights reserved under the copyright laws of the United States
 * and applicable international laws, treaties, and conventions.
 *
 * You may freely redistribute and use this sample code, with or
 * without modification, provided you include the original copyright
 * notice and use restrictions.
 *
 * See the Sample code usage restrictions document for further information.
 *
 */

using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

using Com.Esri.Android.Map;
using Com.Esri.Android.Map.Event;
using Com.Esri.Core.Geometry;
using System.Security.Cryptography;
using Android.Locations;
using Android.Provider;
using Android.Telephony.Gsm;
using Com.Esri.Core.IO;
using Android.Test.Suitebuilder;

namespace samples.basemap
{
	[Activity (Label = "samples.basemap", MainLauncher = true, Icon = "@drawable/ic_launcher")]
	public class MainActivity : Activity
	{
		MapView mapView = null;
		IMenuItem streetsMenuItem = null;
		IMenuItem topoMenuItem = null;
		IMenuItem grayMenuItem = null;
		IMenuItem oceanMenuItem = null;

		MapOptions topoBasemap = new MapOptions(MapOptions.MapType.Topo);
		MapOptions streetBasemap = new MapOptions(MapOptions.MapType.Streets);
		MapOptions grayBasemap = new MapOptions(MapOptions.MapType.Gray);
		MapOptions oceanBasemap = new MapOptions(MapOptions.MapType.Oceans);

		Polygon currentMapExtent = null;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);
			SetContentView (Resource.Layout.Main);

			// Retrieve the map and initial extent from XML layout
			mapView = FindViewById<MapView>(Resource.Id.map);

			// Set the Esri logo to be visible, and enable map to wrap around date line.
			mapView.SetEsriLogoVisible(true);
			mapView.EnableWrapAround(true);

			// Set a listener for map status changes; this will be called when switching basemaps.
			mapView.StatusChanged += StatusChanged;
		}

		public override bool OnCreateOptionsMenu (IMenu menu)
		{
			// Inflate the menu; this adds items to the action bar if it is present.
			MenuInflater.Inflate (Resource.Menu.MainMenu, menu);

			// Get the basemap switching menu items.
			streetsMenuItem = menu.GetItem (0);
			topoMenuItem = menu.GetItem (1);
			grayMenuItem = menu.GetItem (2);
			oceanMenuItem = menu.GetItem (3);

			// Also set the topo basemap menu item to be checked, as this is the default.
			topoMenuItem.SetChecked (true);

			return true;
		}

		public override bool OnOptionsItemSelected (IMenuItem item)
		{
			// Save the current extent of the map before changing the map.
			currentMapExtent = mapView.Extent;

			// Handle menu item selection.
			switch (item.ItemId) 
			{
			case Resource.Id.World_Street_Map:
				mapView.SetMapOptions(streetBasemap);
				streetsMenuItem.SetChecked(true);
				return true;
			case Resource.Id.World_Topo:
				mapView.SetMapOptions(topoBasemap);
				topoMenuItem.SetChecked(true);
				return true;
			case Resource.Id.Gray:
				mapView.SetMapOptions(grayBasemap);
				grayMenuItem.SetChecked(true);
				return true;
			case Resource.Id.Ocean_Basemap:
				mapView.SetMapOptions(oceanBasemap);
				oceanMenuItem.SetChecked(true);
				return true;
			default:
				return this.OnOptionsItemSelected(item);
			}
		}

		protected void onPause() {
			this.OnPause();
			mapView.Pause();
		}

		protected void onResume() {
			this.OnResume();
			mapView.Unpause();
		}

		void StatusChanged (object sender, Com.Esri.Android.Map.StatusChangedEventArgs args)
		{
			if (OnStatusChangedListenerSTATUS.LayerLoaded == args.Status)
			{
				mapView.SetExtent(currentMapExtent);
			}
		}

	}
}