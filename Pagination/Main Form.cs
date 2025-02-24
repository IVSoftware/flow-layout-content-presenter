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
                            TestDataOption = (TestDataOption)option;
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                }
            };
            Length = 25;
        }

        private void OnLengthChanged()
        {
            var removed = contentPresenterFlowLayout.Items.ToArray();
            contentPresenterFlowLayout.Items.Clear();
            Task.Run(async () =>
            {
                foreach (var dispose in removed)
                {
                    removed = null;
                }
                await Task.Delay(TimeSpan.FromSeconds(1));
                GC.Collect(GC.MaxGeneration, GCCollectionMode.Forced, true, true);
            });
            switch (TestDataOption)
            {
                case TestDataOption.ImageRando:
                    contentPresenterFlowLayout.Items
                        .AddRange(Enumerable.Range(0, Length)
                        .Select((_ => new ContentPresenterViewModel(TestDataOption)
                        {
                            ButtonText = "Edit",
                        })));
                    break;
                case TestDataOption.ButtonRegular:
                    contentPresenterFlowLayout.Items
                        .AddRange(Enumerable.Range(0, Length)
                        .Select((_ => new ContentPresenterViewModel(TestDataOption)
                        {
                            ButtonText = $"{_ + 1}",
                        })));
                    break;
                case TestDataOption.ButtonIrregular:
                    contentPresenterFlowLayout.Items
                        .AddRange(Enumerable.Range(0, Length)
                        .Select((_ => new ContentPresenterViewModel(TestDataOption)
                        {
                            ButtonText = $"{_ + 1}",
                            Width = 10 * _randoSize.Next(10, 40),
                            Height = 10 * _randoSize.Next(10, 40),
                        })));
                    break;
                default:
                    throw new NotImplementedException();
            }
        }
        int _length = 0;
        static Random _randoSize = new (1);

        public int Length
        {
            get => _length;
            set
            {
                if (!Equals(_length, value))
                {
                    _length = value;
                    OnLengthChanged();
                }
            }
        }
        TestDataOption TestDataOption
        {
            get => _testDateOption;
            set
            {
                // Don't check for changes here.
                // if (!Equals(_testDateOption, value))
                _testDateOption = value;
                OnLengthChanged();
            }
        }
        TestDataOption _testDateOption = default;

    }
}
