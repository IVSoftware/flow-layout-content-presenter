Having a list of "millions" of controls likely does not set you up to win here. What I'm recommending (and what I understand Olivier Jacot-Descombes to be recommending) is to decouple your data from the UI. You said 

> I created a paginated panel, _which loads list of controls_.

It's loading that many _controls_ that gives us pause here. In the case of "10 items per page" then you need 10 instances of s content presenter (that you design) that loads from a data model which is basically a metadata header. Don't put actual images into this, but rather (as suggested in the comments) link to the image location on disk (or in the cloud as is done in the code below). This keeps the size down of course.

As a general rule, you don't want to create ~ any more controls than you can actually see at one time.

___

**Content Presenter and its View Model**

This model includes some info on what controls to show, whether to check the `CheckBox` and so on.

```
public partial class ContentPresenter : UserControl
{
    public ContentPresenter()
    {
        InitializeComponent();
        Visible = DataContext != null;
    }
    protected override void OnDataContextChanged(EventArgs e)
    {
        base.OnDataContextChanged(e);

        // Customize the behavior when the model loads.
        if (DataContext is ContentPresenterViewModel model)
        {
            pictureBox.ImageLocation = model.ImageLocation;
            pictureBox.Visible = model.PresentationOptions.HasFlag(PresentationOption.PictureBox);
            checkBox.Visible = model.PresentationOptions.HasFlag(PresentationOption.CheckBox);
            button.Visible = model.PresentationOptions.HasFlag(PresentationOption.Button);
            checkBox.Checked = model.Checked == true;
        }

        Visible = DataContext != null;
    }
}

[Flags]
public enum PresentationOption { PictureBox = 0x1, CheckBox = 0x2, Button = 0x4 }

[JsonObject]
public class ContentPresenterViewModel
{
    static Random _randoPic = new Random(2), _randoOption = new Random(1);
    public ContentPresenterViewModel() { }
    public ContentPresenterViewModel(bool testData) : this()
    {
        if (testData)
        {
            ImageLocation = $"https://picsum.photos/id/{_randoPic.Next(13, 200)}/300/200";
            PresentationOptions = (PresentationOption)_randoOption.Next(1, 8);
            Checked = _randoOption.Next(0, 2) == 1;
            switch (_randoOption.Next(1, 3))
            {
                case 0:
                    PresentationOptions = PresentationOption.PictureBox;
                    break;
                case 1:
                    PresentationOptions = PresentationOption.PictureBox | PresentationOption.CheckBox | PresentationOption.Button;
                    ButtonText = "Edit";
                    break;
                case 2:
                    PresentationOptions = PresentationOption.PictureBox;
                    ButtonText = "Button Only";
                    break;
                default: throw new InvalidOperationException();
            }
        }
    }
    public PresentationOption PresentationOptions { get; set; } = PresentationOption.PictureBox;
    public int? Width { get; set; }
    public int? Height { get; set; }
    public Color? ForeColor { get; set; }
    public Color? BackColorColor { get; set; }
    public string? ImageLocation { get; set; }
    public bool? Checked { get; set; }
    public string ButtonText { get; set; } = string.Empty;
}
```
___

**Memory Profile**

Having a million records into memory probably won't happen once things are optimized with lazy loading and such, but let's look at the memory profile and performance of doing that. The app seems to be behaving pretty decently. And by the way, this takes only a couple of seconds to load them all.

[![screenshot][1]][1]
___

**Customized Flow Layout Panel**

Here's an example of loading in response to property changes for CurrentPage that also compensates for any partial page at the end of the list.
___

```
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
```


  [1]: https://i.sstatic.net/533TaUpH.png