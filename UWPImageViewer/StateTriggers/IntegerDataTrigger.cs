using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;

namespace UWPImageViewer.StateTriggers
{
    public class IntegerDataTrigger : StateTriggerBase
    {
        #region DataValue
        public static int GetDataValue(DependencyObject obj)
        {
            return (int)obj.GetValue(DataValueProperty);
        }

        public static void SetDataValue(DependencyObject obj, int value)
        {
            obj.SetValue(DataValueProperty, value);
        }

        public static readonly DependencyProperty DataValueProperty =
            DependencyProperty.RegisterAttached("DataValue", typeof(int),
                typeof(IntegerDataTrigger), new PropertyMetadata(0, DataValueChanged));

        private static void DataValueChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            int triggerValue = (int)target.GetValue(TriggerValueProperty);
            TriggerStateCheck(target, (int)e.NewValue, triggerValue);
        }

        #endregion
        #region TriggerValue
        public static int GetTriggerValue(DependencyObject obj)
        {
            return (int)obj.GetValue(TriggerValueProperty);
        }

        public static void SetTriggerValue(DependencyObject obj, int value)
        {
            obj.SetValue(TriggerValueProperty, value);
        }

        // Using a DependencyProperty as the backing store for TriggerValue.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TriggerValueProperty =
            DependencyProperty.RegisterAttached("TriggerValue", typeof(int),
                typeof(IntegerDataTrigger), new PropertyMetadata(0, TriggerValueChanged));

        private static void TriggerValueChanged(DependencyObject target, DependencyPropertyChangedEventArgs e)
        {
            int dataValue = (int)target.GetValue(DataValueProperty);
            TriggerStateCheck(target, dataValue, (int)e.NewValue);
        }
        #endregion

        private static void TriggerStateCheck(DependencyObject target, int dataValue, int triggerValue)
        {
            IntegerDataTrigger trigger = target as IntegerDataTrigger;
            if (trigger == null) return;
            trigger.SetActive(triggerValue == dataValue);
        }
    }
}
