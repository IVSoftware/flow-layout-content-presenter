using Pagination.Presentation;

namespace Pagination
{
    public partial class MainForm : Form
    {
        // https://picsum.photos/
        public MainForm()
        {
            InitializeComponent();

            const int NUMBER_OF_ITEMS = 1000000;

            contentPresenterFlowLayout.Items.AddRange(
                Enumerable.Range(0, NUMBER_OF_ITEMS).Select(_=>new ContentPresenterViewModel(testData: true)));
        }
    }
}
