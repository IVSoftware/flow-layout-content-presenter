using Pagination.Presentation;

namespace Pagination
{
    enum TestOption { Items25, Items1M, ImageRando, ButtonRegular, ButtonIrregular }
    public partial class MainForm : Form
    {
        // https://picsum.photos/
        public MainForm()
        {
            InitializeComponent();

            const int NUMBER_OF_ITEMS = 1000000;

            contentPresenterFlowLayout.Items.AddRange(
                Enumerable.Range(0, NUMBER_OF_ITEMS).Select(_=>new ContentPresenterViewModel(testData: true)));

            testToolStripMenuItem.DropDownItemClicked += (sender, e) =>
            {
                if (e.ClickedItem?.Tag is TestOption option)
                {
                    switch (option)
                    {
                        case TestOption.Items25:
                            contentPresenterFlowLayout.Items.Clear();
                            contentPresenterFlowLayout.Items.AddRange(
                                Enumerable.Range(0, 25).Select(_ => new ContentPresenterViewModel(testData: true)));
                            break;
                        case TestOption.Items1M:
                            contentPresenterFlowLayout.Items.Clear();
                            contentPresenterFlowLayout.Items.AddRange(
                                Enumerable.Range(0, 1000000).Select(_ => new ContentPresenterViewModel(testData: true)));
                            break;
                        case TestOption.ImageRando:
                            break;
                        case TestOption.ButtonRegular:
                            break;
                        case TestOption.ButtonIrregular:
                            break;
                        default:
                            throw new NotImplementedException();
                    }
                }
            };
        }
    }
}
