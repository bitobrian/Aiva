﻿using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Media;
using Drawing = System.Drawing;

namespace Aiva.Gui.Internal {
    public class ChatColorConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var converted = (Drawing.Color)value;

            Drawing.Color color;
            if (converted.IsEmpty) {
                Random rnd = new Random();
                color = Drawing.Color.FromArgb(rnd.Next(255), rnd.Next(255), rnd.Next(255), rnd.Next(255));
            } else {
                color = Drawing.Color.FromArgb(converted.A, converted.R, converted.G, converted.B);
            }

            return new SolidColorBrush(Color.FromArgb(color.A, color.R, color.G, color.B));
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            if (targetType == typeof(Drawing.Color)) {
                SolidColorBrush converted;
                if ((converted = value as SolidColorBrush) != null) {
                    var color = Drawing.Color.FromArgb(converted.Color.A, converted.Color.R, converted.Color.G, converted.Color.B);

                    return color;
                }
            }

            return null;
        }
    }

    public class AddSongCostCheckedConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            return !(bool)value;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            return !(bool)value;
        }
    }

    public class YoutubePlayerStateConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
            var v = (YoutubePlayerLib.YoutubePlayerState)value;

            return v == YoutubePlayerLib.YoutubePlayerState.playing;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
            //var v = (YoutubePlayerLib.YoutubePlayerState)value;

            //return v == YoutubePlayerLib.YoutubePlayerState.playing;
            return value;
        }
    }
}