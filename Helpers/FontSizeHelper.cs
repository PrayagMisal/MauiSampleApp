namespace MauiSampleApp.Helpers
{
    public class FontSizeHelper
    {
        public static double LittleSize
        {
            get
            {
                return DeviceInfo.Platform == DevicePlatform.iOS ? 11 : 12;
            }
        }

        public static double MidMediumSize
        {
            get
            {
                return DeviceInfo.Platform == DevicePlatform.iOS ? 12 : 14;
            }
        }

        public static double MediumSize
        {
            get
            {
                return DeviceInfo.Platform == DevicePlatform.iOS ? 14 : 16;
            }
        }

        public static double LargeSize
        {
            get
            {
                return DeviceInfo.Platform == DevicePlatform.iOS ? 16 : 18;
            }
        }

        public static double LargerSize
        {
            get
            {
                return DeviceInfo.Platform == DevicePlatform.iOS ? 18 : 20;
            }
        }

        public static double BigSize
        {
            get
            {
                return DeviceInfo.Platform == DevicePlatform.iOS ? 20 : 24;
            }
        }

        public static double ExtraBigSize
        {
            get
            {
                return DeviceInfo.Platform == DevicePlatform.iOS ? 24 : 32;
            }
        }

        public static double HugeSize
        {
            get
            {
                return DeviceInfo.Platform == DevicePlatform.iOS ? 32 : 48;
            }
        }
    }
}
