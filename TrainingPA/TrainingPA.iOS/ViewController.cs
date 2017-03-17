using System;
using ReactiveUI;
using System.Reactive;
using UIKit;
using System.Reactive.Linq;
using System.Collections.Generic;

namespace TrainingPA.iOS
{
	public partial class ViewController : ReactiveViewController, IViewFor<SigninViewModel>	{
       
        

        public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
            

            
            // Set border and color for LabelCode
			base.ViewDidLoad ();
            ViewModel = new SigninViewModel();

            // Set border and color for RoleButton
            SetBorder(RoleButton);
            SetBorder(CodeLabel);
            SetBorder(RolePickerView);
            SetBorder(oneButton);
            SetBorder(twoButton);
            SetBorder(threeButton);
            SetBorder(fourButton);
            SetBorder(fiveButton);
            SetBorder(sixButton);
            SetBorder(sevenButton);
            SetBorder(eightButton);
            SetBorder(nineButton);
            SetBorder(LoginButton);
            SetBorder(clrButton);
            SetBorder(zeroButton);
            SetBorder(MainView);
            MainView.Layer.CornerRadius = 5f;
            RolePickerView.Model = new RoleModel(RoleButton, ViewModel);
            RolePickerView.Hidden = true;
            RolePickerView.Select(1, 0, true);
            // Open pickerview when click
            RoleButton.TouchUpInside += ((sender, e) => {
                RolePickerView.Hidden = false;
            });
            
            this.Bind(ViewModel, vm => vm.Passcode, v => v.CodeLabel.Text);
            this.Bind(ViewModel, vm => vm.Role, v => v.RoleButton.TitleLabel.Text);
            // Bind all the button to ViewModel
            BindButton();

           

            RolePickerView.Select(ViewModel.SelectedRoleIndex, 0, true);
          
        }

        SigninViewModel _ViewModel;


        public SigninViewModel ViewModel
        {
            get { return _ViewModel; }
            set { this.RaiseAndSetIfChanged(ref _ViewModel, value); }
        }

        object IViewFor.ViewModel
        {
            get { return _ViewModel; }
            set { ViewModel = (SigninViewModel)value; }
        }

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

        /**
         * Function to set the border and border color of the uiview
         * @params: view => The view to be set
         */
        private void SetBorder(UIView view)
        {
            view.Layer.BorderWidth = 0.5f;
            view.Layer.CornerRadius = 2;
            view.Layer.BorderColor = UIColor.Gray.CGColor;
        }

        /*
         * Move to welcome page
        */
        private void Login()
        {

        }

        /*
         * Function to bind all the keypad buttons to the ViewModel
         */
         private void BindButton()
        {
            
            this.BindCommand(this.ViewModel, vm => vm.UpdateCommand, v => v.oneButton, Observable.Return(oneButton.TitleLabel.Text));
            this.BindCommand(this.ViewModel, vm => vm.UpdateCommand, v => v.twoButton, Observable.Return(twoButton.TitleLabel.Text));
            this.BindCommand(this.ViewModel, vm => vm.UpdateCommand, v => v.threeButton, Observable.Return(threeButton.TitleLabel.Text));
            this.BindCommand(this.ViewModel, vm => vm.UpdateCommand, v => v.fourButton, Observable.Return(fourButton.TitleLabel.Text));
            this.BindCommand(this.ViewModel, vm => vm.UpdateCommand, v => v.fiveButton, Observable.Return(fiveButton.TitleLabel.Text));
            this.BindCommand(this.ViewModel, vm => vm.UpdateCommand, v => v.sixButton, Observable.Return(sixButton.TitleLabel.Text));
            this.BindCommand(this.ViewModel, vm => vm.UpdateCommand, v => v.sevenButton, Observable.Return(sevenButton.TitleLabel.Text));
            this.BindCommand(this.ViewModel, vm => vm.UpdateCommand, v => v.eightButton, Observable.Return(eightButton.TitleLabel.Text));
            this.BindCommand(this.ViewModel, vm => vm.UpdateCommand, v => v.nineButton, Observable.Return(nineButton.TitleLabel.Text));
            this.BindCommand(this.ViewModel, vm => vm.UpdateCommand, v => v.zeroButton, Observable.Return(zeroButton.TitleLabel.Text));
            this.BindCommand(this.ViewModel, vm => vm.LoginCommand, v => v.LoginButton);
            ViewModel.LoginCommand.Subscribe(success => {
                if (success) {
                    WelcomeController welcome = this.Storyboard.InstantiateViewController("WelcomeController") as WelcomeController;
                    if (welcome != null)
                    {
                        welcome.userName = ViewModel.Role;
                        this.NavigationController.PushViewController(welcome, true);
                    }
                } else
                {
                    UIAlertView alert = new UIAlertView()
                    {
                        Title = "Error",
                        Message = "Wrong Passcode"
                    };
                    alert.AddButton("OK");
                    alert.Show();
                }
            });
            this.BindCommand(this.ViewModel, vm => vm.ResetCommand, v => v.clrButton);
        }
	}
}

