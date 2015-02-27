using System;
using System.Runtime.CompilerServices;
using Android.Locations;
using Javax.Xml.Validation;
using Android.Views.InputMethods;
using Android.Provider;
using Android.Widget;
using Org.Apache.Http.Util;
using Java.Util;
using Android.Nfc;
using Android.Runtime;

namespace Com.Esri.Android.Map.Popup
{
	partial class ArcGISEditAttributesAdapter
	{
		internal protected partial class RangeSpinnerAdapter{

			static IntPtr n_GetItem_I (IntPtr jnienv, IntPtr native__this, int p0)
			{
				global::Com.Esri.Android.Map.Popup.ArcGISEditAttributesAdapter.CodedValueSpinnerAdapter __this = global::Java.Lang.Object.GetObject<global::Com.Esri.Android.Map.Popup.ArcGISEditAttributesAdapter.CodedValueSpinnerAdapter> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.NewString ((string)__this.GetItem (p0));
			}
			#pragma warning restore 0169

			static IntPtr id_getItem_I;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.esri.android.map.popup']/class[@name='ArcGISEditAttributesAdapter.CodedValueSpinnerAdapter']/method[@name='getItem' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("getItem", "(I)Ljava/lang/String;", "GetGetItem_IHandler")]
			public override  global::Java.Lang.Object GetItem (int p0)
			{
				if (id_getItem_I == IntPtr.Zero)
					id_getItem_I = JNIEnv.GetMethodID (class_ref, "getItem", "(I)Ljava/lang/String;");

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod  (Handle, id_getItem_I, new JValue (p0)), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getItem", "(I)Ljava/lang/String;"), new JValue (p0)), JniHandleOwnership.TransferLocalRef);
			}
		}

		internal protected partial class CodedValueSpinnerAdapter{

			static IntPtr n_GetItem_I (IntPtr jnienv, IntPtr native__this, int p0)
			{
				global::Com.Esri.Android.Map.Popup.ArcGISEditAttributesAdapter.CodedValueSpinnerAdapter __this = global::Java.Lang.Object.GetObject<global::Com.Esri.Android.Map.Popup.ArcGISEditAttributesAdapter.CodedValueSpinnerAdapter> (jnienv, native__this, JniHandleOwnership.DoNotTransfer);
				return JNIEnv.NewString ((string)__this.GetItem (p0));
			}
			#pragma warning restore 0169

			static IntPtr id_getItem_I;
			// Metadata.xml XPath method reference: path="/api/package[@name='com.esri.android.map.popup']/class[@name='ArcGISEditAttributesAdapter.CodedValueSpinnerAdapter']/method[@name='getItem' and count(parameter)=1 and parameter[1][@type='int']]"
			[Register ("getItem", "(I)Ljava/lang/String;", "GetGetItem_IHandler")]
			public virtual global::Java.Lang.Object GetItem (int p0)
			{
				if (id_getItem_I == IntPtr.Zero)
					id_getItem_I = JNIEnv.GetMethodID (class_ref, "getItem", "(I)Ljava/lang/String;");

				if (GetType () == ThresholdType)
					return JNIEnv.GetString (JNIEnv.CallObjectMethod  (Handle, id_getItem_I, new JValue (p0)), JniHandleOwnership.TransferLocalRef);
				else
					return JNIEnv.GetString (JNIEnv.CallNonvirtualObjectMethod  (Handle, ThresholdClass, JNIEnv.GetMethodID (ThresholdClass, "getItem", "(I)Ljava/lang/String;"), new JValue (p0)), JniHandleOwnership.TransferLocalRef);
			}
		}
	}
}
