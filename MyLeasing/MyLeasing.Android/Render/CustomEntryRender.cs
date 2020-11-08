using Android.Content;
using MyLeasing.Droid.Render;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(Entry), typeof(CustomEntryRender))]
namespace MyLeasing.Droid.Render
{
    public class CustomEntryRender : EntryRenderer
    {
        public CustomEntryRender(Context context)
            : base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                Control.Background = null;
            }
        }
    }
}