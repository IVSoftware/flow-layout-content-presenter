using IVSoftware.Portable.Disposable;
using System.Collections.ObjectModel;
using static Pagination.Presentation.ContentPresenterFlowLayout;

namespace Pagination
{
    public static class Extensions
    {
        public static void AddRange<T>(this ObservableCollection<T> items, IEnumerable<T> newItems)
        {
            using (AddingRange.GetToken())
            {
                foreach (var item in newItems)
                {
                    items.Add(item);
                }
            }
        }
    }
}
namespace Pagination.Presentation
{
    partial class ContentPresenterFlowLayout
    {
        internal static DisposableHost AddingRange { get; } = new DisposableHost();

        protected virtual void OnCurrentPageChanged()
        {
            if (AddingRange.IsZero())
            {
                flowLayoutPanel.SuspendLayout();
                label1.Text = $"{CurrentPage}/{MaxPage}";
                var controlIndex = 0;
                for (int index = RangeMinIndex; index < RangeMaxIndex; index++)
                {
                    ContentPresenters[controlIndex].DataContext = Items[index];
                    controlIndex++;
                }
                while (controlIndex < PageSize)
                {
                    ContentPresenters[controlIndex].DataContext = null;
                    controlIndex++;
                }
                flowLayoutPanel.ResumeLayout();
            }
            else
            {   /* G T K */
                // Events are ignored while AddRange is running.
            }
        }
    }
}
