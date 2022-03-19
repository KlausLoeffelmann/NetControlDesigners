using System.ComponentModel;

namespace TileRepeaterDemo.TileTemplates
{
    public partial class BindableAsyncImageLoaderComponent : Component, IBindableComponent
    {
        public event EventHandler? ImageChanged;
        public event EventHandler? ImageFilenameChanged;

        private BindingContext? _bindingContext;
        private ControlBindingsCollection? _dataBindings;
        public event EventHandler? BindingContextChanged;
        private Image? _image;
        private string? _imageFilename;

        static SemaphoreSlim s_semaphore = new SemaphoreSlim(2);

        public BindableAsyncImageLoaderComponent()
        {
            InitializeComponent();
            this.Disposed += BindableAsyncImageLoaderComponent_Disposed;
        }

        private void BindableAsyncImageLoaderComponent_Disposed(object? sender, EventArgs e)
        {
            if (Image is not null)
            {
                Image.Dispose();
            }
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

        [Bindable(true), DefaultValue(null)]
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

        [DefaultValue(false)]
        public bool AutoLoad { get; set; }

        protected async virtual void OnImageFilenameChanged(EventArgs e)
        {
            ImageFilenameChanged?.Invoke(this, e);

            if (AutoLoad)
            {
                await LoadImageAsync();
            }
        }

        [Browsable(false)]
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

        public async virtual Task LoadImageAsync()
        {
            if (string.IsNullOrWhiteSpace(_imageFilename))
            {
                if (Image is not null)
                {
                    Image.Dispose();
                    Image = null;
                }

                return;
            }

            try
            {
                if (Image is not null)
                {
                    Image.Dispose();
                }

                Image = await LoadImageAsync(_imageFilename);
            }
            catch (Exception)
            {
            }
        }

        public virtual void DisposeImage()
        {
            if (Image is not null)
            {
                Image.Dispose();
                Image = null;
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
