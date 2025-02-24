using Newtonsoft.Json;
using Pagination.Presentation;
using System.Diagnostics;

namespace Pagination.Presentation
{
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
        static Random _randoIdIndex = new (3), _randoOption = new (1);
        static readonly List<int> _distinctIds = new();
        public ContentPresenterViewModel() { }
        public ContentPresenterViewModel(TestDataOption testOption) : this()
        {
            switch (testOption)
            {
                case TestDataOption.ImageRando:
                    ImageLocation = localGetNextPictureLink();
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
                    break;
                case TestDataOption.ButtonRegular:
                    break;
                case TestDataOption.ButtonIrregular:
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
        public string ButtonText { get; set; } = string.Empty;
    }
}
