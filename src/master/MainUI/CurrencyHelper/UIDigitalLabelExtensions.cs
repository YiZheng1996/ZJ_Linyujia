using System.Runtime.CompilerServices;

namespace MainUI.CurrencyHelper
{
    public static class UIDigitalLabelExtensions
    {
        // 通用的模拟量设置
        public static void ShowSettingDialog(this UIDigitalLabel label,
            object sender,
            Form parentForm,
            string title,
            double maxValue,
            Action<double> updateOPCValue,
            string errorPrefix = null)
        {
            errorPrefix ??= title;

            try
            {
                using frmSetOutValue fs = new(Convert.ToDouble(label.Value), title, maxValue);
                VarHelper.ShowDialogWithOverlay(parentForm, fs);
                if (fs.DialogResult == DialogResult.OK)
                {
                    ControlHelper.ButtonClickAsync(sender, () =>
                    {

                        label.Value = (fs.OutValue);
                        updateOPCValue((fs.OutValue));
                    });
                }
            }
            catch (Exception ex)
            {
                MessageHelper.MessageOK(parentForm, $"{errorPrefix}：{ex.Message}");
            }
        }

        // 模拟量设置方法
        public static void ShowSettingDialog00(this UIDigitalLabel label, object sender, Form parentForm)
        {
            label.ShowSettingDialog(sender, parentForm, "水箱高液位设置", 2100,
                value =>
                {
                    OPCHelper.AOgrp.CA00 = value;

                    GetTestParams().WaterHighSet = value.ToString();
                    GetTestParams().Save();
                }, "水箱高液位设置");
        }

        public static void ShowSettingDialog01(this UIDigitalLabel label, object sender, Form parentForm)
        {
            label.ShowSettingDialog(sender, parentForm, "水箱低液位设置", 2000,
                value =>
                {
                    OPCHelper.AOgrp.CA01 = value;
                    GetTestParams().WaterLowSet = value.ToString();
                    GetTestParams().Save();
                }, "水箱低液位设置");
        }

        public static void ShowSettingDialog02(this UIDigitalLabel label, object sender, Form parentForm)
        {
            label.ShowSettingDialog(sender, parentForm, "水箱极低液位设置", 1000,
                value =>
                {
                    OPCHelper.AOgrp.CA02 = value;
                    GetTestParams().WaterVeryLowSet = value.ToString();
                    GetTestParams().Save();
                }, "水箱极低液位设置");
        }

        public static void ShowSettingDialog03(this UIDigitalLabel label, object sender, Form parentForm)
        {
            label.ShowSettingDialog(sender, parentForm, "管路流量低设置", 1000,
                value =>
                {
                    OPCHelper.AOgrp.CA03 = value;
                    GetTestParams().InternetTrafficSet = value.ToString();
                    GetTestParams().Save();
                }, "管路流量低设置");
        }


        public static void ShowSettingDialog04(this UIDigitalLabel label, object sender, Form parentForm)
        {
            label.ShowSettingDialog(sender, parentForm, "喷淋时间(S)", 10000,
                value =>
                {
                    OPCHelper.AOgrp.CA04 = Convert.ToInt32(value);
                    var config = GetTestParams();
                    if (config != null)
                    {
                        config.SprayTimeSet = value.ToString();
                        config.Save();

                    }
                }, "喷淋时间");

        }

        public static void ShowSettingDialog05(this UIDigitalLabel label, object sender, Form parentForm)
        {
            label.ShowSettingDialog(sender, parentForm, "频率1给定", 1000,
                value =>
                {
                    OPCHelper.AOgrp.CA05 = value;
                    GetTestParams().Frequency1Set = value.ToString();
                    GetTestParams().Save();
                }, "频率1给定");
        }

        public static void ShowSettingDialog06(this UIDigitalLabel label, object sender, Form parentForm)
        {
            label.ShowSettingDialog(sender, parentForm, "频率2给定", 1000,
                value =>
                {
                    OPCHelper.AOgrp.CA06 = value;
                    GetTestParams().Frequency2Set = value.ToString();
                    GetTestParams().Save();
                }, "频率2给定");
        }
        public static void ShowSettingDialog07(this UIDigitalLabel label, object sender, Form parentForm)
        {
            label.ShowSettingDialog(sender, parentForm, "压力给定", 1000,
                value =>
                {
                    OPCHelper.AOgrp.CA07 = value;
                    GetTestParams().AirSet = value.ToString();
                    GetTestParams().Save();
                }, "压力给定");
        }
        private static TestParaConfig _paraconfig;

        public static TestParaConfig GetTestParams()
        {
            try
            {
                if (_paraconfig == null)
                {
                    _paraconfig = new TestParaConfig();
                    _paraconfig.Load();
                }
            }
            catch (Exception ex)
            {
                MessageHelper.MessageOK("加载参数失败。" + ex.Message);
                return null;
            }
            return _paraconfig;
        }

    }


}
