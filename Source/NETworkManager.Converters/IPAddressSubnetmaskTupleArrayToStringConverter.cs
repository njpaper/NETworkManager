﻿using System;
using System.ComponentModel;
using System.Globalization;
using System.Net;
using System.Windows;
using System.Windows.Data;
using NETworkManager.Models.Network;

namespace NETworkManager.Converters;

public sealed class IPAddressSubnetmaskTupleArrayToStringConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
        if (DesignerProperties.GetIsInDesignMode(new DependencyObject()))
            return "-/-";

        if (value is not Tuple<IPAddress, IPAddress>[] ipAddresses)
            return "-/-";

        var result = string.Empty;

        foreach (var ipAddr in ipAddresses)
        {
            if (!string.IsNullOrEmpty(result))
                result += Environment.NewLine;

            result += ipAddr.Item1 + "/" + Subnetmask.ConvertSubnetmaskToCidr(ipAddr.Item2);
        }

        return result;
    }

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}