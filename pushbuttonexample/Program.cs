using System;
using System.Threading;
using Microsoft.SPOT;
using Microsoft.SPOT.Hardware;
using SecretLabs.NETMF.Hardware;
using SecretLabs.NETMF.Hardware.Netduino;

namespace pushbuttonexample
{
    public class Program
    {
        private static OutputPort _led = new OutputPort(Pins.ONBOARD_LED, false);
        private static InterruptPort _pushButton = new InterruptPort(Pins.GPIO_PIN_D0, true, Port.ResistorMode.PullUp, Port.InterruptMode.InterruptEdgeBoth);

        public static void Main()
        {
            _pushButton.OnInterrupt += new NativeEventHandler(_pushButton_OnInterrupt);
            _pushButton.ClearInterrupt();

            Thread.Sleep(Timeout.Infinite);
        }

        // data1 - port
        // data2 - 0 == down 1 & 1 == up
        // time - event time
        static void _pushButton_OnInterrupt(uint data1, uint data2, DateTime time)
        {
            _led.Write(data2 == 0);
        }

    }
}
