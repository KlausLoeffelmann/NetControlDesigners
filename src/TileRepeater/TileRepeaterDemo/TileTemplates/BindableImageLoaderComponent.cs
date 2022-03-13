using System.ComponentModel;

namespace TileRepeaterDemo.TileTemplates
{
    public partial class BindableAsyncImageLoaderComponent : Component, IBindableComponent
    {
        public event EventHandler? ImageChanged;

        private BindingContext? _bindingContext;
        private ControlBindingsCollection? _dataBindings;
        public event EventHandler? BindingContextChanged;
        private Image? _image;
        private string? _imageFilename;

        static SemaphoreSlim s_semaphore = new SemaphoreSlim(2);

        public BindableAsyncImageLoaderComponent()
        {
            InitializeComponent();
        }

        public BindableAsyncImageLoaderComponent(IContainer container)
        {
            container.Add(this);
            InitializeComponent();
        }

        private void UpdateBindings()
        {
            for (int i = 0; i < DataBindings.Count; i++)
            {
                BindingContext.UpdateBinding(BindingContext, DataBindings[i]);
            }
        }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void OnBindingContextChanged(EventArgs e)
        {
            if (_bindingContext is not null)
            {
                UpdateBindings();
            }

            BindingContextChanged?.Invoke(this, e);
        }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [RefreshProperties(RefreshProperties.All)]
        [ParenthesizePropertyName(true)]
        public ControlBindingsCollection DataBindings
        {
            get
            {
                if (_dataBindings is null)
                {
                    _dataBindings = new ControlBindingsCollection(this);
                }
                return _dataBindings;
            }
        }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public BindingContext BindingContext
        {
            get
            {
                _bindingContext ??= new BindingContext();
                return _bindingContext;
            }
            set
            {
                if (!Equals(_bindingContext, value))
                {
                    _bindingContext = value;
                    OnBindingContextChanged(EventArgs.Empty);
                }
            }
        }

        public string? ImageFilename
        {
            get => _imageFilename;
            set
            {
                if (!Equals(_imageFilename, value))
                {
                    _imageFilename = value;
                    OnImageFilenameChanged(EventArgs.Empty);
                }
            }
        }

        public Image? Image
        {
            get => _image;
            private set
            {
                if (!Equals(_image, value))
                {
                    _image = value;
                    OnImageChanged(EventArgs.Empty);
                }
            }
        }

        protected async virtual void OnImageFilenameChanged(EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(_imageFilename))
            {
                if (_image is not null)
                {
                    _image.Dispose();
                    _image = null;
                }

                return;
            }

            try
            {
                Image = await LoadImageAsync(_imageFilename);
            }
            catch (Exception)
            {
            }
        }

        protected virtual void OnImageChanged(EventArgs e)
            => ImageChanged?.Invoke(this, e);

        private static async Task<Image> LoadImageAsync(string fileName)
        {
            await s_semaphore.WaitAsync();

            return await Task.Run<Image>(() =>
            {
                var image = Image.FromFile(fileName);
                return image;
            });
        }
    }
}
