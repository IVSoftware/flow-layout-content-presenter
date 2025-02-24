using Pagination.Presentation;

namespace Pagination
{
    [Flags]
    public enum TestLengthOption { Items25, Items1M }
    public enum TestDataOption { ImageRando, ButtonRegular, ButtonIrregular }
    public partial class MainForm : Form
    {
        // https://picsum.photos/
        public MainForm()
        {
            InitializeComponent();
            testToolStripMenuItem.DropDownItemClicked += (sender, e) =>
            {
                if (e.ClickedItem?.Tag is Enum option)
                {
                    switch (option)
                    {
                        case TestLengthOption.Items25:
                            Length = 25;
                            break;
                        case TestLengthOption.Items1M:
                            Length = 1000000;
                            break;
                        case TestDataOption.ImageRando:
                        case TestDataOption.ButtonRegular:
                        case TestDataOption.ButtonIrregular:
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                }
            };
            Length = 25;
        }
        public int Length
        {
            get => _length;
            set
            {
                if (!Equals(_length, value))
                {
                    _length = value;
                    var removed = contentPresenterFlowLayout.Items.ToArray();
                    contentPresenterFlowLayout.Items.Clear();
                    Task.Run(async() =>
                    {
                        foreach(var dispose in removed)
                        {
                            removed = null;
                        }
                        await Task.Delay(TimeSpan.FromSeconds(1)); 
                        GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true, true);
                    });
                    contentPresenterFlowLayout.Items
                        .AddRange(Enumerable.Range(0, Length)
                        .Select((_ => new ContentPresenterViewModel(TestDataOption))));
                }
            }
        }
        int _length = 0;

        TestDataOption TestDataOption
        {
            get => _TestOption;
            set
            {
                if (!Equals(_TestOption, value))
                {
                    _TestOption = value;
                }
            }
        }
        TestDataOption _TestOption = default;

    }
}
