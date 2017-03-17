using Foundation;
using ReactiveUI;
using System;
using UIKit;

namespace TrainingPA.iOS
{
    public partial class WelcomeController : UIViewController
    {
        public string userName;
        public WelcomeController (IntPtr handle) : base (handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            nameLabel.Text += userName;
           
        }

        
    }
}