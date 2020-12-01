using System;
using System.Windows;
using System.Windows.Controls;

namespace TollCollectorApp
{
    internal class LogDataTemplateSelector : DataTemplateSelector
    {
        public override DataTemplate SelectTemplate(object item, DependencyObject container)
        {
            var element = container as FrameworkElement;
            if (element == null)
            {
                return null;
            }

            if (item is LogItem)
            {
                return element.FindResource("LogItemTemplate") as DataTemplate;
            }
            else if (item is Exception)
            {
                return element.FindResource("ExceptionTemplate") as DataTemplate;
            }

            return null;
        }
    }
}
