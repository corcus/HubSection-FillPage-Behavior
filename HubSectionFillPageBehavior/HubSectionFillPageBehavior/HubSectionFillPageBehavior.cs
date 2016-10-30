using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Media;
using Microsoft.Xaml.Interactivity;


namespace HubSectionFillPageBehavior
{
    public class HubSectionFillPageBehavior : DependencyObject, IBehavior
    {
        public DependencyObject AssociatedObject { get; private set; }

        public void Attach(DependencyObject associatedObject)
        {
            if (this.AssociatedObject != null)
            {
                throw new InvalidOperationException("Cannot assign to the same behavior twice.");
            }
            else if (associatedObject.GetType() != typeof(Hub))
            {
                throw new InvalidOperationException("Can only assign to Hub");
            }

            this.AssociatedObject = associatedObject;

            if (DeviceTypeHelper.GetDeviceFormFactorType() == DeviceFormFactorType.Phone)
            {
                (AssociatedObject as Hub).SizeChanged += HubSectionFillPageBehavior_SizeChanged;
                (AssociatedObject as Hub).Loaded += HubSectionFillPageBehavior_Loaded;
            }
        }

        private void HubSectionFillPageBehavior_Loaded(object sender, RoutedEventArgs e)
        {
            Hub associatedHub = this.AssociatedObject as Hub;
            associatedHub.ApplyTemplate();
            var scrollViewer = getScrollViewer(associatedHub);
            if (scrollViewer != null)
            {
                scrollViewer.HorizontalSnapPointsType = SnapPointsType.MandatorySingle;
            }
        }

        private void HubSectionFillPageBehavior_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            SetHubSectionsWidth();
        }

        private void SetHubSectionsWidth()
        {
            Hub associatedHub = this.AssociatedObject as Hub;
            for (int i = 0; i < associatedHub.Sections.Count - 1; i++)
            {
                associatedHub.Sections[i].Width = associatedHub.ActualWidth - 24; // leave some space for the next hubsection to be visible
            }
            associatedHub.Sections[associatedHub.Sections.Count - 1].Width = associatedHub.ActualWidth;
        }

        private ScrollViewer getScrollViewer(DependencyObject o)
        {
            // Return the DependencyObject if it is a ScrollViewer
            if (o is ScrollViewer)
            {
                return o as ScrollViewer;
            }

            for (int i = 0; i < VisualTreeHelper.GetChildrenCount(o); i++)
            {
                var child = VisualTreeHelper.GetChild(o, i);

                var result = getScrollViewer(child);
                if (result == null)
                {
                    continue;
                }
                else
                {
                    return result;
                }
            }
            return null;
        }


        public void Detach()
        {
            if (DeviceTypeHelper.GetDeviceFormFactorType() == DeviceFormFactorType.Phone)
            {
                (AssociatedObject as Hub).SizeChanged -= HubSectionFillPageBehavior_SizeChanged;
                (AssociatedObject as Hub).Loaded -= HubSectionFillPageBehavior_Loaded;
            }
            this.AssociatedObject = null;
        }
    }
}
