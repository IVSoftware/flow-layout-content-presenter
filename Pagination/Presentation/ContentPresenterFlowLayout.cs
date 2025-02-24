using IVSoftware.Portable.Disposable;
using Pagination.Presentation;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace Pagination.Presentation
{
    public partial class ContentPresenterFlowLayout : UserControl, INotifyPropertyChanged
    {
        const int DEFAULT_PAGE_SIZE = 10;
        private ContentPresenter[] ContentPresenters { get; set; } = [];
        public ObservableCollection<ContentPresenterViewModel> Items
        {
            get
            {
                if (_items is null)
                {
                    _items = new ObservableCollection<ContentPresenterViewModel>();
                    _items.CollectionChanged += (sender, e) =>
                    {
                        if (_items.Any())
                        {
                            _currentPage = Math.Max(1, _currentPage);
                            _currentPage = Math.Min(MaxPage, _currentPage);
                        }
                        else _currentPage = 0;
                        OnCurrentPageChanged();
                    };
                }
                return _items;
            }
        }
        ObservableCollection<ContentPresenterViewModel>? _items = default;
        public ContentPresenterFlowLayout()
        {
            InitializeComponent();
            OnPageSizeChanged();
            // Suppress collection event changes during range loads.
            AddingRange.FinalDispose += (sender, e) =>
            {
                if(InvokeRequired) BeginInvoke(() => OnCurrentPageChanged());
                else OnCurrentPageChanged();
            };
            buttonPrev.Click += (sender, e) => CurrentPage--;
            buttonNext.Click += (sender, e) => CurrentPage++;
        }

        private void OnPageSizeChanged()
        {
            flowLayoutPanel.Controls.Clear();
            ContentPresenters = Enumerable.Range(0, PageSize).Select(_=>new ContentPresenter()).ToArray();
            foreach (var cp in ContentPresenters)
            {
                flowLayoutPanel.Controls.Add(cp);
            }
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible), Browsable(true)]
        public int PageSize
        {
            get => _pageSize;
            set
            {
                value = Math.Max(value, 1); 
                if (!Equals(_pageSize, value))
                {
                    _pageSize = value;
                    OnPageSizeChanged();
                    OnPropertyChanged();
                }
            }
        }
        int _pageSize = DEFAULT_PAGE_SIZE;
        int CurrentPage
        {
            get => _currentPage;
            set
            {
                value = Math.Max(value, MinPage);
                value = Math.Min(value, MaxPage);
                if (!Equals(_currentPage, value))
                {
                    _currentPage = value;
                    OnCurrentPageChanged();
                    OnPropertyChanged();
                    Debug.WriteLine($"CurrentPage={CurrentPage} MinIndex={RangeMinIndex} MaxIndex={RangeMaxIndex}");
                }
            }
        }
        int _currentPage = default;
        int RangeMinIndex => Items.Any()  ? (CurrentPage -1) * PageSize  : 0;
        int RangeMaxIndex => Items.Any() ? Math.Min(Items.Count, RangeMinIndex + PageSize)  : 0;
        int MinPage => Items.Any() ? 1 : 2;
        int MaxPage => Items.Any() ? 1 + (Items.Count / PageSize)  : 0;
        protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)=>
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        public event PropertyChangedEventHandler? PropertyChanged;
    }
}
