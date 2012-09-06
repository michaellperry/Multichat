using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Interactivity;

namespace Multichat.Behaviors
{
    public class WatermarkBehavior : Behavior<TextBlock>
    {
        public static DependencyProperty WatermarkedTextBoxProperty =
            DependencyProperty.Register(
                "WatermarkedTextBox", 
                typeof(TextBox), 
                typeof(WatermarkBehavior), 
                new PropertyMetadata(null));

        public TextBox WatermarkedTextBox
        {
            get { return (TextBox)GetValue(WatermarkedTextBoxProperty); }
            set { SetValue(WatermarkedTextBoxProperty, value); }
        }

        protected override void OnAttached()
        {
            TextBox watermarkedTextBox = WatermarkedTextBox;
            if (watermarkedTextBox != null)
            {
                watermarkedTextBox.GotFocus += WatermarkedControl_GotFocus;
                watermarkedTextBox.LostFocus += WatermarkedControl_LostFocus;
                VisibleIfTextEmpty(watermarkedTextBox);
            }
            base.OnAttached();
        }

        protected override void OnDetaching()
        {
            TextBox watermarkedTextBox = WatermarkedTextBox;
            if (watermarkedTextBox != null)
            {
                watermarkedTextBox.GotFocus -= WatermarkedControl_GotFocus;
                watermarkedTextBox.LostFocus -= WatermarkedControl_LostFocus;
            }
            base.OnDetaching();
        }

        void WatermarkedControl_GotFocus(object sender, RoutedEventArgs e)
        {
            AssociatedObject.Visibility = Visibility.Collapsed;
        }

        void WatermarkedControl_LostFocus(object sender, RoutedEventArgs e)
        {
            TextBox watermarkedTextBox = WatermarkedTextBox;
            if (watermarkedTextBox != null)
                VisibleIfTextEmpty(watermarkedTextBox);
        }

        private void VisibleIfTextEmpty(TextBox hintedControl)
        {
            AssociatedObject.Visibility = String.IsNullOrWhiteSpace(hintedControl.Text)
                ? Visibility.Visible
                : Visibility.Collapsed;
        }
    }
}
