using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
 

namespace Framework.Print.Epson.Helpers
{
    [Activity(MainLauncher = true)]
    public class MainActivity : Activity
    {
        private const int SEND_TIMEOUT = 10*1000;
        private DeviceInfo[] mDeviceList;
        private Context mContext;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            //Java.Lang.JavaSystem.Load("$APP/jni/libeposprint.so"); //Doesn't work

            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main);

            var find = (Button) FindViewById(Resource.Id.find);
            var print = (Button) FindViewById(Resource.Id.print);

            mContext = this;

            print.Click += delegate
            {
                try
                {
                    Print();
                }
                catch (EpsonIoException e)
                {
                    e.PrintStackTrace();
                    Toast.MakeText(mContext, e.ToString(), ToastLength.Long).Show();
                }
            };

            find.Click += delegate
            {
                try
                {
                    GetDevices(); //BOOM! here...
                }
                catch (EpsonIoException e)
                {
                    e.PrintStackTrace();
                    Toast.MakeText(mContext, e.ToString(), ToastLength.Long).Show();
                }
            };
        }

        private void GetDevices()
        {

            try
            {
                Finder.Start(this, DevType.Usb, "null");
            }
            catch (EpsonIoException e)
            {
                if (e.Status == IoStatus.ErrIllegal)
                {
                    Toast.MakeText(this, "SEARCH ALREADY IN PROGRESS", ToastLength.Long).Show();
                }
                else if (e.Status == IoStatus.ErrProcessing)
                {
                    Toast.MakeText(this, "COULD NOT EXECUTE PROCESS", ToastLength.Long).Show();
                }
                else if (e.Status == IoStatus.ErrParam)
                {
                    Toast.MakeText(this, "INVALID PARAMETER PASSED", ToastLength.Long).Show();
                }
                else if (e.Status == IoStatus.ErrMemory)
                {
                    Toast.MakeText(this, "COULD NOT ALLOCATE MEMORY", ToastLength.Long).Show();
                }
                else if (e.Status == IoStatus.ErrFailure)
                {
                    Toast.MakeText(this, "UNSPECIFIED ERROR", ToastLength.Long).Show();
                }
            }
        }

        private void Print()
        {
            mDeviceList = Finder.GetDeviceInfoList(Finder.FilterNone);

            var status = new int[1];

            if (mDeviceList.Length > 0)
            {
                Finder.Stop();
            }
            else
            {
                Toast.MakeText(mContext, "List is null", ToastLength.Long).Show();
            }

            String deviceName = mDeviceList[0].DeviceName;
            String printerName = mDeviceList[0].PrinterName;
            int deviceType = mDeviceList[0].DeviceType;
            String macAddress = mDeviceList[0].MacAddress;
            Print printer = new Print(ApplicationContext);

            //Log.("Device Name: " + deviceName +"\n" + "Printer Name: " + printerName + "\n" + "Device Type: " + String.valueOf(deviceType) + "\n" + "MAC: " +macAddress, "");

            try
            {

                //Print Data Builder
                var builder = new Builder("TM-U220", Builder.ModelAnk, ApplicationContext);
                builder.AddText("ESPON PRINT TEST");
                builder.AddCut(Builder.CutFeed);

//                if(builder!=null) {
//                    Log.i("BUILDER NOT NULL", "");
//                }

                //Printer Test Builder
                var confirmBuilder = new Builder("TM-U220", Builder.ModelAnk, ApplicationContext);

                //Open printer
                printer.OpenPrinter(DevType.Usb, deviceName);

                //Send Test Builder
                printer.SendData(confirmBuilder, SEND_TIMEOUT, status);

                //Check printer Status
                if ((status[0] & Com.Epson.Eposprint.Print.StOffLine) != Com.Epson.Eposprint.Print.StOffLine)
                {
                    //If online send print data
                    //Log.i("PRINTER NOT OFFLINE", "");
                    printer.SendData(builder, SEND_TIMEOUT, status);

                    //Check if data sent successfully
                    if ((status[0] & Com.Epson.Eposprint.Print.StPrintSuccess) ==
                        Com.Epson.Eposprint.Print.StPrintSuccess)
                    {
                        builder.ClearCommandBuffer();
                        Toast.MakeText(this, "DATA SENT SUCCESSFULLY", ToastLength.Long).Show();
                    }
                    printer.ClosePrinter();
                }
                else if ((status[0] & Com.Epson.Eposprint.Print.StOffLine) == Com.Epson.Eposprint.Print.StOffLine)
                {
                    Toast.MakeText(this, "PRINTER OFFLINE", ToastLength.Long).Show();
                }
                else
                {
                    Toast.MakeText(this, "OTHER PRINTER ERROR", ToastLength.Long).Show();
                }
            }
            catch (EposException e)
            {
                e.PrintStackTrace();

                Toast.MakeText(mContext, e.ToString(), ToastLength.Long).Show();
            }
        }
    }
}
