using Newtonsoft.Json;
using Pagination.Presentation;
using System.Configuration;
using System.Diagnostics;

namespace Pagination.Presentation
{
    public partial class ContentPresenter : UserControl
    {
        public ContentPresenter()
        {
            InitializeComponent();
            Visible = DataContext != null;
            button.Click += (sender, e) =>
            {
                var msg =
                    string.IsNullOrWhiteSpace(button.Text)
                    ? "the Button."
                    : button.Text;
                MessageBox.Show($"You clicked {msg}");
            };
        }
        protected override void OnDataContextChanged(EventArgs e)
        {
            base.OnDataContextChanged(e);
            // Customize the behavior when the model loads.
            if (DataContext is ContentPresenterViewModel model)
            {
                switch (model.PresentationOptions)
                {
                    case PresentationOption.PictureBox:
                        pictureBox.ImageLocation = model.ImageLocation;
                        pictureBox.Visible = true;
                        checkBox.Visible = false;
                        button.Visible = false;
                        break;
                    case PresentationOption.PictureBoxWithEditingControls:
                        pictureBox.ImageLocation = model.ImageLocation;
                        pictureBox.Visible = true;
                        checkBox.Visible = true;
                        button.Visible = true;
                        break;
                    case PresentationOption.ButtonOnly:
                        pictureBox.Visible = false;
                        checkBox.Visible = false;
                        button.Visible = true;
                        button.Dock = DockStyle.Fill;
                        break;
                    default:
                        throw new NotImplementedException();
                }
                if (model.ButtonText != null) button.Text = model.ButtonText;
                Width = model.Width ?? 200;
                Height = model.Height ?? 200;
                checkBox.Checked = model.Checked == true;
            }
            Visible = DataContext != null;
        }
    }

    [Flags]
    public enum PresentationOption { PictureBox, PictureBoxWithEditingControls, ButtonOnly }

    [JsonObject]
    public class ContentPresenterViewModel
    {
        static Random _randoIdIndex = new (3), _randoOption = new (1);
        static readonly List<int> _distinctIds = new();
        public ContentPresenterViewModel() { }
        public ContentPresenterViewModel(TestDataOption testOption) : this()
        {
            switch (testOption)
            {
                case TestDataOption.ImageRando:
                    ImageLocation = localGetNextPictureLink();
                    PresentationOptions = (PresentationOption)_randoOption.Next(0, 2);
                    Checked = _randoOption.Next(0, 2) == 1;
                    break;
                case TestDataOption.ButtonRegular:
                    PresentationOptions = PresentationOption.ButtonOnly;
                    break;
                case TestDataOption.ButtonIrregular:
                    PresentationOptions = PresentationOption.ButtonOnly;
                    break;
                default:
                    break;
            }
            string localGetNextPictureLink()
            {
                if(_distinctIds.Count == 0)
                {
                    _distinctIds.AddRange(Enumerable.Range(12, 60).Select(_=>_));
                }
                var idIndex = _randoIdIndex.Next(_distinctIds.Count);
                var id = _distinctIds[idIndex];
                _distinctIds.RemoveAt(idIndex);
                return $"https://picsum.photos/id/{id}/300/200";
            }
        }
        public PresentationOption PresentationOptions { get; set; } = PresentationOption.PictureBox;
        public int? Width { get; set; }
        public int? Height { get; set; }
        public Color? ForeColor { get; set; }
        public Color? BackColorColor { get; set; }
        public string? ImageLocation { get; set; }
        public bool? Checked { get; set; }
        public string? ButtonText { get; set; }
    }
}
